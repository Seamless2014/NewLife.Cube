using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VehicleVideoManage.Video.Codec
{
    /// <summary>
    /// 包
    /// </summary>
    public class PacketUtil
    {
        /// <summary>
        /// 写
        /// </summary>
        protected BinaryWriter binWriter;
        /// <summary>
        /// 内存流
        /// </summary>
        private MemoryStream memoryStream;
        /// <summary>
        /// 总包长度
        /// </summary>
        public int TotalPacketLength
        {
            get;
            set;
        }
        /// <summary>
        /// 包字节
        /// </summary>
        public byte[] PacketBytes
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public PacketUtil()
        {
            memoryStream = new MemoryStream();
            binWriter = new BinaryWriter(memoryStream);
        }
        /// <summary>
        /// 开始写内容
        /// </summary>
        /// <returns></returns>
        public BinaryWriter beginWriteContent()
        {
            binWriter = new BinaryWriter(memoryStream);
            return binWriter;
        }
        /// <summary>
        /// 转成数组
        /// </summary>
        /// <returns></returns>
        public byte[] ToArray()
        {
            return memoryStream.ToArray();
        }
        /// <summary>
        /// 写数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="len"></param>
        public void Write(byte[] data, int len)
        {
            TotalPacketLength += len;
            binWriter.Write(data, 0, len);
        }
        /// <summary>
        /// 写BCD
        /// </summary>
        /// <param name="bcd"></param>
        /// <param name="bcdLen"></param>
        public void WriteBcd(string bcd, int bcdLen)
        {
            bcd = ((bcd == null) ? "" : bcd);
            byte[] buffer = new byte[bcdLen];
            int len = bcdLen * 2;
            if (bcd.Length < len)
            {
                bcd = bcd.PadLeft(len, '0');
            }
            for (int i = 0; i < len; i += 2)
            {
                buffer[i / 2] = Convert.ToByte(bcd.Substring(i, 2), 16);
            }
            binWriter.Write(buffer);
        }
        /// <summary>
        /// 写数据
        /// </summary>
        /// <param name="data"></param>
        public void Write(byte[] data)
        {
            TotalPacketLength += data.Length;
            binWriter.Write(data);
        }
        /// <summary>
        /// 写数据
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public int Write(string str, int length)
        {
            int len = 0;
            if (str != null)
            {
                if (str.Length > length)
                {
                    str = str.Substring(0, length);
                }
                len = Write(str);
            }
            for (; len < length; len++)
            {
                Write((byte)0);
            }
            return length;
        }
        /// <summary>
        /// 写数据
        /// </summary>
        /// <param name="data"></param>
        public void Write(int data)
        {
            data = IPAddress.HostToNetworkOrder(data);
            binWriter.Write(data);
            TotalPacketLength += 4;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void Write(short data)
        {
            data = IPAddress.HostToNetworkOrder(data);
            binWriter.Write(data);
            TotalPacketLength += 2;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="data"></param>
        public void Write(uint data)
        {
            byte[] vBytes = BitConverter.GetBytes(data);
            Array.Reverse(vBytes);
            binWriter.Write(vBytes);
            TotalPacketLength += 4;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void Write(ulong data)
        {
            byte[] vBytes = BitConverter.GetBytes(data);
            Array.Reverse(vBytes);
            binWriter.Write(vBytes);
            TotalPacketLength += 8;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void Write(ushort data)
        {
            byte[] vBytes = BitConverter.GetBytes(data);
            Array.Reverse(vBytes);
            binWriter.Write(vBytes);
            TotalPacketLength += 4;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int Write(string str)
        {
            byte[] strBytes = Encoding.GetEncoding("GBK").GetBytes(str);
            int len = strBytes.Length;
            binWriter.Write(strBytes);
            TotalPacketLength += len;
            return len;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        public void Write(byte b)
        {
            binWriter.Write(b);
            TotalPacketLength++;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int WriteAscII(string str)
        {
            char[] stringArray = str.ToCharArray();
            int len = stringArray.Length;
            binWriter.Write(stringArray);
            TotalPacketLength += len;
            return len;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        public void Write(DateTime d)
        {
            Write((short)d.Year);
            binWriter.Write((byte)d.Month);
            binWriter.Write((byte)d.Day);
            binWriter.Write((byte)d.Hour);
            binWriter.Write((byte)d.Minute);
            binWriter.Write((byte)d.Second);
            TotalPacketLength += 7;
        }
    }
}
