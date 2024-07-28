using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using NAudio.Wave;
using NewLife.Log;
using VehicleVedioManage.Data.Entity;
using VehicleVedioManage.Data.IService;
using VehicleVedioManage.Utility.Enums;
using VehicleVideoManage.Video.Audio;
using VehicleVideoManage.Video.Codec;
using VehicleVideoManage.Video.IService;
using VehicleVideoManage.Video.RTP;
using VehicleVideoManage.Video.Service;

namespace VehicleVideoManage.Video.RTMP
{
    /// <summary>
    /// RTP分析器
    /// </summary>
    public class RTPAnalyzer
    {
        /// <summary>
        /// 数据包缓冲区
        /// </summary>
        private byte[] packetBuffer = new byte[251200];
        /// <summary>
        /// 缓冲区长度
        /// </summary>
        private int bufferDataLength;
        /// <summary>
        /// 是否 aac发送
        /// </summary>
        private bool aacSpecSent = false;
        /// <summary>
        /// 推送时间
        /// </summary>
        public DateTime PushTime = DateTime.Now;
        /// <summary>
        /// 实时数据线程
        /// </summary>
        private Thread processRealDataThread;
        /// <summary>
        /// MP4文件写线程
        /// </summary>
        private Thread mp4FileWriteThread;
        /// <summary>
        /// PCM视频队列
        /// </summary>
        public ConcurrentQueue<byte[]> PcmAudioQueue = new ConcurrentQueue<byte[]>();
        /// <summary>
        /// MP4帧队列
        /// </summary>
        public ConcurrentQueue<byte[]> mp4FrameQueue = new ConcurrentQueue<byte[]>();
        /// <summary>
        /// RTP队列
        /// </summary>
        public ConcurrentQueue<AVFrame> rtpQueue = new ConcurrentQueue<AVFrame>();
        /// <summary>
        /// RTMP处理器
        /// </summary>
        private IntPtr rtmpHandle;
        /// <summary>
        /// MP4文件处理器
        /// </summary>
        private IntPtr mp4FileHandle;
        /// <summary>
        /// 是否sps帧发送
        /// </summary>
        private bool spsFrameSend = false;
        /// <summary>
        /// 是否停止写MP4文件
        /// </summary>
        private bool stopWriteMp4File = false;
        /// <summary>
        /// 最新RTP包
        /// </summary>
        private AVFrame LatestRTPPacket = null;
        /// <summary>
        /// 最新完成RP包
        /// </summary>
        private AVFrame LastCompletedRTPPacket = null;
        /// <summary>
        /// 最新音频RTP包
        /// </summary>
        private AVFrame LastAudioRTPPacket = null;
        /// <summary>
        /// 滴答声
        /// </summary>
        private int tick = 0;
        /// <summary>
        /// 滴答声间隔
        /// </summary>
        private int tickInterval = 0;
        /// <summary>
        /// 视频文件项
        /// </summary>
        private VideoFileItem videoFileItem = null;
        /// <summary>
        /// 是否继续分析
        /// </summary>
        private bool continueAnalyze = true;
        /// <summary>
        /// 继承了Stream, 用来写入文件, 常用于保存音频录制的数据
        /// </summary>
        private WaveFileWriter waveFile;
        /// <summary>
        /// 最新包序列号
        /// </summary>
        private int lastPacketSerialNo = -1;
        /// <summary>
        /// 最新音频帧时间戳
        /// </summary>
        private ulong lastAudioFrameTimestamp = 0uL;
        /// <summary>
        /// 音频帧间隔
        /// </summary>
        private ulong audioFrameInterval = 0uL;
        /// <summary>
        /// 音频间隔
        /// </summary>
        private int audioTick = 0;
        /// <summary>
        /// 总接收包数
        /// </summary>
        private int totalRecvPacketNum = 1;
        /// <summary>
        /// 第一个包序号
        /// </summary>
        private int firstPacketSerialNo = 0;
        /// <summary>
        /// 丢包率
        /// </summary>
        public int PacketLostRate = 0;
        /// <summary>
        /// 本地amr解码器
        /// </summary>
        private IntPtr mNativeAmrDecoder = IntPtr.Zero;
        /// <summary>
        /// sps帧
        /// </summary>
        private byte[] spsFrame;
        /// <summary>
        /// pps帧
        /// </summary>
        private byte[] ppsFrame;

        public static uint HI_ERR_VOICE_PREFIX = 2703360000u;

        public static uint HI_ERR_VOICE_ENC_TYPE = HI_ERR_VOICE_PREFIX | 1u;

        public static uint HI_ERR_VOICE_ENC_FRAMESIZE = HI_ERR_VOICE_PREFIX | 2u;

        public static uint HI_ERR_VOICE_DEC_TYPE = HI_ERR_VOICE_PREFIX | 0x11u;

        public static uint HI_ERR_VOICE_DEC_FRAMESIZE = HI_ERR_VOICE_PREFIX | 0x12u;

