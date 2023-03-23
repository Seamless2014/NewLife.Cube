namespace VehicleVedioManage.Common
{
    /// <summary>
    /// 车辆信息
    /// </summary>
    public class VehicleInformation : IComparable
    {
        /// <summary>
        /// 车牌号
        /// </summary>
        public string _plateNo { get; set; }
        /// <summary>
        /// 驾驶员
        /// </summary>
        public string _driver { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime _operatetime { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        public string _location { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public float _longitude { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public float _latitude { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string _type { get; set; }

        #region IComparable 成员
        /// <summary>
        /// 比较
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            var vi = (VehicleInformation)obj;
            return _operatetime.CompareTo(vi._operatetime);
        }

        #endregion
    }
}
