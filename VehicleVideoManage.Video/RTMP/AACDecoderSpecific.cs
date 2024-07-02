using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleVideoManage.Video.RTMP
{
    /// <summary>
    /// AAC指定解码
    /// </summary>
    public class AACDecoderSpecific
    {
        /// <summary>
        /// 音频格式类型
        /// </summary>
        public byte nAudioFortmatType
        {
            get;
            set;
        }
        /// <summary>
        /// 音频采样类型
        /// </summary>
        public byte nAudioSampleType
        {
            get;
            set;
        }
        /// <summary>
        /// 音频大小类型
        /// </summary>
        public byte nAudioSizeType
        {
            get;
            set;
        }
        /// <summary>
        /// 立体声
        /// </summary>
        public byte nAudioStereo
        {
            get;
            set;
        }
        /// <summary>
        /// acc包类型
        /// </summary>
        public byte nAccPacketType
        {
            get;
            set;
        }
    }
}