        public static uint HI_ERR_VOICE_DEC_FRAMETYPE = HI_ERR_VOICE_PREFIX | 0x13u;

        public static uint HI_ERR_VOICE_INVALID_DEVICE = HI_ERR_VOICE_PREFIX | 0x101u;

        public static uint HI_ERR_VOICE_INVALID_INBUF = HI_ERR_VOICE_PREFIX | 0x102u;

        public static uint HI_ERR_VOICE_INVALID_OUTBUF = HI_ERR_VOICE_PREFIX | 0x103u;

        public static uint HI_ERR_VOICE_TRANS_DEVICE = HI_ERR_VOICE_PREFIX | 0x1001u;

        public static uint HI_ERR_VOICE_TRANS_TYPE = HI_ERR_VOICE_PREFIX | 0x1002u;

        public static int MAX_OUT_BUFFER_LEN = 962;

        private byte[] outPCM = null;

        private IntPtr outPCMFrame = IntPtr.Zero;

        private IntPtr aacFrame = IntPtr.Zero;

        private byte[] pcmBuffer = new byte[3200];

        private int pcmBufferOffset = 0;

        private byte[] outputAacBuffer = null;

        private int inputSamples = 0;

        private int maxOutputBytes = 0;

        private FileStream audioAacFileStream = null;
        /// <summary>
        /// 服务类型
        /// </summary>
        public ServerType ServerType
        {
            get;
            set;
        }
        /// <summary>
        /// 音频解码
        /// </summary>
        public int AudioDecoder
        {
            get;
            set;
        }
        /// <summary>
        /// aac编码
        /// </summary>
        public IntPtr aacEncoder
        {
            get;
            set;
        }
        /// <summary>
        /// RTMP 位置
        /// </summary>
        public string RtmpLocation
        {
            get;
            set;
        }
        /// <summary>
        /// sim卡号
        /// </summary>
        private string SimNo
        {
            get;
            set;
        }
        /// <summary>
        /// 通道号
        /// </summary>
        public int ChannelId
        {
            get;
            set;
        }
        /// <summary>
        /// 丢失包数
        /// </summary>
        public int lostPacketNum
        {
            get;
            set;
        }
        private readonly ITracer tracer;
        private readonly IVehicleService _IVehicleService;
        private readonly IVideoRecoderService _VideoRecoderService;
        public RTPAnalyzer(ITracer tracer, IVehicleService vehicleService, IVideoRecoderService _videoRecoderService)
        {
            tracer = tracer;
            _IVehicleService = vehicleService;
            _VideoRecoderService= _videoRecoderService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_simNo"></param>
        /// <param name="_channel"></param>
        public RTPAnalyzer(string _simNo, int _channel)
        {
            aacEncoder = IntPtr.Zero;
            continueAnalyze = true;
            tracer.NewSpan(_simNo + "_" + _channel + "创建并启动RTP分析线程");
            processRealDataThread = new Thread(analyze);
            processRealDataThread.Start();
        }
        /// <summary>
        /// 获取RP包队列数
        /// </summary>
        /// <returns></returns>
        public int GetRTPPacketQueueNum()
        {
            return rtpQueue.Count;
        }
        /// <summary>
        /// 分析RTP包
        /// </summary>
        /// <param name="rtp"></param>
        public void Analyze(RTPPacket rtp)
        {
            if (firstPacketSerialNo == 0)
            {
                firstPacketSerialNo = rtp.SequenceNumber;
            }
            if (lastPacketSerialNo >= 0)
            {
                int t = rtp.SequenceNumber - lastPacketSerialNo - 1;
                if (t > 0)
                {
                    lostPacketNum += t;
                }
            }
            lastPacketSerialNo = rtp.SequenceNumber;
            totalRecvPacketNum = lastPacketSerialNo - firstPacketSerialNo + 1;
            if (totalRecvPacketNum > 0)
            {
                PacketLostRate = lostPacketNum * 100 / totalRecvPacketNum;
            }
            if (rtp.FrameType == RTPPacketExtend.FRAME_AUDIO)
            {
            }
            if (mp4FileWriteThread == null && GlobalConfig.RecordVideo)
            {
                mp4FileWriteThread = new Thread(mp4FileWriteThreadFunc);
                mp4FileWriteThread.Start();
                tracer.NewSpan(RtmpLocation + "启动mp4录制线程");
            }
            if (string.IsNullOrEmpty(SimNo))
            {
                SimNo = rtp.SimNo;
                ChannelId = rtp.ChannelId;
            }
        }

        public void Analyze(AVFrame avFrame)
        {
            if (mp4FileWriteThread == null && GlobalConfig.RecordVideo)
            {
                mp4FileWriteThread = new Thread(mp4FileWriteThreadFunc);
                mp4FileWriteThread.Start();
                tracer.NewSpan(RtmpLocation + "启动mp4录制线程");
            }
            if (string.IsNullOrEmpty(SimNo))
            {
                SimNo = avFrame.SimNo;
                ChannelId = avFrame.ChannelId;
            }
            LatestRTPPacket = avFrame;
            rtpQueue.Enqueue(avFrame);
        }

        private void analyze()
        {
            while (continueAnalyze)
            {
                AVFrame rtp = null;
                if (rtpQueue.Count > 200)
                {
                    tracer.NewSpan(RtmpLocation + "堵塞");
                }
                while (continueAnalyze && rtpQueue.TryDequeue(out rtp))
                {
                    try
                    {
                        pushAvFrame(rtp);
                    }
                    catch (Exception ex)
                    {
                        tracer.NewError(ex.Message, ex);
                    }
                }
                Thread.Sleep(2);
            }
            tracer.NewSpan(string.Concat(ServerType, ",", RtmpLocation, "线程正常退出"));
        }

        private void calcTickInterval(AVFrame rtp)
        {
            if (LastCompletedRTPPacket != null)
            {
                ulong interval = rtp.Timestamp - LastCompletedRTPPacket.Timestamp;
                tickInterval = (int)((interval == 0 || interval > 100000) ? 40 : interval);
                if (GlobalConfig.ForceInterval)
                {
                    tickInterval = 40;
                }
            }
            LastCompletedRTPPacket = rtp;
        }

        private string getFrameType(RTPPacket msg)
        {
            string strFrameType = "";
            if (msg.FrameType == 0)
            {
                strFrameType = "I帧";
            }
            else if (msg.FrameType == 1)
            {
                strFrameType = "P帧";
            }
            else if (msg.FrameType == 2)
            {
                strFrameType = "B帧";
            }
            else if (msg.FrameType == 3)
            {
                strFrameType = "音频";
            }
            else if (msg.FrameType == 4)
            {
                strFrameType = "透传";
            }
            return strFrameType;
        }

        private void pushAvFrame(AVFrame rtp)
        {
            if (rtmpHandle == IntPtr.Zero)
            {
                try
                {
                    if (rtmpHandle != IntPtr.Zero)
                    {
                        tracer.NewSpan(string.Concat(ServerType, ",RTMP连接断开,关闭当前连接,开始重连接，推流地址:", RtmpLocation));
                        RTMPWrapper.RTMP264_Close(rtmpHandle);
                        rtmpHandle = IntPtr.Zero;
                    }
                    string simNo = rtp.SimNo;
                    if (simNo.Length > 11 && GlobalConfig.SimNoLength == 11)
                    {
                        simNo = "0" + rtp.SimNo.Substring(1);
                    }
                    if (ServerType == ServerType.Playback)
                    {
                        RtmpLocation = GlobalConfig.RtmpLocation + rtp.SimNo + "_" + rtp.ChannelId + "_playback";
                    }
                    else if (ServerType == ServerType.Talk)
                    {
                        RtmpLocation = GlobalConfig.RtmpLocation + rtp.SimNo + "_" + rtp.ChannelId + "_talk";
                    }
                    else
                    {
                        RtmpLocation = GlobalConfig.RtmpLocation + simNo + "_" + rtp.ChannelId;
                    }
                    rtmpHandle = RTMPWrapper.RTMP264_Create(RtmpLocation);
                    bool Connected = rtmpHandle != IntPtr.Zero;
                    string result = (Connected ? "成功" : "失败");
                    if (!Connected)
                    {
                        tracer.NewSpan(string.Concat(ServerType, ",RTMP连接", result, "，推流地址:", RtmpLocation));
                    }
                }
                catch (Exception ex)
                {
                    tracer.NewError(ex.Message, ex);
                }
                if (rtmpHandle == IntPtr.Zero)
                {
                    return;
                }
            }
            if (rtp.FrameType == RTPPacketExtend.FRAME_AUDIO)
            {
                LastAudioRTPPacket = rtp;
                RtmpSendByAacEncode(rtp.Frame);
                if (tickInterval == 0)
                {
                    tickInterval = 40;
                }
            }
            else
            {
                calcTickInterval(rtp);
                sendFrame(rtp.Frame);
            }
        }

        private void CleanBuffer()
        {
            if (bufferDataLength != 0)
            {
                bufferDataLength = 0;
            }
        }

        private void Record(byte[] data, bool audio = false)
        {
            _VideoRecoderService.Record(SimNo, ChannelId, data, audio);
        }

        public void Stop()
        {
            continueAnalyze = false;
            try
            {
                stopWriteMp4File = true;
                if (mp4FileWriteThread != null)
                {
                    mp4FileWriteThread.Join(1000);
                    tracer.NewSpan(RtmpLocation + "Mp4写入线程正常关闭");
                }
            }
            catch (Exception ex7)
            {
                tracer.NewError(ex7.Message, ex7);
            }
            try
            {
                if (processRealDataThread != null)
                {
                    processRealDataThread.Join(60000);
                }
                tracer.NewSpan(string.Concat(ServerType, ",", RtmpLocation, "RTP分析线程正常关闭"));
                if (waveFile != null)
                {
                    waveFile.Close();
                }
            }
            catch (Exception ex6)
            {
                tracer.NewError(ex6.Message, ex6);
            }
            try
            {
                if (aacFrame != IntPtr.Zero)
                {
                    tracer.NewSpan(string.Concat(ServerType, ",", RtmpLocation, "开始释放AAC Frame"));
                    Marshal.FreeHGlobal(aacFrame);
                    aacFrame = IntPtr.Zero;
                    tracer.NewSpan(string.Concat(ServerType, ",", RtmpLocation, "释放AAC Frame"));
                }
                outPCM = null;
                if (outPCMFrame != IntPtr.Zero)
                {
                    tracer.NewSpan(string.Concat(ServerType, ",", RtmpLocation, "开始释放PCM Frame"));
                    Marshal.FreeHGlobal(outPCMFrame);
                    outPCMFrame = IntPtr.Zero;
                    tracer.NewSpan(string.Concat(ServerType, ",", RtmpLocation, "释放PCM Frame"));
                }
                outputAacBuffer = null;
            }
            catch (Exception ex5)
            {
                tracer.NewError(ex5.Message, ex5);
            }
            try
            {
                if (aacEncoder != IntPtr.Zero)
                {
                    tracer.NewSpan(string.Concat(ServerType, ",", RtmpLocation, "开始释放AAC 编码器"));
                    RTMPWrapper.CloseAacEncoder(aacEncoder);
                    aacEncoder = IntPtr.Zero;
                    tracer.NewSpan(string.Concat(ServerType, ",", RtmpLocation, "释放AAC编码器"));
                }
            }
            catch (Exception ex4)
            {
                tracer.NewError(ex4.Message, ex4);
            }
            try
            {
                if (mNativeAmrDecoder != IntPtr.Zero)
                {
                    Decoder.Decoder_Interface_exit(mNativeAmrDecoder);
                    mNativeAmrDecoder = IntPtr.Zero;
                    tracer.NewSpan(string.Concat(ServerType, ",", RtmpLocation, "释放AMR解码器"));
                }
            }
            catch (Exception ex3)
            {
                tracer.NewError(ex3.Message, ex3);
            }
            try
            {
                if (rtmpHandle != IntPtr.Zero)
                {
                    tracer.NewSpan(string.Concat(ServerType, ",", RtmpLocation, "开始关闭RTMP连接"));
                    RTMPWrapper.RTMP264_Close(rtmpHandle);
                    rtmpHandle = IntPtr.Zero;
                    tracer.NewSpan(string.Concat(ServerType, ",", RtmpLocation, "关闭RTMP连接"));
                }
            }
            catch (Exception ex2)
            {
                tracer.NewError(ex2.Message, ex2);
            }
            try
            {
                _VideoRecoderService.EndRecord(SimNo, ChannelId);
            }
            catch (Exception ex)
            {
                tracer.NewError(ex.Message, ex);
            }
        }

        private bool AutoReconnect()
        {
            if (rtmpHandle == IntPtr.Zero || RTMPWrapper.RTMP264_IsConnected(rtmpHandle) == 0)
            {
                if (rtmpHandle != IntPtr.Zero)
                {
                    RTMPWrapper.RTMP264_Close(rtmpHandle);
                }
                rtmpHandle = RTMPWrapper.RTMP264_Create(RtmpLocation);
                string result = ((rtmpHandle != IntPtr.Zero) ? "成功" : "失败");
                aacSpecSent = false;
            }
            return rtmpHandle != IntPtr.Zero && RTMPWrapper.RTMP264_IsConnected(rtmpHandle) == 1;
        }

        private int H264FrameStartPos(byte[] bytes, int start, int totalLen)
        {
            int i = start;
            int remain = totalLen - start;
            int pos = -1;
            while (i < totalLen && remain > 3)
            {
                if (IsH264FrameStart(packetBuffer, i++, totalLen))
                {
                    pos = i - 1;
                    break;
                }
                remain = totalLen - i;
            }
            return pos;
        }

        private bool IsH264FrameStart(byte[] bytes, int start, int totalLen)
        {
            if (totalLen - start < 4)
            {
                return false;
            }
            return bytes[start++] == 0 && bytes[start++] == 0 && bytes[start++] == 0 && bytes[start++] == 1;
        }

        private void sendFrame(byte[] frame)
        {
            if (frame.Length < 5)
            {
                return;
            }
            Record(frame);
            int naluType = frame[4] & 0x1F;
            int num;
            switch (naluType)
            {
                case 7:
                    spsFrame = frame;
                    WriteMp4(frame);
                    return;
                case 8:
                    ppsFrame = frame;
                    WriteMp4(frame);
                    return;
                case 5:
                    if (spsFrame != null && ppsFrame != null)
                    {
                        IntPtr sps = RTMPWrapper.BytesToIntPtr(spsFrame, 4);
                        IntPtr pps = RTMPWrapper.BytesToIntPtr(ppsFrame, 4);
                        int result3 = RTMPWrapper.SendVideoSpsPps(rtmpHandle, pps, ppsFrame.Length - 4, sps, spsFrame.Length - 4);
                        Marshal.FreeHGlobal(sps);
                        Marshal.FreeHGlobal(pps);
                        if (result3 == 1)
                        {
                            spsFrameSend = true;
                        }
                    }
                    if (spsFrameSend)
                    {
                        WriteMp4(frame);
                        IntPtr frameHandle2 = RTMPWrapper.BytesToIntPtr(frame, 4);
                        tick += tickInterval;
                        PushTime = DateTime.Now;
                        int result2 = RTMPWrapper.SendH264Packet(rtmpHandle, frameHandle2, frame.Length - 4, 1, tick);
                        Marshal.FreeHGlobal(frameHandle2);
                        if (result2 != 1)
                        {
                            tracer.NewSpan(RtmpLocation + "I帧发送失败");
                        }
                    }
                    else
                    {
                        tracer.NewSpan(RtmpLocation + "sps帧发送失败造成I帧没有发送");
                    }
                    return;
                case 1:
                    num = (spsFrameSend ? 1 : 0);
                    break;
                default:
                    num = 0;
                    break;
            }
            if (num != 0)
            {
                if (spsFrameSend)
                {
                    WriteMp4(frame);
                }
                IntPtr frameHandle = RTMPWrapper.BytesToIntPtr(frame, 4);
                tick += tickInterval;
                PushTime = DateTime.Now;
                int result = RTMPWrapper.SendH264Packet(rtmpHandle, frameHandle, frame.Length - 4, 0, tick);
                if (result != 1)
                {
                    tracer.NewSpan(RtmpLocation + "P帧发送失败");
                }
                Marshal.FreeHGlobal(frameHandle);
                if (tickInterval <= 0)
                {
                    tickInterval = 40;
                }
            }
            else if (naluType != 6 && naluType != 1)
            {
                tracer.NewSpan(RtmpLocation + "未知的nalu类型:" + naluType + ",帧长度:" + frame.Length);
            }
        }

        public static string GetTimeStamp()
        {
            return Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds).ToString();
        }

