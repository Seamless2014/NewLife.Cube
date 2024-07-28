using System.Collections.Concurrent;
using NewLife.Log;
using VehicleVedioManage.Utility.Enums;
using VehicleVideoManage.Video.IService;
using VehicleVideoManage.Video.RTMP;
using VehicleVideoManage.Video.ViewModel;

namespace GpsNET.Service
{
    public class VideoRealTimeRequestService : IVideoRealTimeRequestService
	{
		private bool IsContinue = true;

		private Thread processRealDataThread;

		public ConcurrentDictionary<string, VideoRequestMessage> governmentRequestMmap = new ConcurrentDictionary<string, VideoRequestMessage>();

		public ConcurrentDictionary<string, VideoRequestMessage> localRequestMmap = new ConcurrentDictionary<string, VideoRequestMessage>();

		public ConcurrentDictionary<string, VideoRequestMessage> talkRequestMap = new ConcurrentDictionary<string, VideoRequestMessage>();

		public ConcurrentDictionary<string, VideoRequestMessage> broadcastRequestMap = new ConcurrentDictionary<string, VideoRequestMessage>();
        private readonly ITracer tracer;
        private RtmpBroadcastService rtmpBroadcastService;
        private VideoRealTimeRequestService(ITracer _tracer,RtmpBroadcastService _rtmpBroadcastService)
        {
            tracer = _tracer;
            rtmpBroadcastService = _rtmpBroadcastService;
        }
		public void Start()
		{
			IsContinue = true;
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

		public void UpdateVideoRequest(VideoRequestMessage vm)
		{
			string key = GetKey(vm.simNo, vm.channelId);
			if (vm.userId > 0)
			{
				if (vm.command == VideoRequestType.PLAY.ToString())
				{
					localRequestMmap[key] = vm;
					if (vm.mediaType == (int)VideoDataType.TALK)
					{
						talkRequestMap[key] = vm;
					}
					else if (vm.mediaType == (int)VideoDataType.BROADCAST)
					{
						broadcastRequestMap[key] = vm;
                        rtmpBroadcastService.BroadcastRequest = true;
					}
				}
				else if (vm.command == VideoRequestType.STOP.ToString())
				{
					VideoRequestMessage t = null;
					localRequestMmap.TryRemove(key, out t);
					if (vm.mediaType == (int)VideoDataType.TALK)
					{
						talkRequestMap.TryRemove(key, out t);
					}
					else if (vm.mediaType == (int)VideoDataType.BROADCAST)
					{
						broadcastRequestMap.TryRemove(key, out t);
                        rtmpBroadcastService.BroadcastRequest = false;
					}
				}
			}
			else if (vm.command == VideoRequestType.PLAY.ToString())
			{
				governmentRequestMmap[key] = vm;
			}
			else if (vm.command == VideoRequestType.STOP.ToString())
			{
				governmentRequestMmap.TryRemove(key, out vm);
			}
		}

		public void ClearRequest()
		{
			localRequestMmap.Clear();
			governmentRequestMmap.Clear();
			talkRequestMap.Clear();
		}

		private bool IsGovernmentRequest(string SimNo, int Channel)
		{
			string key = GetKey(SimNo, Channel);
			VideoRequestMessage v = null;
			if (governmentRequestMmap.TryGetValue(key, out v))
			{
				return true;
			}
			return false;
		}

		private bool IsBroadcastRequest()
		{
			return broadcastRequestMap.Count > 0;
		}

		private bool IsTalkRequest(string SimNo, int Channel)
		{
			if (SimNo.Length > 11)
			{
				SimNo = SimNo.Substring(SimNo.Length - 11);
			}
			string key = GetKey(SimNo, Channel);
			VideoRequestMessage v = null;
			if (talkRequestMap.TryGetValue(key, out v))
			{
				return true;
			}
			return false;
		}

		private bool IsLocalRequest(string SimNo, int Channel)
		{
			string key = GetKey(SimNo, Channel);
			VideoRequestMessage v = null;
			if (localRequestMmap.TryGetValue(key, out v))
			{
				return true;
			}
			return false;
		}

		private string GetKey(string SimNo, int Channel)
		{
			if (SimNo.Length > 11)
			{
				SimNo = SimNo.Substring(SimNo.Length - 11);
			}
			return SimNo + "_" + Channel;
		}
	}
}
