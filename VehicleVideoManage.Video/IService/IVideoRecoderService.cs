namespace VehicleVideoManage.Video.IService
{
    /// <summary>
    /// 视频录像服务
    /// </summary>
	public interface IVideoRecoderService
	{
        /// <summary>
        /// 结束录像
        /// </summary>
        /// <param name="simNo"></param>
        /// <param name="channelId"></param>
		void EndRecord(string simNo, int channelId);
        /// <summary>
        /// 录像
        /// </summary>
        /// <param name="SimNo"></param>
        /// <param name="ChannelId"></param>
        /// <param name="data"></param>
        /// <param name="audio"></param>
		void Record(string SimNo, int ChannelId, byte[] data, bool audio = false);

		void Start();

		void Stop();
	}
}