        private void RtmpSendByAacEncode(byte[] audioData)
        {
            if (GlobalConfig.WriteTalkLog)
            {
                tracer.NewSpan(ParseUtil.ToHexString(audioData));
            }
            AudioDecoder = LastAudioRTPPacket.AudioDecoder;
            if (AudioDecoder == 0)
            {
                return;
            }
            if (AudioDecoder == AudioCoder.AAC)
            {
                SendAACPacket(audioData, audioData.Length);
                return;
            }
            if (AudioDecoder == AudioCoder.AMR_NB)
            {
                SendAMRPacket(audioData, audioData.Length);
                return;
            }
            if (AudioDecoder == AudioCoder.G711_A && audioData.Length == 800)
            {
                for (int i = 0; i < 5; i++)
                {
                    byte[] d = new byte[160];
                    Buffer.BlockCopy(audioData, i * 160, d, 0, d.Length);
                    RtmpSendByAacEncode(d);
                }
                return;
            }
            if (outPCM == null)
            {
                outPCM = new byte[MAX_OUT_BUFFER_LEN];
                outPCMFrame = RTMPWrapper.BytesToIntPtr(outPCM, 0, outPCM.Length);
            }
            if (audioData.Length == 80 || audioData.Length == 100 || audioData.Length == 120 || audioData.Length == 200 || audioData.Length == 320 || audioData.Length == 160 || audioData.Length == 512)
            {
                byte[] d2 = new byte[audioData.Length + 4];
                d2[0] = 0;
                d2[1] = 1;
                d2[2] = (byte)(audioData.Length / 2);
                d2[3] = 0;
                Buffer.BlockCopy(audioData, 0, d2, 4, audioData.Length);
                audioData = d2;
            }
            IntPtr inFrame = RTMPWrapper.BytesToIntPtr(audioData, 0, audioData.Length);
            short dataLen = 0;
            uint ret = (uint)RTMPWrapper.DecodAudioFrame(AudioDecoder, inFrame, outPCMFrame, ref dataLen);
            if (ret != 0)
            {
                string descr = string.Concat(ret);
                if (ret == HI_ERR_VOICE_INVALID_DEVICE)
                {
                    descr = "invalid encoder device handle";
                }
                else if (ret == HI_ERR_VOICE_INVALID_INBUF)
                {
                    descr = "invalid input speech data addr";
                }
                else if (ret == HI_ERR_VOICE_INVALID_OUTBUF)
                {
                    descr = "invalid output addr";
                }
                else if (ret == HI_ERR_VOICE_DEC_FRAMESIZE)
                {
                    descr = "invalid decoder FrameSize";
                }
                else if (ret == HI_ERR_VOICE_DEC_FRAMETYPE)
                {
                    descr = "invalid frame of compress speech data";
                }
                tracer.NewSpan(RtmpLocation + "音频解码失败,编码:" + LastAudioRTPPacket.AudioDecoder + ",错误码:" + descr);
            }
            if (dataLen > 0)
            {
                byte[] outPCMData = new byte[dataLen];
                Marshal.Copy(outPCMFrame, outPCMData, 0, dataLen);
                saveWavFile(outPCMData);
                RtmpSendByAacEncode(outPCMData, dataLen);
            }
            Marshal.FreeHGlobal(inFrame);
        }

