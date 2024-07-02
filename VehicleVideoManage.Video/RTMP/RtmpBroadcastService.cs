//using System.Runtime.InteropServices;

//namespace VehicleVideoManage.Video.RTMP
//{
//    public class RtmpBroadcastService
//	{

//		private IntPtr rtmpHandle;

//		private string SimNo = "013100000000";

//		private int ChannelId = 1;

//		private Thread processRealDataThread;

//		private bool continuePull = false;

//		private string RtmpLocation;

//		private short AUDIO_ENCODER_BUFFER_SIZE = 640;

//		private short PCM_TO_ADPCMA_BUFFER_SIZE = 642;

//		private byte[] pcmBuffer = new byte[4096];

//		private int pcmBufferOffset = 0;

//		private byte[] outputAdpcmaBuffer = new byte[962];

//		private IntPtr outputAdpcmaIntPtr = IntPtr.Zero;

//		private ushort SequenceNo = 0;

//		private VideoFileUtil fileUtil = new VideoFileUtil();

//		public bool BroadcastRequest = false;

//		private IntPtr speexDecoderHandle = IntPtr.Zero;

//		private AACDecoderSpecific adsAACDecoderSpecific = new AACDecoderSpecific();

//		private AudioSpecificConfig ascAudioSpecificConfig = new AudioSpecificConfig();

//		private WaveFileWriter waveFile;

//		private IntPtr aacDecoder = IntPtr.Zero;

//		public int audioEncoder
//		{
//			get;
//			set;
//		}

//		public event ReceivedHandler OnDataReceived;

//		public RtmpBroadcastService()
//		{
//			audioEncoder = AudioCoder.ADPCM_DVI4;
//		}

