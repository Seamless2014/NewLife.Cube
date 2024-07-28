using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using VehicleVedioManage.Data.ViewModels;
using VehicleVedioManage.Utility.Enums;
using VehicleVideoManage.Video.Audio;
using VehicleVideoManage.Video.Codec;
using VehicleVideoManage.Video.RTMP;
using VehicleVideoManage.Video.RTP;
using VehicleVideoManage.Video.ViewModel;
using VehicleVideoManage.Video.Delegates;
using NewLife.Log;
using VehicleVideoManage.Video.Events;
using VehicleVideoManage.Video.Utility;

namespace VehicleVideoManage.Video.Sockets
{
    /// <summary>
    /// 异步socket连接
    /// </summary>
    public class AsyncSocketConnection : IConnection
    {
        /// <summary>
        /// 接收数量
        /// </summary>
        internal int recvedCount = 0;
        /// <summary>
        /// 连接关闭
        /// </summary>
        public ConnectionClosed onConnectionClosed;
        /// <summary>
        /// 当前传入消息的长度
        /// </summary>
        internal int lengthOfCurrentIncomingMessage;
        /// <summary>
        /// 异步socket接收事件参数
        /// </summary>
        internal SocketAsyncEventArgs recvEventArgs = new SocketAsyncEventArgs();
        /// <summary>
        /// 异步socket发送事件参数
        /// </summary>
        internal SocketAsyncEventArgs sendEventArgs = new SocketAsyncEventArgs();
        /// <summary>
        /// 最小数据包长度
        /// </summary>
        public static int MIN_PACKET_LENGTH = 0;
        /// <summary>
        /// 数据包缓冲区
        /// </summary>
        private byte[] packetBuffer = new byte[10240];
        /// <summary>
        /// 数据包缓冲区偏移量
        /// </summary>
        public int pPacketBufferOffset = 0;
        /// <summary>
        /// 帧缓冲区
        /// </summary>
        private byte[] frameBuffer;
        /// <summary>
        /// 帧缓冲区偏移量
        /// </summary>
        private int frameBufferOffset = 0;
        /// <summary>
        /// RTP分析
        /// </summary>
        private RTPAnalyzer rtpAnalyzer;
        /// <summary>
        /// RTP包
        /// </summary>
        private RTPPacket rtp;
        /// <summary>
        /// rtp首包
        /// </summary>
        private RTPPacket firstRtpPacket;
        /// <summary>
        /// 首个rtpI帧
        /// </summary>
        private RTPPacket firtIFrameRtpPacket;
        /// <summary>
        /// rtmp对讲
        /// </summary>
        private RtmpTalkback rtmpTalkback;
        /// <summary>
        /// rtp文件写入
        /// </summary>
        private StreamWriter rtpFileWriter;
        /// <summary>
        /// 连接锁
        /// </summary>
        private object connectionLock = new object();
        /// <summary>
        /// rtp发送
        /// </summary>
        private RTPSender rtpSender;

