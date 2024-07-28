using System.Net;
using VehicleVideoManage.Video.RTP;

namespace VehicleVideoManage.Video.Events
{
    /// <summary>
    /// 接收事件
    /// </summary>
    public class ReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// 远程host
        /// </summary>
        public readonly IPEndPoint RemoteHost;
        /// <summary>
        /// RTPPacket 数据包
        /// </summary>
        public readonly RTPPacket Data;

        public ReceivedEventArgs(IPEndPoint Remote, RTPPacket ReceivedData)
        {
            Data = ReceivedData;
            RemoteHost = Remote;
        }
    }
}
