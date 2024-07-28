using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleVideoManage.Video.RTP;

namespace VehicleVideoManage.Video.Audio
{
    /// <summary>
    /// 音频编解码
    /// </summary>
    public class AudioCoder
    {
        public static int G711_A = 1;

        public static int G711_U = 2;

        public static int ADPCM_DVI4 = 3;

        public static int G726_16KBPS = 4;

        public static int G726_24KBPS = 5;

        public static int G726_32KBPS = 6;

        public static int G726_40KBPS = 7;

        public static int ADPCM_IMA = 35;

        public static int AAC = 19;

        public static int NOT_SUPPORT = 255;

        public static int AMR_NB = 40;

        public static int GetRTPAudioPayLoadType(int audioCoder)
        {
            if (audioCoder == ADPCM_IMA || audioCoder == ADPCM_DVI4)
                return 26;
            if (audioCoder == G711_A)
                return 6;
            if (audioCoder == G711_U)
                return 7;
            if (audioCoder == G726_32KBPS)
                return 8;
            if (audioCoder == G726_40KBPS)
                return 8;
            if (audioCoder == G726_24KBPS)
                return 8;
            if (audioCoder == AAC || audioCoder == AMR_NB)
                return audioCoder;
            return 0;
        }

        public static int GetAudioCoder(RTPPacket r)
        {
            if (r == null || r.FrameType != RTPPacketExtend.FRAME_AUDIO)
                return 0;
            if (r.PayloadType == RTPPacketExtend.AUDIO_CODEC_ADPCMA)
                return ADPCM_DVI4;
            if (r.PayloadType == RTPPacketExtend.AUDIO_CODEC_G726)
            {
                int dataLength = r.DataLength;
                if (dataLength == 164 || dataLength == 160 || dataLength == 324 || dataLength == 320)
                    return G726_32KBPS;
                if (dataLength == 204 || dataLength == 104)
                    return G726_40KBPS;
                if (dataLength == 100 || dataLength == 200)
                    return G726_40KBPS;
                if (dataLength == 120 || dataLength == 124)
                    return G726_24KBPS;
            }
            else
            {
                if (r.PayloadType == RTPPacketExtend.AUDIO_CODEC_G711A)
                    return G711_A;
                if (r.PayloadType == RTPPacketExtend.AUDIO_CODEC_G711U)
                    return G711_U;
                if (r.PayloadType == RTPPacketExtend.AUDIO_CODEC_AAC)
                    return AAC;
                if (r.PayloadType == RTPPacketExtend.AUDIO_CODEC_AMR_NB)
                    return AMR_NB;
            }
            return NOT_SUPPORT;
        }

        public static string GetAudioCoderDescr(int audioCoder)
        {
            if (audioCoder == ADPCM_IMA)
                return "ADPCM_IMA";
            if (audioCoder == ADPCM_DVI4)
                return "ADPCM_DVI4";
            if (audioCoder == G711_A)
                return "G711_A";
            if (audioCoder == G711_U)
                return "G711_U";
            if (audioCoder == G726_32KBPS)
                return "G726_32KBPS";
            if (audioCoder == G726_40KBPS)
                return "G726_40KBPS";
            if (audioCoder == G726_24KBPS)
                return "G726_24KBPS";
            if (audioCoder == AAC)
                return "AAC";
            if (audioCoder == AMR_NB)
                return "AMR_NB";
            if (audioCoder == NOT_SUPPORT)
                return "无法识别的编码:" + audioCoder;
            return "";
        }
    }
}
