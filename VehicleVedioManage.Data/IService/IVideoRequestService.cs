using VehicleVedioManage.Data.Entity;

namespace VehicleVedioManage.Data.IService
{
    public interface IVideoRequestService
    {
        void clearRequest(string sessionId);

        void Init();

        void removeVideoSession(string sessionId);

        TerminalCommand sendStopVideoPlayRequestCommand(string simNo, int channelId);

        void updateOnlineTime(string sessionId);

        void updateVideoRequest(VideoRequest v);
    }
}
