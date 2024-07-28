using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleVedioManage.Utility.Enums;

namespace VehicleVideoManage.Video.ViewModel
{
    /// <summary>
	/// 树状节点
	/// </summary>
	public class VTreeNode
    {
        /// <summary>
        /// 名字
        /// </summary>
        public string name
        {
            get;
            set;
        }
        /// <summary>
        /// 状态
        /// </summary>
        public string state
        {
            get;
            set;
        }
        /// <summary>
        /// sim卡号
        /// </summary>
        public string simNo
        {
            get;
            set;
        }
        /// <summary>
        /// 车辆id
        /// </summary>
        public int vehicleId
        {
            get;
            set;
        }
        /// <summary>
        /// 通道号
        /// </summary>
        public int channelId
        {
            get;
            set;
        }
        /// <summary>
        /// 设备号
        /// </summary>
        public string deviceId
        {
            get;
            set;
        }
        /// <summary>
        /// 父设备号
        /// </summary>
        public string parentDeviceId
        {
            get;
            set;
        }
        /// <summary>
        /// 节点类型
        /// </summary>
        public string nodeType
        {
            get;
            set;
        }
        /// <summary>
        /// 子节点
        /// </summary>
        public List<VTreeNode> children
        {
            get;
            set;
        }
        /// <summary>
        /// 是否通道
        /// </summary>
        /// <returns></returns>
        public bool IsChannel()
        {
            return VTreeNodeType.CAMERA.ToString() == nodeType;
        }
    }
}
