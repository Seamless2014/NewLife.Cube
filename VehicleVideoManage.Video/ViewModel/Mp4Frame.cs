using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleVideoManage.Video.ViewModel
{
    /// <summary>
    /// MP4帧数据
    /// </summary>
    public class Mp4Frame
    {
        public string Key
        {
            get;
            set;
        }

        public string SimNo
        {
            get;
            set;
        }

        public int ChannelId
        {
            get;
            set;
        }

        public bool Audio
        {
            get;
            set;
        }

        public byte[] Data
        {
            get;
            set;
        }

        public Mp4Frame(string simNo, int channelId, byte[] d, bool audio = false)
        {
            Key = simNo + "_" + channelId;
            SimNo = simNo;
            ChannelId = channelId;
            int start = (audio ? 7 : 0);
            int len = d.Length - start;
            Data = new byte[len];
            Buffer.BlockCopy(d, start, Data, 0, len);
            Audio = audio;
        }
    }
}
