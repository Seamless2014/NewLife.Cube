//using System.Runtime.InteropServices;

//namespace VehicleVideoManage.Video.RTMP
//{
//    public class RtmpBroadcastService3
//	{

//		private IntPtr rtmpHandle;

//		private string SimNo = "013100000000";

//		private int ChannelId = 1;

//		private Thread processRealDataThread;

//		private bool continuePull = false;

//		private string RtmpLocation;

//		private short PCM_TO_ADPCMA_BUFFER_SIZE = 642;

//		private byte[] pcmBuffer = new byte[2568];

//		private int pcmBufferOffset = 0;

//		private byte[] outputAdpcmaBuffer = new byte[962];

//		private IntPtr outputAdpcmaIntPtr = IntPtr.Zero;

//		private ushort SequenceNo = 0;

//		private VideoFileUtil fileUtil = new VideoFileUtil();

//		public bool BroadcastRequest = false;

//		public int audioEncoder
//		{
//			get;
//			set;
//		}

//		public event ReceivedHandler OnDataReceived;

//		public RtmpBroadcastService3()
//		{
//			audioEncoder = AudioCoder.G726_40KBPS;
//		}

//		public void Start()
//		{
//			continuePull = true;
//			processRealDataThread = new Thread(pull);
//			processRealDataThread.Start();
//		}

//		public void Stop()
//		{
//			try
//			{
//				if (outputAdpcmaIntPtr != IntPtr.Zero)
//				{
//					Marshal.FreeHGlobal(outputAdpcmaIntPtr);
//				}
//				if (processRealDataThread != null)
//				{
//					processRealDataThread.Abort();
//				}
//			}
//			catch (Exception ex2)
//			{
//				logger.Error(ex2.Message, ex2);
//			}
//			try
//			{
//				if (rtmpHandle != IntPtr.Zero)
//				{
//					RTMPWrapper.RTMP264_Close(rtmpHandle);
//					rtmpHandle = IntPtr.Zero;
//				}
//			}
//			catch (Exception ex)
//			{
//				logger.Error(ex.Message, ex);
//			}
//		}

//		private bool AutoReconnect()
//		{
//			if (rtmpHandle == IntPtr.Zero || RTMPWrapper.RTMP264_IsConnected(rtmpHandle) == 0)
//			{
//				if (rtmpHandle != IntPtr.Zero)
//				{
//					RTMPWrapper.RTMP264_Close(rtmpHandle);
//				}
//				rtmpHandle = RTMPWrapper.RTMP264_InitPull(RtmpLocation);
//				string result = ((rtmpHandle != IntPtr.Zero) ? "成功" : "失败");
//				logger.Error("广播服务：" + RtmpLocation + ",音频编码:" + AudioCoder.GetAudioCoderDescr(audioEncoder) + "," + result);
//			}
//			return rtmpHandle != IntPtr.Zero && RTMPWrapper.RTMP264_IsConnected(rtmpHandle) == 1;
//		}

//		private void pull()
//		{
//			try
//			{
//				RtmpLocation = GlobalConfig.RtmpLocation + "broadcast";
//				rtmpHandle = RTMPWrapper.RTMP264_InitPull(RtmpLocation);
//				string result = ((rtmpHandle != IntPtr.Zero) ? "拉流成功" : "拉流失败");
//				logger.Error("广播服务：" + RtmpLocation + ",音频编码:" + AudioCoder.GetAudioCoderDescr(audioEncoder) + "," + result);
//				int bufsize = 1024;
//				byte[] buf = new byte[bufsize];
//				byte[] pcMBuff = new byte[320];
//				if (!(rtmpHandle != IntPtr.Zero))
//				{
//					return;
//				}
//				int nRead = 0;
//				IntPtr ptrBuffer = RTMPWrapper.BytesToIntPtr(buf, 0, bufsize);
//				IntPtr pcmPtrBuffer = RTMPWrapper.BytesToIntPtr(pcMBuff, 0, pcMBuff.Length);
//				while (continuePull)
//				{
//					if (!BroadcastRequest)
//					{
//						GlobalConfig.BroadcastState = null;
//					}
//					try
//					{
//						AutoReconnect();
//						while (continuePull && BroadcastRequest && (nRead = RTMPWrapper.RTMP264_Read(rtmpHandle, ptrBuffer, bufsize)) > 0)
//						{
//							byte[] outSpeexData = new byte[nRead];
//							Marshal.Copy(ptrBuffer, outSpeexData, 0, nRead);
//							int speexLen = nRead - 1;
//							IntPtr speexFrame = RTMPWrapper.BytesToIntPtr(outSpeexData, 1, speexLen);
//							byte[] outPcmData = new byte[pcMBuff.Length];
//							Marshal.Copy(pcmPtrBuffer, outPcmData, 0, pcMBuff.Length);
//							EncoderAudio(outPcmData);
//						}
//					}
//					catch (Exception ex2)
//					{
//						logger.Error(ex2.Message, ex2);
//					}
//					Thread.Sleep((nRead > 0) ? 5 : 5);
//				}
//			}
//			catch (Exception ex)
//			{
//				logger.Error(ex.Message, ex);
//			}
//		}

//		private void EncoderAudio(byte[] pcmData)
//		{
//			if (outputAdpcmaIntPtr == IntPtr.Zero)
//			{
//				outputAdpcmaIntPtr = RTMPWrapper.BytesToIntPtr(outputAdpcmaBuffer, 0, outputAdpcmaBuffer.Length);
//			}
//			Array.Copy(pcmData, 0, pcmBuffer, pcmBufferOffset, pcmData.Length);
//			pcmBufferOffset += pcmData.Length;
//			if (pcmBufferOffset >= PCM_TO_ADPCMA_BUFFER_SIZE)
//			{
//				IntPtr pcmFrameIntPtr = RTMPWrapper.BytesToIntPtr(pcmBuffer, 0, PCM_TO_ADPCMA_BUFFER_SIZE);
//				short outLen = 0;
//				if (RTMPWrapper.EncodeAudioFrame(audioEncoder, pcmFrameIntPtr, outputAdpcmaIntPtr, PCM_TO_ADPCMA_BUFFER_SIZE, ref outLen) == 0)
//				{
//					byte[] outAdpcmaData = new byte[outLen];
//					Marshal.Copy(outputAdpcmaIntPtr, outAdpcmaData, 0, outLen);
//					CreateRTPPacket(outAdpcmaData);
//				}
//				Marshal.FreeHGlobal(pcmFrameIntPtr);
//				pcmBufferOffset -= PCM_TO_ADPCMA_BUFFER_SIZE;
//				if (pcmBufferOffset > 0)
//				{
//					Array.Copy(pcmBuffer, PCM_TO_ADPCMA_BUFFER_SIZE, pcmBuffer, 0, pcmBufferOffset);
//				}
//			}
//		}

//		private void CreateRTPPacket(byte[] adpcmData)
//		{
//			ulong timestamp = ConvertDateTimeInt(DateTime.Now);
//			int rtpPayloadType = AudioCoder.GetRTPAudioPayLoadType(audioEncoder);
//			RTPPacket r = new RTPPacket(SimNo, ChannelId, SequenceNo++, timestamp, adpcmData, rtpPayloadType);
//			if (SequenceNo > 65533)
//			{
//				SequenceNo = 0;
//			}
//			this.OnDataReceived?.Invoke(null, new ReceivedEventArgs(null, r));
//		}

//		public static ulong ConvertDateTimeInt(DateTime time)
//		{
//			DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
//			return (ulong)(time - startTime).TotalMilliseconds;
//		}
//	}
//}