        private Stopwatch sw = new Stopwatch();
        /// <summary>
        /// 序号
        /// </summary>
        private int sn = 0;
        /// <summary>
        /// 音频解码
        /// </summary>
        private int AudioDecoder = 0;
        /// <summary>
        /// 状态
        /// </summary>
        public string Status
        {
            get;
            set;
        }
        /// <summary>
        /// 重连次数
        /// </summary>
        public int ReconnectTimes
        {
            get;
            set;
        }
        /// <summary>
        /// 服务类型
        /// </summary>
        public ServerType ServerType
        {
            get;
            set;
        }
        /// <summary>
        /// id
        /// </summary>
        public string ID
        {
            get;
            set;
        }
        /// <summary>
        /// 客户端ip
        /// </summary>
        public IPEndPoint ClientIP
        {
            get;
            set;
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate
        {
            get;
            set;
        }
        /// <summary>
        /// 在线时间
        /// </summary>
        public DateTime OnlineDate
        {
            get;
            set;
        }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string PlateNo
        {
            get;
            set;
        }
        /// <summary>
        /// 通道
        /// </summary>
        public int Channel
        {
            get;
            set;
        }
        /// <summary>
        /// sim卡号
        /// </summary>
        public string SimNo
        {
            get;
            set;
        }
        /// <summary>
        /// 数据使用情况
        /// </summary>
        public int DataUsage
        {
            get;
            set;
        }
        /// <summary>
        /// 最后使用情况
        /// </summary>
        public int LastUsage
        {
            get;
            set;
        }
        /// <summary>
        /// 计算流时间
        /// </summary>
        public DateTime CalcFlowTime
        {
            get;
            set;
        }
        /// <summary>
        /// 是否政府播放
        /// </summary>
        public bool GovUserPlaying
        {
            get;
            set;
        }

        public Int32 ConnectionBufferSize => throw new NotImplementedException();

        private readonly ITracer tracer;
        public AsyncSocketConnection(ITracer _tracer)
        {
            this.tracer = _tracer;
        }
        /// <summary>
        /// 设置rtp发送
        /// </summary>
        /// <param name="_sender"></param>
        public void SetRtpSender(RTPSender _sender)
        {
            rtpSender = _sender;
        }
        /// <summary>
        /// 获取RTP发送
        /// </summary>
        /// <returns></returns>
        public RTPSender GetRtpSender()
        {
            return rtpSender;
        }
        /// <summary>
        /// 解析整个数据包
        /// </summary>
        private void ParseWholePacket()
        {
            sn++;
            int totalLen = pPacketBufferOffset;
            int index = 0;
            bool isFirstRTP = firstRtpPacket == null;
            if (isFirstRTP)
            {
            }
            if (rtp == null && totalLen < 31)
            {
                return;
            }
            if (frameBuffer == null)
            {
                frameBuffer = new byte[351200];
            }
            while (index < totalLen && !IsClosing())
            {
                int start = RTPStartPos(packetBuffer, index, totalLen);
                if (rtp != null)
                {
                    int len = ((start < 0) ? totalLen : start) - index;
                    if (len > 0)
                    {
                        int rtpRemain = rtp.Remain();
                        int dataLength2 = rtp.addData(packetBuffer, index, len);
                        CopyToFrameBuffer(index, dataLength2);
                        if (rtp.IsCompleted())
                        {
                            processRTPPacket(rtp);
                            rtp = null;
                            index += rtpRemain;
                        }
                        else
                        {
                            index += len;
                        }
                    }
                }
                if (start < 0)
                {
                    int remainLen2 = totalLen - index;
                    if (remainLen2 > 1100)
                    {
                        tracer.NewSpan("没有包头的报文过长，无效报文");
                        pPacketBufferOffset = 0;
                    }
                    else if (index > 0 && remainLen2 > 0)
                    {
                        Buffer.BlockCopy(packetBuffer, index, packetBuffer, 0, remainLen2);
                    }
                    pPacketBufferOffset = remainLen2;
                    break;
                }
                if (start >= 0)
                {
                    if (rtp != null)
                    {
                        tracer.NewSpan("解析错误，收到不完整的RTP包" + rtp.ToString());
                    }
                    int remainLen = totalLen - start;
                    if (remainLen <= 30)
                    {
                        Buffer.BlockCopy(packetBuffer, start, packetBuffer, 0, remainLen);
                        pPacketBufferOffset = remainLen;
                        break;
                    }
                    int t = start;
                    if (packetBuffer[t++] != 48 || (packetBuffer[t++] != 49 && packetBuffer[t++] != 99 && packetBuffer[t++] != 100))
                    {
                        tracer.NewSpan("非法包头:" + ParseUtil.ToHexString(packetBuffer, start, remainLen));
                    }
                    rtp = new RTPPacket(packetBuffer, start, remainLen, SimNo);
                    if (rtp.PacketType == RTPPacketExtend.PACKET_FIRST && rtp.FrameType == RTPPacketExtend.FRAME_I)
                    {
                    }
                    if (rtp.PacketType == RTPPacketExtend.PACKET_LAST && rtp.FrameType == RTPPacketExtend.FRAME_I)
                    {
                    }
                    if (frameBufferOffset > 0 && (rtp.PacketType == RTPPacketExtend.PACKET_FIRST || rtp.PacketType == RTPPacketExtend.PACKET_ATOMIC))
                    {
                        tracer.NewSpan(SimNo + "发现没有结束的帧数据,直接清除" + rtp.ToString());
                        frameBufferOffset = 0;
                    }
                    start += rtp.HeaderLen();
                    index = start + rtp.DataLength;
                    remainLen = totalLen - index;
                    int dataLength = ((remainLen > 0) ? rtp.DataLength : (totalLen - start));
                    CopyToFrameBuffer(start, dataLength);
                    if (rtp.IsCompleted())
                    {
                        processRTPPacket(rtp);
                        rtp = null;
                    }
                    if (remainLen <= 0)
                    {
                        pPacketBufferOffset = 0;
                        break;
                    }
                }
                if (pPacketBufferOffset < 0)
                {
                    pPacketBufferOffset = 0;
                }
            }
            if (pPacketBufferOffset < 0)
            {
                pPacketBufferOffset = 0;
            }
            if (isFirstRTP && ServerType == ServerType.RealTime_809 && !GlobalConfig.TransferTo809AfterAnanylze)
            {
                bool res = ServiceUtil.HttpServer.Send(SimNo, Channel, packetBuffer, 0, totalLen);
            }
        }
        /// <summary>
        /// copy到帧缓冲区
        /// </summary>
        /// <param name="start"></param>
        /// <param name="dataLength"></param>
        private void CopyToFrameBuffer(int start, int dataLength)
        {
            if (frameBufferOffset + dataLength > frameBuffer.Length)
            {
                byte[] data = new byte[frameBufferOffset + dataLength + 9500];
                Buffer.BlockCopy(frameBuffer, 0, data, 0, frameBufferOffset);
                frameBuffer = data;
                tracer.NewSpan(SimNo + ",帧缓冲区长度不足,扩充长度为:" + data.Length);
            }
            Buffer.BlockCopy(packetBuffer, start, frameBuffer, frameBufferOffset, dataLength);
            frameBufferOffset += dataLength;
        }
        /// <summary>
        /// 保存邀请日志
        /// </summary>
        /// <param name="descr"></param>
        private void saveInviteLog(string descr)
        {
            InviteLog v = new InviteLog();
            v.Descr = descr;
            v.Tcp = true;
            v.PlateNo = PlateNo;
            v.SimNo = SimNo;
            v.Channel = Channel;
            v.Owner = "1078设备";
            GlobalConfig.InviteLogQueue.Enqueue(v);
        }
        /// <summary>
        /// 处理RTP包
        /// </summary>
        /// <param name="rtp"></param>
        private void processRTPPacket(RTPPacket rtp)
        {
            SimNo = rtp.SimNo;
            Channel = rtp.ChannelId;
            if (rtp.FrameType == RTPPacketExtend.FRAME_TRANSPARENT)
            {
                return;
            }
            if (GlobalConfig.DisplayRtpLog && ID == GlobalConfig.ConnectIdForDisplay)
            {
                GlobalConfig.RTPPacketQueue.Enqueue(rtp);
            }
            if (firstRtpPacket == null)
            {
                firstRtpPacket = rtp;
                string key = string.Concat(ServerType, "_", rtp.SimNo, "_", rtp.ChannelId);
                tracer.NewSpan("接入1078视频连接:" + key);
                if (GlobalConfig.RtpSenderMap.TryGetValue(key, out rtpSender))
                {
                    tracer.NewSpan("发现有GB28181请求,开始转发");
                }
                saveInviteLog("1078视频接入");
                if (ServerType == ServerType.RealTime_809 && !GlobalConfig.TransferTo809AfterAnanylze)
                {
                    return;
                }
                try
                {
                    if (GlobalConfig.VideoConnections.ContainsKey(key))
                    {
                        AsyncSocketConnection conn = GlobalConfig.VideoConnections[key];
                        if (conn != null)
                        {
                            tracer.NewSpan("发现有重复的连接，关闭掉之前的连接:" + key);
                            conn.Close();
                            int i = 0;
                            if (!GlobalConfig.VideoConnections.TryRemove(key, out conn))
                            {
                                tracer.NewSpan("发现有重复的连接，关闭掉之前的连接:" + key + ",移除失败");
                            }
                            tracer.NewSpan("发现有重复的连接，关闭掉之前的连接:" + key + ",移除成功");
                        }
                    }
                    GlobalConfig.VideoConnections[key] = this;
                }
                catch (Exception ex)
                {
                    tracer.NewError(ex.Message, ex);
                }
                if (ServerType == ServerType.Talk)
                {
                    rtmpTalkback = new RtmpTalkback(SimNo, Channel);
                    rtmpTalkback.OnDataReceived += OnTalkBackDataReceived;
                    int coder = AudioCoder.GetAudioCoder(rtp);
                    if (coder > 0)
                    {
                        rtmpTalkback.audioEncoder = coder;
                        string strTemp = string.Concat(rtp.DataLength);
                        if (coder == AudioCoder.ADPCM_IMA || coder == AudioCoder.ADPCM_DVI4)
                        {
                            rtmpTalkback.HISIHead = true;
                        }
                        else
                        {
                            rtmpTalkback.HISIHead = (rtp.DataLength - 4) % 10 == 0;
                        }
                    }
                    rtmpTalkback.Start();
                }
            }
            if (ServerType == ServerType.RealTime_809 && !GlobalConfig.TransferTo809AfterAnanylze)
            {
                return;
            }
            if (ServerType == ServerType.RealTime_809 && GlobalConfig.TransferTo809AfterAnanylze)
            {
                byte[] rtpData = rtp.ToByteArray2();
                bool res = ServiceUtil.HttpServer.Send(SimNo, Channel, rtpData, 0, rtpData.Length);
                if (!res && GlobalConfig.ShowHttpFailLog && SimNo.IndexOf("0131") == 0)
                {
                    tracer.NewSpan("http转发连接失败:" + SimNo + ",通道:" + Channel);
                }
                GovUserPlaying = res;
            }
            else
            {
                if (rtp.FrameType == RTPPacketExtend.FRAME_TRANSPARENT)
                {
                    return;
                }
                if (rtpAnalyzer == null && IsConnected())
                {
                }
                if (rtp.PacketType == RTPPacketExtend.PACKET_LAST || rtp.PacketType == RTPPacketExtend.PACKET_ATOMIC)
                {
                    if (rtp.FrameType == RTPPacketExtend.FRAME_I)
                    {
                        ParseWholeIFramePacket(rtp);
                    }
                    else
                    {
                        AnanlyzeFrame(rtp, frameBuffer, 0, frameBufferOffset);
                    }
                    frameBufferOffset = 0;
                }
            }
        }
        /// <summary>
        /// 分析帧
        /// </summary>
        /// <param name="rtp"></param>
        /// <param name="buffer"></param>
        /// <param name="start"></param>
        /// <param name="len"></param>
        private void AnanlyzeFrame(RTPPacket rtp, byte[] buffer, int start, int len)
        {
            AVFrame avFrame = new AVFrame();
            avFrame.AudioDecoder = 0;
            avFrame.Timestamp = rtp.Timestamp;
            avFrame.ChannelId = rtp.ChannelId;
            avFrame.SimNo = rtp.SimNo;
            avFrame.AudioDecoder = GetAudioCoder(rtp);
            avFrame.FrameType = rtp.FrameType;
            avFrame.Audio = rtp.FrameType == RTPPacketExtend.FRAME_AUDIO;
            AudioDecoder = avFrame.AudioDecoder;
            avFrame.Frame = new byte[len];
            Buffer.BlockCopy(buffer, start, avFrame.Frame, 0, len);
            if (rtpSender != null)
            {
                if (!rtpSender.IsConnected)
                {
                    tracer.NewSpan("RTP 28181转发 连接中断, 断开设备连接");
                    Close();
                    return;
                }
                rtpSender.SendFrame(avFrame);
            }
            else if (rtpAnalyzer != null)
            {
                rtpAnalyzer.Analyze(avFrame);
            }
            if (GlobalConfig.PreviewVideo && ID == GlobalConfig.ConnectIdForDisplay)
            {
                GlobalConfig.AVFrameQueue.Enqueue(avFrame);
            }
        }
        /// <summary>
        /// 获取音频编码
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public static int GetAudioCoder(RTPPacket r)
        {
            if (r == null || r.FrameType != RTPPacketExtend.FRAME_AUDIO)
            {
                return 0;
            }
            if (r.PayloadType == RTPPacketExtend.AUDIO_CODEC_ADPCMA)
            {
                return AudioCoder.ADPCM_DVI4;
            }
            if (r.PayloadType == RTPPacketExtend.AUDIO_CODEC_G726)
            {
                int dataLength = r.DataLength;
                if (dataLength == 164 || dataLength == 160 || dataLength == 324 || dataLength == 320)
                {
                    return AudioCoder.G726_32KBPS;
                }
                if (dataLength == 204 || dataLength == 104)
                {
                    return AudioCoder.G726_40KBPS;
                }
                if (dataLength == 100 || dataLength == 200)
                {
                    return AudioCoder.G726_40KBPS;
                }
                if (dataLength == 120 || dataLength == 124)
                {
                    return AudioCoder.G726_24KBPS;
                }
            }
            else
            {
                if (r.PayloadType == RTPPacketExtend.AUDIO_CODEC_G711A)
                {
                    return AudioCoder.G711_A;
                }
                if (r.PayloadType == RTPPacketExtend.AUDIO_CODEC_G711U)
                {
                    return AudioCoder.G711_U;
                }
                if (r.PayloadType == RTPPacketExtend.AUDIO_CODEC_AAC)
                {
                    return AudioCoder.AAC;
                }
                if (r.PayloadType == RTPPacketExtend.AUDIO_CODEC_AMR_NB)
                {
                    return AudioCoder.AMR_NB;
                }
            }
            return AudioCoder.NOT_SUPPORT;
        }
        /// <summary>
        /// 解析整个帧包
        /// </summary>
        /// <param name="rtp"></param>
        private void ParseWholeIFramePacket(RTPPacket rtp)
        {
            int totalLen = frameBufferOffset;
            int index = 0;
            if (totalLen < 5)
            {
                return;
            }
            int totalNum = 0;
            while (index < totalLen)
            {
                int start = H264FrameStartPos(frameBuffer, index, totalLen);
                if (start < 0)
                {
                    tracer.NewSpan("找不到H.264帧头，无效报文");
                    frameBufferOffset = 0;
                    return;
                }
                if (start >= 0)
                {
                    int headPos = start;
                    if (headPos + 4 >= totalLen)
                    {
                        tracer.NewSpan("异常数据包");
                        return;
                    }
                    int end = H264FrameStartPos(frameBuffer, headPos + 4, totalLen);
                    if (end < start)
                    {
                        end = totalLen;
                    }
                    int packetLen = end - headPos;
                    if (packetLen < 5)
                    {
                        tracer.NewSpan(SimNo + "非法的视频帧:" + ParseUtil.ToHexString(frameBuffer, headPos, packetLen));
                    }
                    else
                    {
                        totalNum++;
                        AnanlyzeFrame(rtp, frameBuffer, headPos, packetLen);
                    }
                    index = end;
                }
            }
            frameBufferOffset = 0;
        }
        /// <summary>
        /// H264帧开始位置
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="start"></param>
        /// <param name="totalLen"></param>
        /// <returns></returns>
        private int H264FrameStartPos(byte[] bytes, int start, int totalLen)
        {
            int i = start;
            int remain = totalLen - start;
            int pos = -1;
            while (i < totalLen && remain > 3 && !IsClosing())
            {
                if (IsH264FrameStart(bytes, i++, totalLen))
                {
                    pos = i - 1;
                    break;
                }
                remain = totalLen - i;
            }
            return pos;
        }
        /// <summary>
        /// 是否H264帧开始
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="start"></param>
        /// <param name="totalLen"></param>
        /// <returns></returns>
        private bool IsH264FrameStart(byte[] bytes, int start, int totalLen)
        {
            if (totalLen - start < 4)
            {
                return false;
            }
            return bytes[start++] == 0 && bytes[start++] == 0 && bytes[start++] == 0 && bytes[start++] == 1;
        }
        /// <summary>
        /// 获取RTP包队列数
        /// </summary>
        /// <returns></returns>
        public int GetRTPPacketQueueNum()
        {
            if (rtpAnalyzer == null)
            {
                return 0;
            }
            return rtpAnalyzer.GetRTPPacketQueueNum();
        }
        /// <summary>
        /// 获取音频录音
        /// </summary>
        /// <returns></returns>
        public int GetAudioDecoder()
        {
            return AudioDecoder;
        }
        /// <summary>
        /// 获取rtp丢包率
        /// </summary>
        /// <returns></returns>
        public string GetRTPLostRate()
        {
            if (rtpAnalyzer == null)
            {
                return "";
            }
            return rtpAnalyzer.lostPacketNum + "(" + rtpAnalyzer.PacketLostRate + "%)";
        }
        /// <summary>
        /// 获取推送时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetPushTime()
        {
            if (rtpSender == null)
            {
                return DateTime.Now;
            }
            return rtpSender.UpdateDate;
        }
        /// <summary>
        /// RTP起始位置
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="index"></param>
        /// <param name="totalLen"></param>
        /// <returns></returns>
        private int RTPStartPos(byte[] bytes, int index, int totalLen)
        {
            int i = index;
            int remain = totalLen;
            int start = -1;
            while (i < totalLen && remain > 3)
            {
                if (IsRTPStart(packetBuffer, i++))
                {
                    start = i - 1;
                    break;
                }
                remain = totalLen - i;
            }
            return start;
        }
        /// <summary>
        /// 是否RTP起始
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        private bool IsRTPStart(byte[] bytes, int start = 0)
        {
            if (bytes.Length < 4)
            {
                return false;
            }
            return bytes[start++] == 48 && bytes[start++] == 49 && bytes[start++] == 99 && bytes[start++] == 100;
        }
        /// <summary>
        /// 是否连接
        /// </summary>
        /// <returns></returns>
        public bool IsConnected()
        {
            return recvEventArgs != null && recvEventArgs.AcceptSocket != null && recvEventArgs.AcceptSocket.Connected;
        }
        /// <summary>
        /// 异步socket连接
        /// </summary>
        public AsyncSocketConnection()
        {
            CreateDate = DateTime.Now;
            OnlineDate = DateTime.Now;
            recvEventArgs.UserToken = this;
            sendEventArgs.UserToken = this;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="s"></param>
        public void Init(Socket s)
        {
            recvEventArgs.AcceptSocket = s;
            sendEventArgs.AcceptSocket = s;
            ClientIP = (IPEndPoint)recvEventArgs.AcceptSocket.RemoteEndPoint;
            firstRtpPacket = null;
            OnlineDate = DateTime.Now;
            CreateDate = DateTime.Now;
            PlateNo = "";
            SimNo = null;
            rtmpTalkback = null;
            rtpAnalyzer = null;
            CalcFlowTime = DateTime.Now;
            Status = "Created";
        }
        /// <summary>
        /// 是否有效
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            return recvEventArgs != null && recvEventArgs.AcceptSocket != null;
        }
        /// <summary>
        /// 是否关闭
        /// </summary>
        /// <returns></returns>
        public bool IsClosing()
        {
            return Status == "Closing";
        }
        /// <summary>
        /// 关闭
        /// </summary>
        public void Close()
        {
            saveInviteLog("1078视频断开");
            string key = string.Concat(ServerType, ",", SimNo, "_", Channel);
            tracer.NewSpan(key + "准备关闭");
            lock (connectionLock)
            {
                if (Status != "Created")
                {
                    tracer.NewSpan(key + "关闭连接时,发现已经被关闭");
                    return;
                }
                Status = "Closing";
            }
            tracer.NewSpan(key + "开始关闭");
            if (string.IsNullOrEmpty(ID))
            {
                return;
            }
            try
            {
                if (rtpSender != null)
                {
                    rtpSender.Stop();
                    GlobalConfig.RtpSenderMap.TryRemove(key, out rtpSender);
                    tracer.NewSpan(key + "关闭28181推流");
                }
                rtpSender = null;
                if (GlobalConfig.ForceCloseHttpWhenTerminalDisconnect)
                {
                    ServiceUtil.HttpServer.CloseConnection(SimNo, Channel);
                }
            }
            catch (Exception ex5)
            {
                tracer.NewError(ex5.Message, ex5);
            }
            if (firstRtpPacket != null)
            {
                try
                {
                    VideoDataUsageDetail d = new VideoDataUsageDetail();
                    d.StartTime = CreateDate;
                    d.EndTime = DateTime.Now;
                    d.UpdateDate = OnlineDate;
                    d.CreateDate = CreateDate;
                    d.DataUsage = DataUsage;
                    d.ChannelId = firstRtpPacket.ChannelId;
                    d.SimNo = firstRtpPacket.SimNo;
                    d.TotalTime = (d.EndTime.Value - d.StartTime).TotalMinutes;
                    ServiceUtil.VideoDataUsageDetailService.EnQueue(d);
                }
                catch (Exception ex6)
                {
                    tracer.NewError(ex6.Message, ex6);
                }
                try
                {
                    string connKey = string.Concat(ServerType, "_", firstRtpPacket.SimNo, "_", firstRtpPacket.ChannelId);
                    if (GlobalConfig.VideoConnections.ContainsKey(connKey))
                    {
                        AsyncSocketConnection t = null;
                        int i = 0;
                        while (!GlobalConfig.VideoConnections.TryRemove(connKey, out t) && i < 10)
                        {
                            tracer.NewSpan(key + "连接从缓存中移除" + i);
                            Thread.Sleep(10);
                        }
                    }
                }
                catch (Exception ex4)
                {
                    tracer.NewError(ex4.Message, ex4);
                }
            }
            try
            {
                if (recvEventArgs != null && recvEventArgs.AcceptSocket != null)
                {
                    recvEventArgs.AcceptSocket.Shutdown(SocketShutdown.Both);
                    recvEventArgs.AcceptSocket.Close();
                    recvEventArgs.AcceptSocket = null;
                }
            }
            catch (Exception ex3)
            {
                tracer.NewError(ex3.Message, ex3);
            }
            string successMessage = string.Concat(ServerType, ",", SimNo, "_", Channel, "成功关闭");
            try
            {
                SimNo = null;
                PlateNo = "";
                ID = "";
                DataUsage = 0;
                LastUsage = 0;
                pPacketBufferOffset = 0;
                frameBufferOffset = 0;
                frameBuffer = null;
                GovUserPlaying = false;
                if (rtpAnalyzer != null)
                {
                    rtpAnalyzer.Stop();
                }
                rtpAnalyzer = null;
                if (rtmpTalkback != null)
                {
                    rtmpTalkback.Stop();
                }
                rtmpTalkback = null;
            }
            catch (Exception ex2)
            {
                tracer.NewError(ex2.Message, ex2);
            }
            try
            {
                if (rtpFileWriter != null)
                {
                    rtpFileWriter.Close();
                }
            }
            catch (Exception ex)
            {
                tracer.NewError(ex.Message, ex);
            }
            rtpFileWriter = null;
            tracer.NewSpan(successMessage);
            onConnectionClosed?.Invoke(this);
        }
        /// <summary>
        /// 获取连接描述
        /// </summary>
        /// <returns></returns>
        public string GetConnectionDescr()
        {
            return string.Concat(ServerType, ",", SimNo, ",", Channel);
        }
        /// <summary>
        /// 是否接收
        /// </summary>
        /// <returns></returns>
        public bool Recv()
        {
            if (Status == "Closing" || !IsConnected())
            {
                tracer.NewSpan(GetConnectionDescr() + "连接已经关闭,数据直接丢弃");
                return true;
            }
            try
            {
                recvedCount = recvEventArgs.BytesTransferred;
                DataUsage += recvedCount;
                if (firstRtpPacket != null)
                {
                    if (firstRtpPacket.SimNo != SimNo)
                    {
                        tracer.NewSpan("出现不一致的simNo, " + firstRtpPacket.SimNo + "," + SimNo);
                    }
                    if (ServerType == ServerType.RealTime_809 && !GlobalConfig.TransferTo809AfterAnanylze)
                    {
                        bool res = ServiceUtil.HttpServer.Send(SimNo, Channel, recvEventArgs.Buffer, recvEventArgs.Offset, recvedCount);
                        if (!res && GlobalConfig.ShowHttpFailLog && SimNo.IndexOf("0131") == 0)
                        {
                            tracer.NewSpan("http转发连接失败:" + SimNo + ",通道:" + Channel);
                        }
                        GovUserPlaying = res;
                        return true;
                    }
                }
                if (packetBuffer.Length < pPacketBufferOffset + recvedCount)
                {
                    tracer.NewSpan("RTP包缓冲区溢出，清除缓冲");
                    pPacketBufferOffset = 0;
                }
                Buffer.BlockCopy(recvEventArgs.Buffer, recvEventArgs.Offset, packetBuffer, pPacketBufferOffset, recvedCount);
                pPacketBufferOffset += recvedCount;
                try
                {
                    ParseWholePacket();
                }
                catch (Exception ex2)
                {
                    tracer.NewError(ex2.Message, ex2);
                }
                if (Logs.LogAllStream)
                {
                    if (rtpFileWriter == null)
                    {
                        string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\rtp" + SimNo + "_" + Channel + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
                        rtpFileWriter = new StreamWriter(filePath, append: true);
                    }
                    string str = ParseUtil.ToHexString(recvEventArgs.Buffer, recvEventArgs.Offset, recvedCount);
                    rtpFileWriter.WriteLine(str);
                    rtpFileWriter.Flush();
                }
            }
            catch (Exception ex)
            {
                tracer.NewError(ex.Message, ex);
            }
            return true;
        }
        /// <summary>
        /// 对讲数据接收
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        private void OnTalkBackDataReceived(object o, ReceivedEventArgs e)
        {
            try
            {
                RTPPacket rtp = e.Data;
                if (GlobalConfig.ShowTalkLog)
                {
                    GlobalConfig.RTPTalkQueue.Enqueue(rtp);
                }
                byte[] data = rtp.ToByteArray();
                Send(data, data.Length);
            }
            catch (Exception ex)
            {
                tracer.NewError(ex.Message, ex);
            }
        }
        /// <summary>
        /// 发送
        /// </summary>
        /// <param name="data"></param>
        /// <param name="length"></param>
        public void Send(byte[] data, int length)
        {
            if (IsConnected())
            {
                Socket s = recvEventArgs.AcceptSocket;
                int offset = 0;
                int remain = length;
                while (remain > 0 && s.Connected)
                {
                    int sendBytes = s.Send(data, offset, remain, SocketFlags.None);
                    offset += sendBytes;
                    remain -= sendBytes;
                }
            }
        }

        public ValueTask<Int32> ReadAsync(Memory<Byte> buffer, TimeSpan timeout) => throw new NotImplementedException();
        public ValueTask WriteAsync(ReadOnlyMemory<Byte> buffer, Boolean immediate, TimeSpan timeout) => throw new NotImplementedException();
        public void Abort() => throw new NotImplementedException();
        public ValueTask CloseAsync(TimeSpan timeout) => throw new NotImplementedException();
    }
}
