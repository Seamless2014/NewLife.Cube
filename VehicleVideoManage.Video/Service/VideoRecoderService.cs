using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using NewLife.Log;
using SIPSorcery.GB28181.Net;
using VehicleVedioManage.Data.Entity;
using VehicleVedioManage.Data.IService;
using VehicleVedioManage.Utility.Enums;
using VehicleVideoManage.Video.IService;
using VehicleVideoManage.Video.ViewModel;

namespace VehicleVideoManage.Video.Service
{
    public class VideoRecoderService : IVideoRecoderService
	{
		private Thread processRealDataThread;

		public ConcurrentDictionary<string, IntPtr> mp4HandlerMap = new ConcurrentDictionary<string, IntPtr>();

		public ConcurrentDictionary<string, VideoFileItem> requestMap = new ConcurrentDictionary<string, VideoFileItem>();

		private bool IsContinue = true;

		private ConcurrentQueue<Mp4Frame> mp4FrameQueue = new ConcurrentQueue<Mp4Frame>();

        private readonly ITracer tracer;
        private readonly IVehicleService vehicleService;
        public VideoRecoderService(ITracer _tracer,IVehicleService _vehicleService)
        {
            this.tracer = _tracer;
            vehicleService = _vehicleService;
        }
		public void Start()
		{
		}

		public void Record(string SimNo, int Channel, byte[] data, bool audio = false)
		{
			if (!requestMap.IsEmpty)
			{
				string key = SimNo + "_" + Channel;
				if (requestMap.ContainsKey(key))
				{
					Mp4Frame f = new Mp4Frame(SimNo, Channel, data, audio);
					mp4FrameQueue.Enqueue(f);
				}
			}
		}

		private void parseVideoRecordRequest()
		{
			DateTime dt = DateTime.Now;
			while (IsContinue)
			{
				try
				{
					string hql = "from VideoFileItem where CreateDate > ? and  (Status = ? Or Status = ? )and FileSource = ?  ";
                    var requests=VideoFileItem.FindAllByCreateDateStatusAndSource(DateTime.Now.AddMinutes(-2.0), (int)VideoFileItemStatus.NOT_UPLOAD, 
                        (int)VideoFileItemStatus.STOP_RECORD, VideoFileItemStatus.USER_RECORDER.ToString());
					foreach (var v in requests)
					{
						if (v.CreateTime.CompareTo(dt) < 0)
						{
							continue;
						}
						if (v.Status == (int)VideoFileItemStatus.NOT_UPLOAD)
						{
							string simNo = v.SimNo;
							if (simNo.Length < 12)
							{
								simNo = "0" + simNo;
							}
							string requestKey = simNo + "_" + v.ChannelId;
							requestMap[requestKey] = v;
						}
						else
						{
							EndRecord(v.SimNo, v.ChannelId);
						}
					}
					Mp4Frame mp4Frame = null;
					while (mp4FrameQueue.TryDequeue(out mp4Frame) && IsContinue)
					{
						WriteMp4File(mp4Frame);
					}
				}
				catch (Exception e)
				{
                    tracer.NewSpan(e.Message, e);
				}
				Thread.Sleep(1000);
			}
		}

		private void WriteMp4File(Mp4Frame mp4Frame)
		{
			if (!requestMap.ContainsKey(mp4Frame.Key))
			{
				return;
			}
			IntPtr mp4FileHandle = IntPtr.Zero;
			try
			{
				if (!mp4HandlerMap.TryGetValue(mp4Frame.Key, out mp4FileHandle))
				{
					mp4FileHandle = CreateMp4File(mp4Frame);
					if (mp4FileHandle == IntPtr.Zero)
					{
						return;
					}
				}
			}
			catch (Exception ex2)
			{
                tracer.NewError(mp4Frame.Key + "用户录像文件时发生错误，终止运行"+","+ex2.Message, ex2);
				return;
			}
			byte[] mp4FrameBytes = mp4Frame.Data;
			try
			{
				IntPtr ptr = RTMPWrapper.BytesToIntPtr(mp4FrameBytes);
				if (mp4FrameBytes[0] == 0 && mp4FrameBytes[1] == 0 && mp4FrameBytes[2] == 0 && mp4FrameBytes[3] == 1)
				{
					RTMPWrapper.Mp4V_Encode(mp4FileHandle, ptr, mp4FrameBytes.Length);
				}
				else
				{
					RTMPWrapper.Mp4A_Encode(mp4FileHandle, ptr, mp4FrameBytes.Length);
				}
				Marshal.FreeHGlobal(ptr);
			}
			catch (Exception ex)
			{
				tracer.NewError(mp4Frame.Key + "用户录像写入发生错误，终止运行"+","+ex.Message, ex);
			}
		}

