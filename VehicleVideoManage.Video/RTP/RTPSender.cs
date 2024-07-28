using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using NewLife.Log;
using SIPSorcery.GB28181.SIP.Core;
using VehicleVideoManage.Video.RTMP;
using VehicleVideoManage.Video.ViewModel;

namespace VehicleVideoManage.Video.RTP
{
    /// <summary>
	/// rtp发送
	/// </summary>
	public class RTPSender
    {
        /// <summary>
        /// 数据包缓冲区
        /// </summary>
        private byte[] packetBuffer = new byte[951200];
        /// <summary>
        /// 缓冲区长度
        /// </summary>
        private int bufferDataLength;
        /// <summary>
        /// 半包标识
        /// </summary>
        private bool HalfPacketTag = false;
        /// <summary>
        /// 实时数据线程
        /// </summary>
        private Thread processRealDataThread;
        /// <summary>
        /// H264帧队列
        /// </summary>
        public ConcurrentQueue<AVFrame> h264FrameQueue = new ConcurrentQueue<AVFrame>();
        /// <summary>
        /// rtp发送
        /// </summary>
        private IntPtr rtpSender = IntPtr.Zero;
        /// <summary>
        /// 是否继续分析
        /// </summary>
        private bool continueAnalyze = true;
        /// <summary>
        /// sps帧
        /// </summary>
        private byte[] spsFrame;
        /// <summary>
        /// pps帧
        /// </summary>
        private byte[] ppsFrame;
        /// <summary>
        /// 间隔
        /// </summary>
        private int tickInterval = 0;
        /// <summary>
        /// 序号
        /// </summary>
        private int sn = 0;
        /// <summary>
        /// 最后帧
        /// </summary>
        private AVFrame lastFrame = null;
        /// <summary>
        /// 设备节点
        /// </summary>
        public VTreeNode Device
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
        /// 更新时间
        /// </summary>
        public DateTime UpdateDate
        {
            get;
            set;
        }
        /// <summary>
        /// 是否连接
        /// </summary>
        public bool IsConnected
        {
            get;
            set;
        }
        /// <summary>
        /// 邀请多媒体信息
        /// </summary>
        public InviteMediaInfo InviteMediaInfo
        {
            get;
            set;
        }
        /// <summary>
        /// rtp发送者
        /// </summary>
        /// <param name="im"></param>
        public RTPSender(InviteMediaInfo im)
        {
            InviteMediaInfo = im;
            IsConnected = true;
        }
        private readonly ITracer tracer;
        public RTPSender(ITracer _tracer)
        {
            tracer = _tracer;
        }
        /// <summary>
        /// 开始
        /// </summary>
        /// <returns></returns>
        private bool Start()
        {
            CreateDate = DateTime.Now;
            processRealDataThread = new Thread(Analyze);
            processRealDataThread.Start();
            tracer.NewSpan("RTP sender已启动发送线程:" + InviteMediaInfo.ToString());
            return true;
        }
        /// <summary>
        /// 保存邀请日志
        /// </summary>
        /// <param name="im"></param>
        /// <param name="descr"></param>
        private void saveInviteLog(InviteMediaInfo im, string descr)
        {
            if (im != null)
            {
                InviteLog v = new InviteLog();
                v.Remark = im.ToString();
                v.Descr = descr;
                v.Tcp = im.TcpPassive;
                v.DeviceId = im.DeviceId;
                if (Device != null)
                {
                    v.PlateNo = Device.name;
                    v.SimNo = Device.simNo;
                    v.Channel = Device.channelId;
                }
                v.Owner = "RTP Sender";
                GlobalConfig.InviteLogQueue.Enqueue(v);
            }
        }
        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            try
            {
                saveInviteLog(InviteMediaInfo, "GB28181视频连接断开");
                continueAnalyze = false;
                IsConnected = false;
                if (processRealDataThread != null)
                {
                    processRealDataThread.Join(30000);
                }
                if (rtpSender != IntPtr.Zero)
                {
                    RTMPWrapper.RTP_Close(rtpSender);
                }
                rtpSender = IntPtr.Zero;
                tracer.NewSpan("RTP sender已成功关闭:" + InviteMediaInfo.ToString());
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// 发送帧
        /// </summary>
        /// <param name="frame"></param>
        public void SendFrame(AVFrame frame)
        {
            if (continueAnalyze && !frame.Audio)
            {
                if (processRealDataThread == null)
                {
                    Start();
                }
                h264FrameQueue.Enqueue(frame);
            }
        }
        /// <summary>
        /// 连接
        /// </summary>
        /// <returns></returns>
        private bool Connect()
        {
            tracer.NewSpan("开始通过端口发送视频:" + InviteMediaInfo.ToString());
            int tcp = (InviteMediaInfo.TcpPassive ? 1 : 0);
            rtpSender = RTMPWrapper.RTP_Init(InviteMediaInfo.RemoteIp, InviteMediaInfo.LocalPort, InviteMediaInfo.RemotePort, InviteMediaInfo.Ssrc, tcp);
            if (rtpSender == IntPtr.Zero)
            {
                saveInviteLog(InviteMediaInfo, "连接上级平台失败");
                IsConnected = false;
                tracer.NewSpan("连接上级平台失败:" + InviteMediaInfo.ToString());
                return false;
            }
            saveInviteLog(InviteMediaInfo, "开始转发");
            IsConnected = true;
            return true;
        }
        /// <summary>
        /// 分析
        /// </summary>
        private void Analyze()
        {
            while (continueAnalyze)
            {
                AVFrame rtp = null;
                while (continueAnalyze && h264FrameQueue.TryDequeue(out rtp))
                {
                    if (rtpSender == IntPtr.Zero && !Connect())
                    {
                        continueAnalyze = false;
                        return;
                    }
                    try
                    {
                        ProcessFrame(rtp);
                    }
                    catch (Exception ex)
                    {
                        tracer.NewError(ex.Message, ex);
                    }
                }
                Thread.Sleep(2);
            }
            tracer.NewSpan("线程正常退出");
        }
        /// <summary>
        /// 发送帧
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pts"></param>
        /// <param name="frameType"></param>
        public void SendFrame(byte[] data, int pts, int frameType)
        {
            DateTime start = DateTime.Now;
            IntPtr pFrameBuffer = RTMPWrapper.BytesToIntPtr(data);
            int res = RTMPWrapper.SendH264FrameByRTP(rtpSender, pFrameBuffer, data.Length, pts, frameType);
            if (res == -1)
            {
                IsConnected = false;
                tracer.NewSpan("发送失败");
            }
            else
            {
                UpdateDate = DateTime.Now;
            }
            //释放以前从进程的非托管内存中分配的内存。
            Marshal.FreeHGlobal(pFrameBuffer);
            DateTime end = DateTime.Now;
            TimeSpan ts = end - start;
            if (ts.TotalMilliseconds > 200.0)
            {
                tracer.NewSpan("帧类型:" + frameType + ",长度:" + data.Length + "发送耗时:" + ts.TotalMilliseconds);
            }
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        public void loadData()
        {
            string mp4FilePath = "C:\\tmp.264";
            if (!File.Exists(mp4FilePath))
            {
                tracer.NewSpan("264文件数据不存在:" + mp4FilePath);
                return;
            }
            byte[] byData = new byte[40960];
            char[] charData = new char[1200];
            try
            {
                FileStream aFile = new FileStream(mp4FilePath, FileMode.Open);
                int readBytes = 0;
                while ((readBytes = aFile.Read(byData, 0, byData.Length)) > 0)
                {
                    Analyze(byData, 0, readBytes);
                }
                Console.WriteLine("读取文件成功，开始播放!");
                aFile.Close();
            }
            catch (IOException e)
            {
                tracer.NewError("264文件数据读取失败:" + mp4FilePath + "," + e.Message, e);
                Console.WriteLine("An IO exception has been thrown!");
                Console.WriteLine(e.ToString());
                Console.ReadKey();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        public void Analyze(byte[] data, int start, int length)
        {
            if (data[0] == 0 && data[1] == 1 && (data[2] == 50 || data[2] == 82) && data[3] == 0 && data.Length < 200)
            {
            }
            Buffer.BlockCopy(data, start, packetBuffer, bufferDataLength, length);
            bufferDataLength += data.Length;
            ParseWholePacket();
        }
        /// <summary>
        /// 解析整个包
        /// </summary>
        private void ParseWholePacket()
        {
            sn++;
            int totalLen = bufferDataLength;
            int index = 0;
            if (bufferDataLength < 5)
            {
                return;
            }
            while (index < totalLen)
            {
                int start = H264FrameStartPos(packetBuffer, index, totalLen);
                if (start < 0)
                {
                    if (bufferDataLength > 1100)
                    {
                        bufferDataLength = 0;
                    }
                    break;
                }
                if (start >= 0)
                {
                    int headPos = start + 3;
                    int end = H264FrameStartPos(packetBuffer, headPos, totalLen);
                    if (end < start)
                    {
                        HalfPacketTag = true;
                        if (start > 0)
                        {
                            bufferDataLength = totalLen - start;
                            Buffer.BlockCopy(packetBuffer, start, packetBuffer, 0, bufferDataLength);
                        }
                        break;
                    }
                    HalfPacketTag = false;
                    int packetLen = end - start;
                    byte[] wholePacket = new byte[packetLen];
                    Buffer.BlockCopy(packetBuffer, start, wholePacket, 0, packetLen);
                    index = end;
                }
                if (bufferDataLength < 0)
                {
                    bufferDataLength = 0;
                }
            }
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
            while (i < totalLen && remain > 3)
            {
                if (IsH264FrameStart(packetBuffer, i++, totalLen))
                {
                    pos = i - 1;
                    break;
                }
                remain = totalLen - i;
            }
            return pos;
        }
        /// <summary>
        /// 是否H264帧
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="pos"></param>
        /// <param name="totalLen"></param>
        /// <returns></returns>
        private bool IsH264FrameStart(byte[] bytes, int pos, int totalLen)
        {
            if (totalLen - pos < 4)
            {
                return false;
            }
            int start = pos;
            bool res = bytes[start++] == 0 && bytes[start++] == 0 && bytes[start++] == 0 && bytes[start++] == 1;
            start = pos;
            if (!res)
            {
                res = bytes[start++] == 0 && bytes[start++] == 0 && bytes[start++] == 1;
            }
            return res;
        }
        /// <summary>
        /// 处理帧
        /// </summary>
        /// <param name="avframe"></param>
        public void ProcessFrame(AVFrame avframe)
        {
            byte[] frame = avframe.Frame;
            int start = 0;
            int naluType = ((frame[start++] == 0 && frame[start++] == 0 && frame[start++] == 0 && frame[start++] == 1) ? (frame[4] & 0x1F) : (frame[3] & 0x1F));
            switch (naluType)
            {
                case 7:
                    spsFrame = frame;
                    break;
                case 8:
                    ppsFrame = frame;
                    break;
                case 5:
                    {
                        if (spsFrame == null || ppsFrame == null)
                        {
                            Console.WriteLine("没有收到sps和pps,无法发送I帧");
                            break;
                        }
                        byte[] IFrame = frame;
                        byte[] data = new byte[frame.Length + spsFrame.Length + ppsFrame.Length];
                        Buffer.BlockCopy(spsFrame, 0, data, 0, spsFrame.Length);
                        Buffer.BlockCopy(ppsFrame, 0, data, spsFrame.Length, ppsFrame.Length);
                        Buffer.BlockCopy(IFrame, 0, data, spsFrame.Length + ppsFrame.Length, IFrame.Length);
                        if (lastFrame != null)
                        {
                            int interval2 = (int)(avframe.Timestamp - lastFrame.Timestamp);
                            int pts2 = 90000 * interval2 / 1000;
                            tickInterval += pts2;
                        }
                        SendFrame(data, tickInterval, naluType);
                        lastFrame = avframe;
                        break;
                    }
                case 1:
                    if (lastFrame != null)
                    {
                        int interval = (int)(avframe.Timestamp - lastFrame.Timestamp);
                        int pts = 90000 * interval / 1000;
                        tickInterval += pts;
                    }
                    SendFrame(frame, tickInterval, naluType);
                    lastFrame = avframe;
                    break;
                case 6:
                    break;
                default:
                    tracer.NewSpan("未知的naluType:" + naluType);
                    break;
            }
        }
        /// <summary>
        /// 字节转成 表示一个带符号整数，其中位宽度与指针相同。非托管内存
		/// 调用 方法以分配与非托管字符串占用的相同字节数
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static IntPtr BytesToIntPtr(byte[] bytes)
        {
            int size = bytes.Length;
            IntPtr buffer = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.Copy(bytes, 0, buffer, size);
                return buffer;
            }
            finally
            {
            }
        }
        /// <summary>
        /// 获取帧类型描述
        /// </summary>
        /// <param name="frame"></param>
        /// <returns></returns>
        private string getFrameTypeDescr(byte[] frame)
        {
            int naluType = frame[0] & 0x1F;
            string descr = "未知帧" + naluType;
            switch (naluType)
            {
                case 7:
                    descr = "SPS帧";
                    break;
                case 8:
                    descr = "PPS帧";
                    break;
                case 5:
                    descr = "I帧";
                    break;
                case 1:
                    descr = "P帧";
                    break;
                case 6:
                    descr = "SEI帧";
                    break;
            }
            return descr;
        }
    }
}
