using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleVedioManage.Utility.Extends
{
    public class VideoFileItemExtendcs
    {
        /// <summary>
		/// 不上传
		/// </summary>
		public static string STATUS_NOT_UPLOAD = "not_upload";
        /// <summary>
        /// 上传完成
        /// </summary>
        public static string STATUS_UPLOAD_COMPLTETED = "upload_completed";
        /// <summary>
        /// 上传中
        /// </summary>
        public static string STATUS_UPLOADING = "uploading";
        /// <summary>
        /// 离线
        /// </summary>
        public static string STATUS_OFFLINE = "offline";
        /// <summary>
        /// 停止录像
        /// </summary>
        public static string STATUS_STOP_RECORD = "stop_record";
        /// <summary>
        /// ftp
        /// </summary>
        public static string FROM_FTP = "ftp";
        /// <summary>
        /// 终端
        /// </summary>
        public static string FROM_TERMINAL = "terminal";
        /// <summary>
        /// 用户录像
        /// </summary>
        public static string FROM_USER = "user_recorder";
        /// <summary>
        /// 服务器录像
        /// </summary>
        public static string FROM_SERVER = "server_recorder";
    }
}
