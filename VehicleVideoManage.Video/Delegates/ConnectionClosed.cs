using VehicleVideoManage.Video.Sockets;

namespace VehicleVideoManage.Video.Delegates
{
    /// <summary>
	/// 连接关闭委托
	/// </summary>
	/// <param name="conn"></param>
	public delegate void ConnectionClosed(AsyncSocketConnection conn);
}
