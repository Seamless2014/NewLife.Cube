using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleVideoManage.Video.Codec;

namespace VehicleVideoManage.Video.RTP
{
    /// <summary>
    /// RTP包
    /// </summary>
    public class RTPPacket
    {
        /// <summary>
        /// 索引
        /// </summary>
        public int dataIndex;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime
        {
            get;
            set;
        }
        /// <summary>
        /// 帧头
        /// </summary>
        public byte[] Header
        {
            get;
            set;
        }
        /// <summary>
        /// V
        /// </summary>
        public int V
        {
            get;
            set;
        }
        /// <summary>
        /// P
        /// </summary>
        public int P
        {
            get;
            set;
        }
        /// <summary>
        /// X
        /// </summary>
        public int X
        {
            get;
            set;
        }
        /// <summary>
        /// CC
        /// </summary>
        public int CC
        {
            get;
            set;
        }
        /// <summary>
        /// 标识
        /// </summary>
        public int Marker
        {
            get;
            set;
        }
        /// <summary>
        /// 加载类型
        /// </summary>
        public int PayloadType
        {
            get;
            set;
        }
        /// <summary>
        /// 序列号
        /// </summary>
        public ushort SequenceNumber
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
        /// 通道号
        /// </summary>
        public int ChannelId
        {
            get;
            set;
        }
        /// <summary>
        /// 帧类型
        /// </summary>
        public int FrameType
        {
            get;
            set;
        }
        /// <summary>
        /// 包类型
        /// </summary>
        public int PacketType
        {
            get;
            set;
        }
        /// <summary>
        /// 时间戳
        /// </summary>
        public ulong Timestamp
        {
            get;
            set;
        }
        /// <summary>
        /// 最后I帧间隔
        /// </summary>
        public ushort LastIFrameInterval
        {
            get;
            set;
        }
        /// <summary>
        /// 最后帧间隔
        /// </summary>
        public ushort LastFrameInterval
        {
            get;
            set;
        }
        /// <summary>
        /// 数据长度
        /// </summary>
        public ushort DataLength
        {
            get;
            set;
        }
        /// <summary>
        /// 数据体
        /// </summary>
        public byte[] DataBody
        {
            get;
            set;
        }
        /// <summary>
        /// 包描述
        /// </summary>
        private string PacketDescr
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="simNo"></param>
        /// <param name="chanelId"></param>
        /// <param name="serialNo"></param>
        /// <param name="timestamp"></param>
        /// <param name="audioData"></param>
        /// <param name="payloadType"></param>
        public RTPPacket(string simNo, int chanelId, ushort serialNo, ulong timestamp, byte[] audioData, int payloadType)
        {
            Header = new byte[4]
            {
                48,
                49,
                99,
                100
            };
            V = 3;
            P = 0;
            X = 0;
            CC = 1;
            Marker = 1;
            PayloadType = payloadType;
            SequenceNumber = serialNo;
            SimNo = simNo;
            ChannelId = chanelId;
            FrameType = RTPPacketExtend.FRAME_AUDIO;
            PacketType = RTPPacketExtend.PACKET_ATOMIC;
            Timestamp = timestamp;
            DataLength = (ushort)audioData.Length;
            DataBody = audioData;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <param name="_SimNo"></param>
        public RTPPacket(byte[] bytes, int start, int count, string _SimNo = null)
        {
            CreateTime = DateTime.Now;
            using ParseUtil p = new ParseUtil(bytes, start, 30);
            Header = p.ParseBytes(4);
            byte b = p.Parse();
            b = p.Parse();
            Marker = b & 0x80;
            PayloadType = b & 0x7F;
            SequenceNumber = p.ParseUInt16();
            if (_SimNo == null)
            {
                SimNo = p.ParseBcdString(6);
            }
            else
            {
                p.Skip(6);
                SimNo = _SimNo;
            }
            ChannelId = p.Parse();
            b = p.Parse();
            FrameType = (b & 0xF0) >> 4;
            PacketType = b & 0xF;
            if (FrameType < RTPPacketExtend.FRAME_TRANSPARENT)
            {
                Timestamp = p.ParseUInt64();
            }
            if (FrameType < 3)
            {
                LastIFrameInterval = p.ParseUInt16();
                LastFrameInterval = p.ParseUInt16();
            }
            DataLength = p.ParseUInt16();
            int dataStart = start + HeaderLen();
            int remain = count - HeaderLen();
            addData(bytes, dataStart, remain);
        }
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public int addData(byte[] data, int start, int length)
        {
            int r = Remain();
            int len = ((length > r) ? r : length);
            dataIndex += len;
            return len;
        }
        /// <summary>
        /// 是否完成
        /// </summary>
        /// <returns></returns>
        public bool IsCompleted()
        {
            return DataLength == dataIndex;
        }
        /// <summary>
        /// 头长度
        /// </summary>
        /// <returns></returns>
        public int HeaderLen()
        {
            if (FrameType == RTPPacketExtend.FRAME_TRANSPARENT)
            {
                return 18;
            }
            return (FrameType < 3) ? 30 : 26;
        }
        /// <summary>
        /// 转换为字节数组
        /// </summary>
        /// <returns></returns>
        public byte[] ToByteArray()
        {
            PacketUtil p = new PacketUtil();
            p.Write(Header);
            byte h1 = 129;
            p.Write(h1);
            byte h2 = (byte)(0x80u | (uint)PayloadType);
            p.Write(h2);
            p.Write(SequenceNumber);
            p.WriteBcd(SimNo, 6);
            p.Write((byte)ChannelId);
            byte b = 48;
            p.Write(b);
            p.Write(Timestamp);
            p.Write(DataLength);
            p.Write(DataBody);
            return p.ToArray();
        }
        /// <summary>
        /// 转换为字节数组2
        /// </summary>
        /// <returns></returns>
        public byte[] ToByteArray2()
        {
            PacketUtil p = new PacketUtil();
            p.Write(Header);
            byte h1 = 129;
            p.Write(h1);
            byte h2 = (byte)(0x80u | (uint)PayloadType);
            p.Write(h2);
            p.Write(SequenceNumber);
            p.WriteBcd(SimNo, 6);
            p.Write((byte)ChannelId);
            string t = Convert.ToString(FrameType, 2).PadLeft(4, '0') + Convert.ToString(PacketType, 2).PadLeft(4, '0');
            byte b = Convert.ToByte(t, 2);
            p.Write(b);
            p.Write(Timestamp);
            if (FrameType < 3)
            {
                p.Write(LastIFrameInterval);
                p.Write(LastFrameInterval);
            }
            p.Write(DataLength);
            p.Write(DataBody);
            return p.ToArray();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string strFrameType = "未知帧";
            if (FrameType == 0)
            {
                strFrameType = "I帧";
            }
            else if (FrameType == 1)
            {
                strFrameType = "P帧";
            }
            else if (FrameType == 2)
            {
                strFrameType = "B帧";
            }
            else if (FrameType == 3)
            {
                strFrameType = "音频";
            }
            else if (FrameType == 4)
            {
                strFrameType = "透传";
            }
            string strPacketType = "未知分包标记";
            if (PacketType == 0)
            {
                strPacketType = "原子包";
            }
            else if (PacketType == 1)
            {
                strPacketType = "第一包";
            }
            else if (PacketType == 2)
            {
                strPacketType = "结尾包";
            }
            else if (PacketType == 3)
            {
                strPacketType = "中间包";
            }
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.AppendFormat("负载类型：{0},包序号：{1},时间戳:{2},数据帧类型：{3},分包标记:{4},I帧间隔：{5}秒,帧间隔:{6}秒,包长度:{7},帧边界{8}", PayloadType, SequenceNumber, Timestamp, strFrameType, strPacketType, LastIFrameInterval, LastFrameInterval, DataLength, Marker);
            return sBuilder.ToString();
        }
        /// <summary>
        /// 剩余
        /// </summary>
        /// <returns></returns>
        public int Remain()
        {
            return DataLength - dataIndex;
        }
    }
}