        private void saveWavFile(byte[] pcmData)
        {
            if (GlobalConfig.SaveTalkAudioToWav)
            {
                if (waveFile == null)
                {
                    WaveFormat WaveFormat = new WaveFormat(8000, 16, 1);
                    string fn = "terminal_" + SimNo + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".wav";
                    waveFile = new WaveFileWriter(fn, WaveFormat);
                }
                waveFile.Write(pcmData, 0, pcmData.Length);
                waveFile.Flush();
            }
        }

        private void SendAMRPacket(byte[] outAMRData, int aacDataLength)
        {
            if (mNativeAmrDecoder == IntPtr.Zero)
            {
                mNativeAmrDecoder = Decoder.Decoder_Interface_init();
            }
            if (GlobalConfig.SaveTalkAudioToWav)
            {
                tracer.NewSpan("音频包长度:" + outAMRData.Length + ",RTP数据体长度:" + aacDataLength + ",报文:" + ParseUtil.ToHexString(outAMRData));
            }
            int remain = 0;
            int index = 0;
            while (index < outAMRData.Length)
            {
                byte[] amrData = new byte[32];
                Buffer.BlockCopy(outAMRData, index, amrData, 0, 32);
                index += 32;
                short[] outbuffer = new short[160];
                Decoder.Decoder_Interface_Decode(mNativeAmrDecoder, amrData, outbuffer, 0);
                byte[] littleendian = new byte[320];
                int j = 0;
                for (int i = 0; i < 160; i++)
                {
                    littleendian[j] = (byte)((uint)outbuffer[i] & 0xFFu);
                    littleendian[j + 1] = (byte)((uint)(outbuffer[i] >> 8) & 0xFFu);
                    j += 2;
                }
                saveWavFile(littleendian);
                RtmpSendByAacEncode(littleendian, littleendian.Length);
            }
        }

