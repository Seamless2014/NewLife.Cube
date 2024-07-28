using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleVedioManage.Utility.Enums
{
    /// <summary>
    /// 树状节点类型
    /// </summary>
    public enum VTreeNodeType
    {
        /// <summary>
        /// 组织
        /// </summary>
        [Description("组织")]
        ORGNIZATION,
        /// <summary>
        /// 车辆
        /// </summary>
        [Description("车辆")]
        VEHICLE,
        /// <summary>
        /// 摄像头
        /// </summary>
        [Description("摄像头")]
        CAMERA,
    }
}