//		public void Start()
//		{
//			continuePull = true;
//			speexDecoderHandle = RTMPWrapper.SpeexDecoder_Init();
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
//				if (speexDecoderHandle != IntPtr.Zero)
//				{
//					RTMPWrapper.SpeexDecoder_Dispose(speexDecoderHandle);
//					speexDecoderHandle = IntPtr.Zero;
//				}
//				if (rtmpHandle != IntPtr.Zero)
//				{
//					RTMPWrapper.RTMP264_Close(rtmpHandle);
//					rtmpHandle = IntPtr.Zero;
//				}
//				if (aacDecoder != IntPtr.Zero)
//				{
//					RTMPWrapper.CloseAacDecoder(aacDecoder);
//					aacDecoder = IntPtr.Zero;
//				}
//				if (waveFile != null)
//				{
//					waveFile.Close();
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
//						int packetType = 0;
//						while (continuePull && BroadcastRequest && (nRead = RTMPWrapper.RTMP264_ReadPacket(rtmpHandle, ptrBuffer, ref packetType, bufsize)) > 0)
//						{
//							byte[] frame = null;
//							frame = new byte[nRead];
//							Marshal.Copy(ptrBuffer, frame, 0, nRead);
//							byte[] outSpeexData = new byte[nRead];
//							Marshal.Copy(ptrBuffer, outSpeexData, 0, nRead);
//							if (packetType == RTMPPacketType.RTMP_PACKET_TYPE_AUDIO)
//							{
//								int audioTag = frame[0];
//								if (audioTag == 175)
//								{
//									if (frame[1] == 0)
//									{
//										adsAACDecoderSpecific.nAudioFortmatType = (byte)((frame[0] & 0xF0) >> 4);
//										adsAACDecoderSpecific.nAudioSampleType = (byte)((frame[0] & 0xC) >> 2);
//										adsAACDecoderSpecific.nAudioSizeType = (byte)((frame[0] & 2) >> 1);
//										adsAACDecoderSpecific.nAudioStereo = (byte)(frame[0] & 1u);
//										if (adsAACDecoderSpecific.nAudioFortmatType == 10)
//										{
//											adsAACDecoderSpecific.nAccPacketType = frame[1];
//											ushort audioSpecificConfig = 0;
//											audioSpecificConfig = (ushort)((frame[2] & 0xFF) << 8);
//											audioSpecificConfig = (ushort)(audioSpecificConfig + (ushort)(0xFF & frame[3]));
//											ascAudioSpecificConfig.nAudioObjectType = (byte)((audioSpecificConfig & 0xF800) >> 11);
//											ascAudioSpecificConfig.nSampleFrequencyIndex = (byte)((audioSpecificConfig & 0x780) >> 7);
//											ascAudioSpecificConfig.nChannels = (byte)((audioSpecificConfig & 0x78) >> 3);
//											ascAudioSpecificConfig.nFrameLengthFlag = (byte)((audioSpecificConfig & 4) >> 2);
//											ascAudioSpecificConfig.nDependOnCoreCoder = (byte)((audioSpecificConfig & 2) >> 1);
//											ascAudioSpecificConfig.nExtensionFlag = (byte)(audioSpecificConfig & 1u);
//										}
//										else if (adsAACDecoderSpecific.nAudioFortmatType == 11)
//										{
//											adsAACDecoderSpecific.nAudioStereo = 0;
//											adsAACDecoderSpecific.nAudioSizeType = 1;
//											adsAACDecoderSpecific.nAudioSampleType = 4;
//										}
//									}
//									else
//									{
//										int frameLength = frame.Length - 2 + 7;
//										byte[] adts = CreateADTS(ascAudioSpecificConfig, (ushort)frameLength);
//										int rawDataLength = frame.Length - 2;
//										string audioFileName = "aac" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".aac";
//										byte[] aacFrame = new byte[frameLength];
//										Buffer.BlockCopy(adts, 0, aacFrame, 0, adts.Length);
//										Buffer.BlockCopy(frame, 2, aacFrame, 7, frame.Length - 2);
//										processAACAudio(aacFrame);
//									}
//								}
//								else
//								{
//									byte[] d = new byte[frame.Length - 1];
//									logger.Error("speex音频帧长度" + d.Length);
//									int speexLen = nRead - 1;
//									IntPtr speexFrame = RTMPWrapper.BytesToIntPtr(outSpeexData, 1, speexLen);
//									RTMPWrapper.SpeexDecoder_Decode(speexDecoderHandle, speexLen, speexFrame, pcmPtrBuffer);
//									byte[] outPcmData = new byte[pcMBuff.Length];
//									Marshal.Copy(pcmPtrBuffer, outPcmData, 0, pcMBuff.Length);
//									EncoderAudio(outPcmData);
//								}
//							}
//							Thread.Sleep(5);
//						}
//						if (continuePull && BroadcastRequest && nRead == 0)
//						{
//							if (rtmpHandle != IntPtr.Zero)
//							{
//								RTMPWrapper.RTMP264_Close(rtmpHandle);
//							}
//							rtmpHandle = IntPtr.Zero;
//							logger.Error(RtmpLocation + "关闭对讲拉流，等待再次重连");
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
//			if (GlobalConfig.SaveTalkAudioToWav)
//			{
//				if (waveFile == null)
//				{
//					WaveFormat WaveFormat = new WaveFormat(8000, 16, 1);
//					string fn = "user_broadcast_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".wav";
//					waveFile = new WaveFileWriter(fn, WaveFormat);
//				}
//				waveFile.Write(pcmData, 0, pcmData.Length);
//				waveFile.Flush();
//			}
//			if (outputAdpcmaIntPtr == IntPtr.Zero)
//			{
//				outputAdpcmaIntPtr = RTMPWrapper.BytesToIntPtr(outputAdpcmaBuffer, 0, outputAdpcmaBuffer.Length);
//			}
//			Array.Copy(pcmData, 0, pcmBuffer, pcmBufferOffset, pcmData.Length);
//			pcmBufferOffset += pcmData.Length;
//			if (audioEncoder == AudioCoder.ADPCM_IMA || audioEncoder == AudioCoder.ADPCM_DVI4)
//			{
//				AUDIO_ENCODER_BUFFER_SIZE = 642;
//			}
//			while (pcmBufferOffset >= AUDIO_ENCODER_BUFFER_SIZE)
//			{
//				IntPtr pcmFrameIntPtr = RTMPWrapper.BytesToIntPtr(pcmBuffer, 0, AUDIO_ENCODER_BUFFER_SIZE);
//				short outLen = 0;
//				if (RTMPWrapper.EncodeAudioFrame(audioEncoder, pcmFrameIntPtr, outputAdpcmaIntPtr, AUDIO_ENCODER_BUFFER_SIZE, ref outLen) == 0)
//				{
//					byte[] outAdpcmaData = new byte[outLen];
//					Marshal.Copy(outputAdpcmaIntPtr, outAdpcmaData, 0, outLen);
//					CreateRTPPacket(outAdpcmaData);
//				}
//				else
//				{
//					logger.Error(AudioCoder.GetAudioCoderDescr(audioEncoder) + "编码错误");
//				}
//				Marshal.FreeHGlobal(pcmFrameIntPtr);
//				pcmBufferOffset -= AUDIO_ENCODER_BUFFER_SIZE;
//				if (pcmBufferOffset > 0)
//				{
//					Array.Copy(pcmBuffer, AUDIO_ENCODER_BUFFER_SIZE, pcmBuffer, 0, pcmBufferOffset);
//				}
//			}
//		}