        private void SendAACPacket(byte[] outAACData, int aacDataLength)
        {
            if (aacEncoder == IntPtr.Zero)
            {
                aacEncoder = RTMPWrapper.InitAACEncoder(8000, 1, 16, ref inputSamples, ref maxOutputBytes);
                tracer.NewSpan("创建AAc编码器，输入样本数:" + inputSamples + ",输出缓冲区长度:" + maxOutputBytes);
            }
            if (!aacSpecSent && aacEncoder != IntPtr.Zero)
            {
                int result = RTMPWrapper.SendAACSpecPacket(aacEncoder, rtmpHandle);
                if (result != 1)
                {
                    Console.WriteLine("AAC帧解码信息数据发送" + ((result == 1) ? "成功" : "失败"));
                }
                if (result == 1)
                {
                    aacSpecSent = true;
                }
            }
            IntPtr rtmpAacFrame = RTMPWrapper.BytesToIntPtr(outAACData, 7, outAACData.Length - 7);
            WriteMp4(outAACData, audio: true);
            Record(outAACData, audio: true);
            if (audioTick == tick)
            {
                tick += tickInterval;
            }
            PushTime = DateTime.Now;
            int res = RTMPWrapper.SendAACPacket(rtmpHandle, rtmpAacFrame, outAACData.Length - 7, tick);
            audioTick = tick;
            if (res != 1)
            {
                tracer.NewSpan("AAC帧发送失败");
            }
            Marshal.FreeHGlobal(rtmpAacFrame);
        }

