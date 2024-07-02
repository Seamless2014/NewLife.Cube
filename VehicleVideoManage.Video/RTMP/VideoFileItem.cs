using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleVideoManage.Video.RTMP
{
    /// <summary>
    /// 视频文件项
    /// </summary>
    [Serializable]
    public class VideoFileItem
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
        /// 服务器录录像
        /// </summary>
        public static string FROM_SERVER = "server_recorder";
        /// <summary>
        /// 实体id
        /// </summary>
        public int EntityId
        {
            get;
            set;
        }
        /// <summary>
        /// 命令id
        /// </summary>
        public int CommandId
        {
            get;
            set;
        }
        /// <summary>
        /// 车辆id
        /// </summary>
        public int VehicleId
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
        public byte ChannelId
        {
            get;
            set;
        }
        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime? StartDate
        {
            get;
            set;
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndDate
        {
            get;
            set;
        }
        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime? UploadDate
        {
            get;
            set;
        }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status
        {
            get;
            set;
        }
        /// <summary>
        /// 文件源
        /// </summary>
        public string FileSource
        {
            get;
            set;
        }
        /// <summary>
        /// 文件路径
        /// </summary>
        public string FilePath
        {
            get;
            set;
        }
        /// <summary>
        /// 文件长度
        /// </summary>
        public string FileLength
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
        /// 视频文件项
        /// </summary>
        public VideoFileItem()
        {
            CreateDate = DateTime.Now;
            FileSource = FROM_TERMINAL;
            Status = STATUS_NOT_UPLOAD;
            UploadDate = DateTime.Now;
        }
    }
}
