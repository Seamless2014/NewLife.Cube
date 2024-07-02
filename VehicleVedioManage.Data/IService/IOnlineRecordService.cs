using System.Collections;
using VehicleVedioManage.Data.Entity;

namespace VehicleVedioManage.Data.IService
{
    /// <summary>
    /// 上线记录服务
    /// </summary>
    public interface IOnlineRecordService
    {
        /// <summary>
        /// 报警配置映射
        /// </summary>
        Hashtable alarmConfigMap { get; set; }
        /// <summary>
        /// 核查是否在线
        /// </summary>
        /// <param name="rd"></param>
        void checkOnline(GPSRealData rd);
        /// <summary>
        /// 停止服务
        /// </summary>
        void Stop();
    }
}
