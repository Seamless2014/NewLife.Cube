using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleVideoManage.Video.RTP;

namespace VehicleVideoManage.Video.RTMP
{
    /// <summary>
    /// AV帧
    /// </summary>
    public class AVFrame
    {
        /// <summary>
        /// sim卡号
        /// </summary>
        public string SimNo
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
        /// 帧类型
        /// </summary>
        public int FrameType
        {
            get;
            set;
        }
        /// <summary>
        /// 时间戳
        /// </summary>
        public ulong Timestamp
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
        /// 是否音频
        /// </summary>
        public bool Audio
        {
            get;
            set;
        }
        /// <summary>
        /// 帧数据
        /// </summary>
        public byte[] Frame
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <param name="data"></param>
        /// <param name="start"></param>
        /// <param name="len"></param>
        public void Add(RTPPacket r, byte[] data, int start, int len)
        {
        }
    }
}