        private void RtmpSendByAacEncode(byte[] pcmData, int pcmDataLength)
        {
            if (aacEncoder == IntPtr.Zero)
            {
                _ = aacFrame;
                if (true)
                {
                    Marshal.FreeHGlobal(aacFrame);
                    aacFrame = IntPtr.Zero;
                }
                aacEncoder = RTMPWrapper.InitAACEncoder(8000, 1, 16, ref this.inputSamples, ref maxOutputBytes);
                if (aacEncoder == IntPtr.Zero)
                {
                    tracer.NewSpan(RtmpLocation + "初始化AAC编码器失败");
                    return;
                }
                tracer.NewSpan(RtmpLocation + ",创建AAc编码器，输入样本数:" + this.inputSamples + ",输出缓冲区长度:" + maxOutputBytes);
                outputAacBuffer = new byte[maxOutputBytes];
                aacFrame = RTMPWrapper.BytesToIntPtr(outputAacBuffer, 0, outputAacBuffer.Length);
                return;
            }
            if (!aacSpecSent && aacEncoder != IntPtr.Zero)
            {
                int result = RTMPWrapper.SendAACSpecPacket(aacEncoder, rtmpHandle);
                Console.WriteLine("AAC帧解码信息数据发送" + ((result == 1) ? "成功" : "失败"));
                if (result == 1)
                {
                    aacSpecSent = true;
                }
            }
            if (pcmBufferOffset + pcmDataLength > pcmBuffer.Length)
            {
                tracer.NewSpan("pcmbuffer溢出，直接清空缓冲区");
                pcmBufferOffset = 0;
                return;
            }
            Array.Copy(pcmData, 0, pcmBuffer, pcmBufferOffset, pcmDataLength);
            pcmBufferOffset += pcmDataLength;
            int pcmFrameLen = this.inputSamples * 16 / 8;
            if (pcmBufferOffset < pcmFrameLen && lastAudioFrameTimestamp == 0)
            {
                audioTick += 40;
            }
            if (pcmBufferOffset < pcmFrameLen || !(aacEncoder != IntPtr.Zero))
            {
                return;
            }
            IntPtr pcmFrame = RTMPWrapper.BytesToIntPtr(pcmBuffer, 0, pcmFrameLen);
            int inputSamples = pcmFrameLen / 2;
            int nRet = RTMPWrapper.AacEncode(aacEncoder, pcmFrame, inputSamples, aacFrame, maxOutputBytes);
            int times = 0;
            while (nRet == 0 && times++ < 10)
            {
                if (times > 3)
                {
                    tracer.NewSpan("AAC编码缓冲区满，等待编码" + times);
                }
                nRet = RTMPWrapper.AacEncode(aacEncoder, pcmFrame, inputSamples, aacFrame, maxOutputBytes);
            }
            if (nRet > 0)
            {
                byte[] outAccData = new byte[nRet];
                Marshal.Copy(aacFrame, outAccData, 0, nRet);
                IntPtr rtmpAacFrame = RTMPWrapper.BytesToIntPtr(outAccData, 7, outAccData.Length - 7);
                WriteMp4(outAccData, audio: true);
                Record(outAccData, audio: true);
                if (lastAudioFrameTimestamp != 0)
                {
                    audioFrameInterval = LastAudioRTPPacket.Timestamp - lastAudioFrameTimestamp;
                    audioFrameInterval = ((audioFrameInterval > 1000 || audioFrameInterval < 0) ? 120 : audioFrameInterval);
                    audioTick += (int)audioFrameInterval;
                }
                lastAudioFrameTimestamp = LastAudioRTPPacket.Timestamp;
                PushTime = DateTime.Now;
                int res = RTMPWrapper.SendAACPacket(rtmpHandle, rtmpAacFrame, outAccData.Length - 7, audioTick);
                if (res != 1)
                {
                    tracer.NewSpan(RtmpLocation + "AAC帧发送失败");
                }
                Marshal.FreeHGlobal(rtmpAacFrame);
            }
            else
            {
                tracer.NewSpan(RtmpLocation + "AAC编码失败");
            }
            Marshal.FreeHGlobal(pcmFrame);
            pcmBufferOffset -= pcmFrameLen;
            if (pcmBufferOffset > 0)
            {
                Array.Copy(pcmBuffer, pcmFrameLen, pcmBuffer, 0, pcmBufferOffset);
            }
        }

