using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VehicleVideoManage.Video.Codec
{
    public class ParseUtil : IDisposable
    {
        private MemoryStream memoryStream;

        public BinaryReader reader
        {
            get;
            set;
        }

        public ParseUtil(byte[] byBuffer)
        {
            memoryStream = new MemoryStream(byBuffer);
            reader = new BinaryReader(memoryStream);
        }

        public ParseUtil(byte[] byBuffer, int index, int count)
        {
            memoryStream = new MemoryStream(byBuffer, index, count);
            reader = new BinaryReader(memoryStream);
        }

        public BinaryReader newReader(byte[] byBuffer, int nReceived)
        {
            return newReader(byBuffer, 0, nReceived);
        }

        public BinaryReader newReader(byte[] byBuffer, int start, int nReceived)
        {
            memoryStream = new MemoryStream(byBuffer, start, nReceived);
            return new BinaryReader(memoryStream);
        }

        public bool IsEnd()
        {
            return memoryStream.Position >= memoryStream.Length;
        }

        public byte Parse()
        {
            return reader.ReadByte();
        }

        public string ParseAsBinaryString()
        {
            byte b = Parse();
            return Convert.ToString(b, 2).PadLeft(8, '0');
        }

        public byte[] ParseBytes(int len)
        {
            return reader.ReadBytes(len);
        }

        public byte[] ParseBytes()
        {
            long len = memoryStream.Length - memoryStream.Position;
            return reader.ReadBytes((int)len);
        }

        public DateTime ParseDateTime()
        {
            short year = IPAddress.NetworkToHostOrder(reader.ReadInt16());
            byte month = reader.ReadByte();
            byte day = reader.ReadByte();
            byte hour = reader.ReadByte();
            byte minute = reader.ReadByte();
            byte sec = reader.ReadByte();
            return new DateTime(year, month, day, hour, minute, sec);
        }

        public uint ParseUInt32()
        {
            byte[] vBytes = reader.ReadBytes(4);
            Array.Reverse(vBytes);
            return BitConverter.ToUInt32(vBytes, 0);
        }

        public ulong ParseUInt64()
        {
            byte[] vBytes = reader.ReadBytes(8);
            Array.Reverse(vBytes);
            return BitConverter.ToUInt64(vBytes, 0);
        }

        public int ParseInt32()
        {
            int flow = reader.ReadInt32();
            return IPAddress.NetworkToHostOrder(flow);
        }

        public ushort ParseUInt16()
        {
            byte[] vBytes = reader.ReadBytes(2);
            Array.Reverse(vBytes);
            return BitConverter.ToUInt16(vBytes, 0);
        }

        public short ParseInt16()
        {
            short test = reader.ReadInt16();
            return IPAddress.NetworkToHostOrder(test);
        }

        public string ParseBcdString(int len)
        {
            byte[] bytes = ParseBytes(len);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < len; i++)
            {
                sb.Append(bytes[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public void Skip(int len)
        {
            for (int i = 0; i < len; i++)
            {
                Parse();
            }
        }

        public string ParseStringBZ(int intLength)
        {
            string strReturn = "";
            for (int i = 0; i < intLength; i++)
            {
                strReturn += Parse().ToString("x2");
            }
            return strReturn;
        }

        public string ParseString()
        {
            long remain = memoryStream.Length - memoryStream.Position;
            return ParseString((int)remain);
        }

        public string ParseString(int len)
        {
            byte[] bytes = reader.ReadBytes(len);
            return Encoding.ASCII.GetString(bytes).TrimEnd(default(char));
        }

        public string ParseString(int len, Encoding encoding)
        {
            byte[] bytes = reader.ReadBytes(len);
            if (bytes[0] != 0)
            {
                return encoding.GetString(bytes);
            }
            return "";
        }

        public static string ToHexString(byte[] bytes, int len)
        {
            return ToHexString(bytes, 0, len);
        }

        public static string ToHexString(byte[] bytes)
        {
            return ToHexString(bytes, 0, bytes.Length);
        }

        public static string ToHexString(byte[] bytes, int start, int len)
        {
            string strReturn = "";
            for (int i = start; i < start + len; i++)
            {
                byte bt = bytes[i];
                strReturn += bt.ToString("x2");
            }
            return strReturn;
        }

        public static byte[] ToByesByHex(string hexStr)
        {
            int len = hexStr.Length;
            byte[] data = new byte[len / 2];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = Convert.ToByte(hexStr.Substring(i * 2, 2), 16);
            }
            return data;
        }

        public void Dispose()
        {
            reader.Dispose();
            memoryStream.Dispose();
        }
    }
}
