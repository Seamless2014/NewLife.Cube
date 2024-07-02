using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleVideoManage.Video.RTMP
{
    /// <summary>
    /// 指定音频配置
    /// </summary>
    public class AudioSpecificConfig
    {
        /// <summary>
        /// 音频类型
        /// </summary>
        public byte nAudioObjectType
        {
            get;
            set;
        }
        /// <summary>
        /// 采样率索引
        /// </summary>
        public byte nSampleFrequencyIndex
        {
            get;
            set;
        }
        /// <summary>
        /// 通道
        /// </summary>
        public byte nChannels
        {
            get;
            set;
        }
        /// <summary>
        /// 帧长度标识
        /// </summary>
        public byte nFrameLengthFlag
        {
            get;
            set;
        }
        /// <summary>
        /// 依赖核心编码器
        /// </summary>
        public byte nDependOnCoreCoder
        {
            get;
            set;
        }
        /// <summary>
        /// 扩展标志
        /// </summary>
        public byte nExtensionFlag
        {
            get;
            set;
        }
    }
}