        private void saveAacStreamToFile(byte[] data, int len)
        {
            try
            {
                if (audioAacFileStream == null)
                {
                    string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\myaudio" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".aac";
                    audioAacFileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write);
                }
                audioAacFileStream.Write(data, 0, len);
            }
            catch (Exception ex)
            {
                tracer.NewError(ex.Message, ex);
            }
            finally
            {
            }
        }

        private string getFrameTypeDescr(byte[] frame)
        {
            int naluType = frame[0] & 0x1F;
            string descr = "未知帧" + naluType;
            switch (naluType)
            {
                case 7:
                    descr = "SPS帧";
                    break;
                case 8:
                    descr = "PPS帧";
                    break;
                case 5:
                    descr = "I帧";
                    break;
                case 1:
                    descr = "P帧";
                    break;
                case 6:
                    descr = "SEI帧";
                    break;
            }
            return descr;
        }

        private bool CreateMp4File(AVFrame rtp)
        {
            int width = 320;
            int height = 240;
            int videoFrameRate = 25;
            int videoTimeScale = 90000;
            int audioSampleRate = 8000;
            int inputSample = 1024;
            Vehicle vd = _IVehicleService.getVehicleBySimNo(rtp.SimNo);
            string fileName = vd.SimNo + "_" + rtp.ChannelId + "_" + DateTime.Now.ToString("yyMMddHHmmss") + ".mp4";
            string subDir = DateTime.Now.ToString("yyyyMMdd");
            string mp4Dir = GlobalConfig.VideoServerConfig.FtpPath + "\\" + subDir;
            if (!Directory.Exists(mp4Dir))
            {
                Directory.CreateDirectory(mp4Dir);
            }
            string fullFileName = mp4Dir + "\\" + fileName;
            mp4FileHandle = RTMPWrapper.Init_Mp4Encoder(fullFileName, width, height, videoFrameRate, videoTimeScale, audioSampleRate, inputSample);
            bool res = mp4FileHandle != IntPtr.Zero;
            if (!res)
            {
                tracer.NewSpan(RtmpLocation + "创建mp4录制文件失败,文件名:" + fullFileName);
            }
            else
            {
                tracer.NewSpan(RtmpLocation + "创建mp4录制文件成功,文件名:" + fullFileName);
                try
                {
                    videoFileItem = new VideoFileItem();
                    videoFileItem.StartDate = DateTime.Now;
                    videoFileItem.EndDate = DateTime.Now;
                    videoFileItem.VehicleId = vd.ID;
                    videoFileItem.PlateNo = vd.PlateNo;
                    videoFileItem.SimNo = vd.SimNo;
                    videoFileItem.FileSource = VideoFileItemStatus.SERVER_RECORDER.ToString();
                    videoFileItem.FilePath = subDir + "/" + fileName;
                    videoFileItem.ChannelId = (byte)rtp.ChannelId;
                    videoFileItem.UploadDate = DateTime.Now;
                    videoFileItem.Latitude1 = 39.914936;
                    videoFileItem.Longitude1 = 116.403696;
                    videoFileItem.Update();
                }
                catch (Exception ex)
                {
                    tracer.NewError("mp4资源文件记录入库失败:" + ex.Message, ex);
                }
            }
            return res;
        }