//		private void CreateRTPPacket(byte[] adpcmData)
//		{
//			if (GlobalConfig.BroadcastAudioWithoutHISI)
//			{
//				byte[] d = new byte[adpcmData.Length - 4];
//				Array.Copy(adpcmData, 4, d, 0, d.Length);
//				adpcmData = d;
//			}
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

//		private void processAACAudio(byte[] aacFrame)
//		{
//			IntPtr ptrAacFrame = RTMPWrapper.BytesToIntPtr(aacFrame, 0, aacFrame.Length);
//			int samples = 0;
//			int channels = 0;
//			int sampleRate = 0;
//			if (aacDecoder == IntPtr.Zero)
//			{
//				aacDecoder = RTMPWrapper.InitAACDecoder(ptrAacFrame, aacFrame.Length, ref samples, ref channels);
//			}
//			IntPtr ptrPcmData = RTMPWrapper.AacDecode(aacDecoder, ptrAacFrame, aacFrame.Length, ref samples, ref sampleRate, ref channels);
//			if (ptrPcmData != IntPtr.Zero && samples > 0)
//			{
//				int pcmDataLength = samples * channels;
//				byte[] pcmData = new byte[pcmDataLength];
//				Marshal.Copy(ptrPcmData, pcmData, 0, pcmData.Length);
//				byte[] frame_mono = new byte[2048];
//				int i = 0;
//				int j = 0;
//				while (i < 4096 && j < 2048)
//				{
//					frame_mono[j] = pcmData[i];
//					frame_mono[j + 1] = pcmData[i + 1];
//					i += 4;
//					j += 2;
//				}
//				EncoderAudio(frame_mono);
//				Marshal.FreeHGlobal(ptrAacFrame);
//			}
//		}

//		private byte[] CreateADTS(AudioSpecificConfig ascAudioSpecificConfig, ushort nAudioFrameLength)
//		{
//			byte[] adts = new byte[7];
//			int chanCfg = ascAudioSpecificConfig.nChannels;
//			adts[0] = byte.MaxValue;
//			adts[1] = 249;
//			adts[2] = (byte)((ascAudioSpecificConfig.nAudioObjectType - 1 << 6) + (ascAudioSpecificConfig.nSampleFrequencyIndex << 2) + (chanCfg >> 2));
//			adts[3] = (byte)(((chanCfg & 3) << 6) + (nAudioFrameLength >> 11));
//			adts[4] = (byte)((nAudioFrameLength & 0x7FF) >> 3);
//			adts[5] = (byte)(((nAudioFrameLength & 7) << 5) + 31);
//			adts[6] = 252;
//			return adts;
//		}
//	}
//}