		public void EndRecord(string simNo, int channelId)
		{
			if (simNo == null)
			{
				return;
			}
			if (simNo.Length < 12)
			{
				simNo = "0" + simNo;
			}
			string key = simNo + "_" + channelId;
			try
			{
				try
				{
					IntPtr mp4FileHandle = IntPtr.Zero;
					VideoFileItem videoFileItem = null;
					if (!mp4HandlerMap.TryGetValue(key, out mp4FileHandle))
					{
						return;
					}
					int i = 0;
					while (i++ < 3 && !mp4HandlerMap.TryRemove(key, out mp4FileHandle))
					{
						tracer.NewSpan(key + "从mp4HandlerMap移除请求失败" + i);
						Thread.Sleep(50);
					}
					if (!(mp4FileHandle != IntPtr.Zero))
					{
						return;
					}
					RTMPWrapper.CloseMp4_Encoder(mp4FileHandle);
					mp4FileHandle = IntPtr.Zero;
					tracer.NewSpan(key + " 用户录像文件写入结束");
					if (!requestMap.TryGetValue(key, out videoFileItem))
					{
						return;
					}
					requestMap.TryRemove(key, out videoFileItem);
					videoFileItem.EndDate = DateTime.Now;
                    videoFileItem.Status = (int)VideoFileItemStatus.UPLOAD_COMPLTETED; 
					try
					{
						string fullFileName = GlobalConfig.VideoServerConfig.FtpPath + "\\" + videoFileItem.FilePath;
						if (File.Exists(fullFileName))
						{
							FileInfo f = new FileInfo(fullFileName);
							videoFileItem.FileLength = (int)f.Length;
						}
					}
					catch (Exception ex3)
					{
						tracer.NewError("计算mp4文件大小发生错误:" + ex3.Message, ex3);
						return;
					}
					videoFileItem.Update();
				}
				catch (Exception ex2)
				{
					tracer.NewError(ex2.Message, ex2);
				}
			}
			catch (Exception ex)
			{
				tracer.NewError(key + "用户录像结束写入时发生错误，终止运行"+","+ex.Message, ex);
			}
		}

		private IntPtr CreateMp4File(Mp4Frame rtp)
		{
			int width = 320;
			int height = 240;
			int videoFrameRate = 25;
			int videoTimeScale = 90000;
			int audioSampleRate = 8000;
			int inputSample = 1024;
			Vehicle vd = vehicleService.getVehicleBySimNo(rtp.SimNo);
			string fileName = vd.SimNo + "_" + rtp.ChannelId + "_" + DateTime.Now.ToString("yyMMddHHmmss") + ".mp4";
			string fullFileName = GlobalConfig.VideoServerConfig.FtpPath + "\\" + fileName;
			IntPtr mp4FileHandle = RTMPWrapper.Init_Mp4Encoder(fullFileName, width, height, videoFrameRate, videoTimeScale, audioSampleRate, inputSample);
			if (!(mp4FileHandle != IntPtr.Zero))
			{
				tracer.NewSpan(rtp.Key + "创建用户录像录制文件失败");
			}
			else
			{
				mp4HandlerMap[rtp.Key] = mp4FileHandle;
				tracer.NewSpan(rtp.Key + "创建用户录像录制文件成功");
				try
				{
					VideoFileItem videoFileItem = null;
					if (requestMap.TryGetValue(rtp.Key, out videoFileItem))
					{
						videoFileItem.Status = (int)VideoFileItemStatus.UPLOADING;
						videoFileItem.UploadDate = DateTime.Now;
						videoFileItem.VehicleId = vd.ID;
						videoFileItem.StartDate = DateTime.Now;
						videoFileItem.PlateNo = vd.PlateNo;
						videoFileItem.FilePath = fileName;
						videoFileItem.Update();
					}
				}
				catch (Exception ex)
				{
					tracer.NewError("用户录像资源文件记录入库失败:" + ex.Message, ex);
				}
			}
			return mp4FileHandle;
		}

		public void Stop()
		{
			try
			{
				IsContinue = false;
				if (processRealDataThread != null)
				{
					processRealDataThread.Join(100000);
				}
			}
			catch (Exception ex)
			{
				tracer.NewError(ex.Message, ex);
			}
		}
	}
}
