using System.Collections.Concurrent;
using System.Text;
using NewLife.Log;
using VehicleVedioManage.Data.Entity;
using VehicleVedioManage.Data.IService;

namespace VehicleVedioManage.Data.Service
{
    public class VideoRequestService : IVideoRequestService
    {
        private bool isContinue;

        private Thread checkThread;

        private ConcurrentDictionary<string, DateTime> onlineMap = new ConcurrentDictionary<string, DateTime>();

        private ConcurrentDictionary<string, VideoRequest> requestMap = new ConcurrentDictionary<string, VideoRequest>();

        private readonly ITracer tracer;
       
        public IVehicleService VehicleService
        {
            get;
            set;
        }
        public VideoRequestService(ITracer tracer)
        {
            this.tracer = tracer;
        }

        public void Init()
        {
            checkThread = new Thread(checkVideoSessionThreadFunc);
            checkThread.Start();
        }

        private void checkVideoSessionThreadFunc()
        {
            while (isContinue)
            {
                try
                {
                    checkVideoSession();
                }
                catch (Exception ex2)
                {
                    tracer.NewError(ex2.Message, ex2);
                }
                try
                {
                    Thread.Sleep(30000);
                }
                catch (Exception ex)
                {
                    tracer.NewError(ex.Message, ex);
                }
            }
        }

        private void checkVideoSession()
        {
            ICollection<string> keys = onlineMap.Keys;
            foreach (string sessionId in keys)
            {
                DateTime d = onlineMap[sessionId];
                if ((DateTime.Now - d).TotalSeconds > 90.0)
                {
                    onlineMap.TryRemove(sessionId, out d);
                    clearRequest(sessionId);
                }
            }
        }

        public void clearRequest(string sessionId)
        {
            ICollection<string> keys = requestMap.Keys;
            foreach (string key in keys)
            {
                VideoRequest v = requestMap[key];
                if (v != null && sessionId == v.SessionId)
                {
                    VideoRequest tv = null;
                    requestMap.TryRemove(key, out tv);
                    if (!isChannelOnRequest(v.SimNo, v.Channel))
                    {
                        sendStopVideoPlayRequestCommand(v.SimNo, v.Channel);
                    }
                }
            }
        }

        public void updateOnlineTime(string sessionId)
        {
            onlineMap[sessionId] = DateTime.Now;
        }

        public void removeVideoSession(string sessionId)
        {
            DateTime d = DateTime.Now;
            onlineMap.TryRemove(sessionId, out d);
        }

        public void updateVideoRequest(VideoRequest v)
        {
            string key = v.getRequestKey();
            if (requestMap.ContainsKey(key))
            {
                VideoRequest r = requestMap[key];
                r.StartTime = DateTime.Now;
            }
            else
            {
                requestMap[key] = v;
            }
            v.Update();
        }

        private bool isChannelOnRequest(string simNo, int channelId)
        {
            ICollection<string> keys = requestMap.Keys;
            foreach (string key in keys)
            {
                VideoRequest v = requestMap[key];
                if (v.SimNo == simNo && v.Channel == channelId)
                {
                    return true;
                }
            }
            return false;
        }

        public TerminalCommand sendStopVideoPlayRequestCommand(string simNo, int channelId)
        {
            Vehicle vd = VehicleService.getVehicleBySimNo(simNo);
            if (vd == null)
            {
                tracer.NewSpan(simNo + "找不到车辆信息");
                return null;
            }
            TerminalCommand tc = new TerminalCommand();
            tc.PlateNo = vd.PlateNo;
            tc.SimNo = vd.SimNo;
            tc.VehicleId = vd.ID;
            StringBuilder sb = new StringBuilder();
            tc.CmdType = 37122;
            byte controlCommand = 0;
            byte videoType = 0;
            byte streamType = 0;
            sb.Append(channelId).Append(';').Append(controlCommand)
                .Append(';')
                .Append(videoType)
                .Append(';')
                .Append(streamType);
            tc.CmdData = sb.ToString();
            tc.Update();
            return tc;
        }
    }
}
