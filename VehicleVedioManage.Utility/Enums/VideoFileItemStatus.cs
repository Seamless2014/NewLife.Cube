using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleVedioManage.Utility.Enums
{
    /// <summary>
    /// 视频文件状态
    /// </summary>
    public enum VideoFileItemStatus
    {
        /// <summary>
        /// 不上传
        /// </summary>
        [Description("不上传")]
        NOT_UPLOAD,
        /// <summary>
        /// 上传完成
        /// </summary>
        [Description("上传完成")]
        UPLOAD_COMPLTETED,
        /// <summary>
        /// 上传中
        /// </summary>
        [Description("上传中")]
        UPLOADING,
        /// <summary>
        /// 离线
        /// </summary>
        [Description("离线")]
        OFFLINE,
        /// <summary>
        /// 停止录像
        /// </summary>
        [Description("停止录像")]
        STOP_RECORD,
        /// <summary>
        /// ftp
        /// </summary>
        [Description("ftp")]
        FTP,
        /// <summary>
        /// 终端
        /// </summary>
        [Description("来自终端")]
        TERMINAL,
        /// <summary>
        /// 用户录像
        /// </summary>
        [Description("用户录像")]
        USER_RECORDER,
        /// <summary>
        /// 服务器录像
        /// </summary>
        [Description("服务器录像")]
        SERVER_RECORDER,
    }
}
