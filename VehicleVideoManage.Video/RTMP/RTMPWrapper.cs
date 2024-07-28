using System.Runtime.InteropServices;
using NewLife.Log;

namespace VehicleVideoManage.Video.RTMP
{
    public class RTMPWrapper
    {
        [DllImport("h264tortmp.dll")]
        public static extern int RtmpInitWinSocket();

        [DllImport("h264tortmp.dll")]
        public static extern int RtmpCleanupWinSockets();

        [DllImport("h264tortmp.dll")]
        public static extern IntPtr RTMP264_Create(string url);

        [DllImport("h264tortmp.dll")]
        public static extern IntPtr RTMP264_Close(IntPtr rtmpHandle);

        [DllImport("h264tortmp.dll")]
        public static extern IntPtr RTMP264_InitPull(string url);

        [DllImport("h264tortmp.dll")]
        public static extern int RTMP264_Read(IntPtr rtmpHandle, IntPtr frame, int naluSize);

        [DllImport("h264tortmp.dll")]
        public static extern int RTMP264_ReadPacket(IntPtr rtmpHandle, IntPtr frame, ref int packetType, int naluSize);

        [DllImport("h264tortmp.dll")]
        public static extern void Speex_Init();

        [DllImport("h264tortmp.dll")]
        public static extern IntPtr SpeexDecoder_Init();

        [DllImport("h264tortmp.dll")]
        public static extern void SpeexDecoder_Dispose(IntPtr handle);

        [DllImport("h264tortmp.dll")]
        public static extern void SpeexDecoder_Decode(IntPtr handle, int nbBytes, IntPtr inData, IntPtr output);

        [DllImport("h264tortmp.dll")]
        public static extern IntPtr InitSpeexResampler(uint channels, uint inRate, uint outRate, int quality, ref int err);

        [DllImport("h264tortmp.dll")]
        public static extern int SpeexResamplerProcessInt(IntPtr resampler, uint channelId, IntPtr inData, ref int inDataLen, IntPtr outData, ref int outDataLen);

        [DllImport("h264tortmp.dll")]
        public static extern void SpeexResamplerDestroy(IntPtr resampler);

        [DllImport("h264tortmp.dll")]
        public static extern int SendVideoSpsPps(IntPtr rtmpHandle, IntPtr pps, int pps_len, IntPtr sps, int sps_len);

        [DllImport("h264tortmp.dll")]
        public static extern int SendH264Packet(IntPtr m_pRtmp, IntPtr data, int size, int bIsKeyFrame, int nTimeStamp);

        [DllImport("h264tortmp.dll")]
        public static extern int GetSpsFrameRate(IntPtr buf, int nLen);

        [DllImport("h264tortmp.dll")]
        public static extern int DecodAudioFrame(int coder, IntPtr inFrame, IntPtr outFrame, ref short len);

        [DllImport("h264tortmp.dll")]
        public static extern int EncodeAudioFrame(int coder, IntPtr inFrame, IntPtr outFrame, short len, ref short outLen);

        [DllImport("h264tortmp.dll")]
        public static extern int InitAudioDecoder();

        [DllImport("h264tortmp.dll")]
        public static extern IntPtr InitAACEncoder(int nSampleRate, int nChannels, int nPCMBitSize, ref int nInputSamples, ref int nMaxOutputBytes);

        [DllImport("h264tortmp.dll")]
        public static extern int CloseAacEncoder(IntPtr aacEncoder);

        [DllImport("h264tortmp.dll")]
        public static extern int AacEncode(IntPtr aacEncoder, IntPtr pbPCMBuffer, int nInputSamples, IntPtr pbAACBuffer, int nMaxOutputBytes);

        [DllImport("h264tortmp.dll")]
        public static extern IntPtr InitAACDecoder(IntPtr frame, int frameSize, ref int nSampleRate, ref int nChannels);

        [DllImport("h264tortmp.dll")]
        public static extern void CloseAacDecoder(IntPtr aacDeccoder);

        [DllImport("h264tortmp.dll")]
        public static extern IntPtr AacDecode(IntPtr aacDeccoder, IntPtr frame, int frameSize, ref int nSample, ref int nSampleRate, ref int nChannels);

        [DllImport("h264tortmp.dll")]
        public static extern int SendAACPacket(IntPtr rtmpHandle, IntPtr data, int size, int nTimeStamp);

        [DllImport("h264tortmp.dll")]
        public static extern int SendAACSpecPacket(IntPtr aacEncoder, IntPtr rtmpHandle);

        [DllImport("h264tortmp.dll")]
        public static extern int RTMP264_IsConnected(IntPtr rtmpHandle);

        [DllImport("h264tortmp.dll")]
        public static extern int RTMP264_Connect(IntPtr rtmpHandle);

        [DllImport("h264tortmp.dll")]
        public static extern IntPtr Init_Mp4Encoder(string fileName, int width, int height, int videoFrameRate, int videoTimeScale, int audioSampleRate, int inputSample);

        [DllImport("h264tortmp.dll")]
        public static extern int Mp4V_Encode(IntPtr mp4Handle, IntPtr frame, int naluSize);

        [DllImport("h264tortmp.dll")]
        public static extern int Mp4A_Encode(IntPtr mp4Handle, IntPtr frame, int aacSize);

        [DllImport("h264tortmp.dll")]
        public static extern int CloseMp4_Encoder(IntPtr mp4Handle);

        [DllImport("h264tortmp.dll")]
        public static extern IntPtr Init_Mp4Decoder(string fileName, string keyFrameFileName);

        [DllImport("h264tortmp.dll")]
        public static extern IntPtr RTP_Init(string serverIp, int sendPort, int recvPort, int ssrc, int tcp);

        [DllImport("h264tortmp.dll")]
        public static extern int SendH264FrameByRTP(IntPtr rtpSender, IntPtr pFrameBuffer, int nFrameSize, int nPts, int frameType);

        [DllImport("h264tortmp.dll")]
        public static extern void RTP_Close(IntPtr rtpSender);

        public static void Init()
        {
            if (RtmpInitWinSocket() == 0)
            {
                Console.WriteLine("win32 scoket初始化失败");
            }
            InitAudioDecoder();
            Speex_Init();
        }

        public static IntPtr BytesToIntPtr(byte[] bytes, int start, int size)
        {
            IntPtr buffer = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.Copy(bytes, start, buffer, size);
                return buffer;
            }
            finally
            {
            }
        }

        public static IntPtr BytesToIntPtr(byte[] bytes, int start = 0)
        {
            int size = bytes.Length - start;
            IntPtr buffer = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.Copy(bytes, start, buffer, size);
                return buffer;
            }
            finally
            {
            }
        }
    }
}
