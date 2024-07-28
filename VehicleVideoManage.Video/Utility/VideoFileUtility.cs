using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewLife.Log;

namespace VehicleVideoManage.Video.Utility
{
    /// <summary>
    /// 视频文件操作
    /// </summary>
    public class VideoFileUtility
    {
        private FileStream audioFileStream = null;
        private readonly ITracer tracer;
        public VideoFileUtility() { }
        public VideoFileUtility(ITracer _tracer)
        {
            tracer = _tracer;
        }

        public void saveStreamToFile(string audioFileName, byte[] data, int len, int start = 0)
        {
            try
            {
                if (audioFileStream == null)
                {
                    string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\" + audioFileName;
                    audioFileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write);
                }
                audioFileStream.Write(data, start, len);
            }
            catch (Exception ex)
            {
                tracer.NewError(ex.Message, ex);
            }
            finally
            {
            }
        }

        public void Close()
        {
            try
            {
                if (audioFileStream != null)
                {
                    audioFileStream.Close();
                }
            }
            catch (Exception ex)
            {
                tracer.NewError(ex.Message, ex);
            }
        }
    }
}
