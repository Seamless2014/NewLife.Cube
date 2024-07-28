using VehicleVideoManage.Video.ViewModel;

namespace VehicleVideoManage.Video.IService
{
	/// <summary>
	/// 实时视频请求服务
	/// </summary>
	public interface IVideoRealTimeRequestService
	{
		/// <summary>
		/// 更新视频请求
		/// </summary>
		/// <param name="vm"></param>
		void UpdateVideoRequest(VideoRequestMessage vm);
		/// <summary>
		/// 清除请求
		/// </summary>
		void ClearRequest();
		/// <summary>
		/// 开始
		/// </summary>
		void Start();
		/// <summary>
		/// 结束
		/// </summary>
		void Stop();
	}
}
