using System.Collections.Concurrent;
using VehicleVedioManage.Data.Entity;
using VehicleVideoManage.Video.RTMP;
using VehicleVideoManage.Video.RTP;
using VehicleVideoManage.Video.Sockets;
using VehicleVideoManage.Video.ViewModel;

namespace VehicleVideoManage.Video
{
    public class GlobalConfig
    {
        public static bool RecordVideo = false;

        public static string RtmpLocation = "rtmp://localhost:19350/live/";

        public static bool DisplayRtpLog = false;

        public static bool BroadcastAudioWithoutHISI = false;

        public static bool PreviewVideo = false;

        public static string ConnectIdForDisplay = null;

        public static string ConnectIdForLog = null;

        public static bool ShowTalkLog = false;

        public static bool ShowBroadcastLog = false;

        public static bool SaveTalkAudioToWav = false;

        public static bool RTMPEnabled = false;

        public static bool DisplayHttpConnection = false;

        public static string SimNoFilterForDisplay = null;

        public static string SimNoOfPlayer = null;

        public static int ChannelOfPlayer = 0;

        public static bool TransferTo809AfterAnanylze = false;

        public static bool SyncTransfer = true;

        public static VideoServerConfig VideoServerConfig;

        public static bool CreateMp4KeyFrame = true;

        public static bool ForceInterval = false;

        public static bool RTPAnalyze = true;

        public static bool WriteTalkLog = false;

        public static bool ForceCloseHttpWhenTerminalDisconnect = false;

        public static bool ShowHttpFailLog = true;

        public static string BroadcastState = null;

        public static bool AutoUploadCatalog = false;

        public static bool ShowCatalogState = false;

        public static int SimNoLength = 11;

        public static ConcurrentQueue<RTPPacket> RTPTalkQueue = new ConcurrentQueue<RTPPacket>();

        public static ConcurrentQueue<RTPPacket> RTPPacketQueue = new ConcurrentQueue<RTPPacket>();

        public static ConcurrentQueue<InviteLog> InviteLogQueue = new ConcurrentQueue<InviteLog>();

        public static ConcurrentQueue<AVFrame> AVFrameQueue = new ConcurrentQueue<AVFrame>();

        public static ConcurrentDictionary<string, AsyncSocketConnection> VideoConnections = new ConcurrentDictionary<string, AsyncSocketConnection>();

        public static ConcurrentDictionary<string, RTPSender> RtpSenderMap = new ConcurrentDictionary<string, RTPSender>();
    }
}
