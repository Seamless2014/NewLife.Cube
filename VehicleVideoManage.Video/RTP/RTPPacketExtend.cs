using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleVideoManage.Video.RTP
{
    public class RTPPacketExtend
    {
        /// <summary>
        /// 音频帧
        /// </summary>
        public static byte FRAME_AUDIO = 3;
        /// <summary>
        /// I帧
        /// </summary>
        public static byte FRAME_I = 0;
        /// <summary>
        /// P帧
        /// </summary>
        public static byte FRAME_P = 1;
        /// <summary>
        /// B帧
        /// </summary>
        public static byte FRAME_B = 2;
        /// <summary>
        /// 透明帧
        /// </summary>
        public static byte FRAME_TRANSPARENT = 4;
        /// <summary>
        /// 原子帧
        /// </summary>
        public static byte PACKET_ATOMIC = 0;
        /// <summary>
        /// 第一帧
        /// </summary>
        public static byte PACKET_FIRST = 1;
        /// <summary>
        /// 最后一帧
        /// </summary>
        public static byte PACKET_LAST = 2;
        /// <summary>
        /// 中间数据包
        /// </summary>
        public static byte PACKET_MIDDLE = 3;
        /// <summary>
        /// 音频编码 ADPCMA
        /// </summary>
        public static int AUDIO_CODEC_ADPCMA = 26;
        /// <summary>
        /// 音频编码G726
        /// </summary>
        public static int AUDIO_CODEC_G726 = 8;
        /// <summary>
        /// 音频编码G711A
        /// </summary>
        public static int AUDIO_CODEC_G711A = 6;
        /// <summary>
        /// 音频编码G711U
        /// </summary>
        public static int AUDIO_CODEC_G711U = 7;
        /// <summary>
        /// 音频编码AAC
        /// </summary>
        public static int AUDIO_CODEC_AAC = 19;
        /// <summary>
        /// 音频编码AMR_NB
        /// </summary>
        public static int AUDIO_CODEC_AMR_NB = 28;
    }
}