        private void mp4FileWriteThreadFunc()
        {
            try
            {
                if (LatestRTPPacket != null && !CreateMp4File(LatestRTPPacket))
                {
                    return;
                }
            }
            catch (Exception ex3)
            {
                tracer.NewError(ex3.Message + "," + RtmpLocation + "mp4创建文件时发生错误，终止运行", ex3);
                return;
            }
            try
            {
                while (!stopWriteMp4File && mp4FileHandle != IntPtr.Zero && GlobalConfig.RecordVideo)
                {
                    byte[] rtp = null;
                    while (mp4FrameQueue.TryDequeue(out rtp) && !stopWriteMp4File)
                    {
                        try
                        {
                            IntPtr ptr = RTMPWrapper.BytesToIntPtr(rtp);
                            if (rtp[0] == 0 && rtp[1] == 0 && rtp[2] == 0 && rtp[3] == 1)
                            {
                                RTMPWrapper.Mp4V_Encode(mp4FileHandle, ptr, rtp.Length);
                            }
                            else
                            {
                                RTMPWrapper.Mp4A_Encode(mp4FileHandle, ptr, rtp.Length);
                            }
                            Marshal.FreeHGlobal(ptr);
                        }
                        catch (Exception ex5)
                        {
                            tracer.NewError(ex5.Message, ex5);
                        }
                    }
                    Thread.Sleep(10);
                }
            }
            catch (Exception ex4)
            {
                tracer.NewError(RtmpLocation + "mp4写线程发生错误，终止运行" + "," + ex4.Message, ex4);
            }
            try
            {
                CloseMp4Hanle();
                videoFileItem.EndDate = DateTime.Now;
                videoFileItem.Status = (int)VideoFileItemStatus.UPLOAD_COMPLTETED;
                videoFileItem.Latitude2 = 39.914936;
                videoFileItem.Longitude2 = 116.403696;
                try
                {
                    string fullFileName = GlobalConfig.VideoServerConfig.FtpPath + "\\" + videoFileItem.FilePath;
                    if (File.Exists(fullFileName))
                    {
                        FileInfo f = new FileInfo(fullFileName);
                        videoFileItem.FileLength = (int)f.Length;
                    }
                }
                catch (Exception ex2)
                {
                    tracer.NewError("计算mp4文件大小发生错误:" + ex2.Message, ex2);
                    return;
                }
                videoFileItem.Update();
                mp4FileWriteThread = null;
                mp4FileHandle = IntPtr.Zero;
                VideoMp4KeyFrame v = new VideoMp4KeyFrame();
                v.Mp4FilePath = videoFileItem.FilePath;
                v.Update();
            }
            catch (Exception ex)
            {
                tracer.NewError(RtmpLocation + "mp4结束写入时发生错误，终止运行" + "," + ex.Message, ex);
            }
        }

        private void WriteMp4(byte[] frame, bool audio = false)
        {
            if (GlobalConfig.RecordVideo)
            {
                int start = (audio ? 7 : 0);
                int len = frame.Length - start;
                byte[] t = new byte[len];
                Buffer.BlockCopy(frame, start, t, 0, len);
                mp4FrameQueue.Enqueue(t);
            }
        }

        public void CloseMp4Hanle()
        {
            try
            {
                RTMPWrapper.CloseMp4_Encoder(mp4FileHandle);
                mp4FileHandle = IntPtr.Zero;
                tracer.NewSpan(RtmpLocation + " mp4文件写入结束");
            }
            catch (Exception ex)
            {
                tracer.NewError(ex.Message, ex);
            }
        }
    }
}
