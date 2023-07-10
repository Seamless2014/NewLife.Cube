using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using NewLife;
using NewLife.Data;
using XCode;
using XCode.Cache;
using XCode.Membership;

namespace VehicleVedioManage.BasicData.Entity
{
    public partial class Vehicle : Entity<Vehicle>
    {
        #region 对象操作
        static Vehicle()
        {
            // 累加字段，生成 Update xx Set Count=Count+1234 Where xxx
            //var df = Meta.Factory.AdditionalFields;
            //df.Add(nameof(ParameterID));

            // 过滤器 UserModule、TimeModule、IPModule
            Meta.Modules.Add<UserModule>();
            Meta.Modules.Add<TimeModule>();
            Meta.Modules.Add<IPModule>();
            // 单对象缓存
            var sc = Meta.SingleCache;
            sc.FindSlaveKeyMethod = k => Find(_.PlateNo == k);
            sc.GetSlaveKeyMethod = e => e.PlateNo;
        }

        /// <summary>验证并修补数据，通过抛出异常的方式提示验证失败。</summary>
        /// <param name="isNew">是否插入</param>
        public override void Valid(Boolean isNew)
        {
            // 如果没有脏数据，则不需要进行任何处理
            if (!HasDirty) return;

            // 建议先调用基类方法，基类方法会做一些统一处理
            base.Valid(isNew);

            // 在新插入数据或者修改了指定字段时进行修正
            // 处理当前已登录用户信息，可以由UserModule过滤器代劳
            /*var user = ManageProvider.User;
            if (user != null)
            {
                if (isNew && !Dirtys[nameof(CreateUserID)]) CreateUserID = user.ID;
                if (!Dirtys[nameof(UpdateUserID)]) UpdateUserID = user.ID;
            }*/
            //if (isNew && !Dirtys[nameof(CreateTime)]) CreateTime = DateTime.Now;
            //if (!Dirtys[nameof(UpdateTime)]) UpdateTime = DateTime.Now;
            //if (isNew && !Dirtys[nameof(CreateIP)]) CreateIP = ManageProvider.UserHost;
            //if (!Dirtys[nameof(UpdateIP)]) UpdateIP = ManageProvider.UserHost;
        }

        ///// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //protected override void InitData()
        //{
        //    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
        //    if (Meta.Session.Count > 0) return;

        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化Vehicle[车辆信息]数据……");

        //    var entity = new Vehicle();
        //    entity.PlateNo = "abc";
        //    entity.ParameterID = 0;
        //    entity.PlateColor = 0;
        //    entity.RunStatus = 0;
        //    entity.Deleted = true;
        //    entity.TenantId = 0;
        //    entity.InstallDate = DateTime.Now;
        //    entity.SimNo = "abc";
        //    entity.Driver = "abc";
        //    entity.DepartmentID = 0;
        //    entity.DepartmentName = "abc";
        //    entity.Region = "abc";
        //    entity.Industry = "abc";
        //    entity.UseType = "abc";
        //    entity.DriverMobile = "abc";
        //    entity.BuyDate = DateTime.Now;
        //    entity.Owner = "abc";
        //    entity.CreateUser = "abc";
        //    entity.CreateUserID = 0;
        //    entity.CreateIP = "abc";
        //    entity.CreateTime = DateTime.Now;
        //    entity.UpdateUser = "abc";
        //    entity.UpdateUserID = 0;
        //    entity.UpdateIP = "abc";
        //    entity.UpdateTime = DateTime.Now;
        //    entity.Remark = "abc";
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化Vehicle[车辆信息]数据！");
        //}

        ///// <summary>已重载。基类先调用Valid(true)验证数据，然后在事务保护内调用OnInsert</summary>
        ///// <returns></returns>
        //public override Int32 Insert()
        //{
        //    return base.Insert();
        //}

        ///// <summary>已重载。在事务保护范围内处理业务，位于Valid之后</summary>
        ///// <returns></returns>
        //protected override Int32 OnDelete()
        //{
        //    return base.OnDelete();
        //}
        #endregion

        #region 扩展属性
        /// <summary>部门</summary>
        [XmlIgnore, IgnoreDataMember]
        //[ScriptIgnore]
        public Department _Department => Extends.Get(nameof(Department), k => Department.FindByID(DepartmentID));

        /// <summary>企业名称</summary>
        [Map(nameof(DepartmentID), typeof(Department), "ID")]
        [BindColumn("DepartmentName", "企业名称", "nvarchar(50)")]
        public String DepartmentName => _Department?.Name;

        /// <summary>行业类型</summary>
        [XmlIgnore, IgnoreDataMember]
        //[ScriptIgnore]
        public IndustryType _IndustryType => Extends.Get(nameof(IndustryType), k => IndustryType.FindByID(Industry));

        /// <summary>行业类型名称</summary>
        [Map(nameof(Industry), typeof(IndustryType), "ID")]
        public String IndustryTypeName => _IndustryType?.Description;

        /// <summary>车牌颜色</summary>
        [XmlIgnore, IgnoreDataMember]
        //[ScriptIgnore]
        public PlateColor __PlateColor => Extends.Get(nameof(PlateColor), k => PlateColor.FindByCode(PlateColorCode));

        /// <summary>车牌颜色名称</summary>
        [Map(nameof(PlateColorCode), typeof(PlateColor), "Code")]
        public String PlateColorName => __PlateColor?.Name;

        /// <summary>车辆类型</summary>
        [XmlIgnore, IgnoreDataMember]
        //[ScriptIgnore]
        public VehicleType __VehicleType => Extends.Get(nameof(VehicleType), k => VehicleType.FindByCode(VehicleTypeCode));

        /// <summary>车辆类型名称</summary>
        [Map(nameof(VehicleTypeCode), typeof(VehicleType), "Code")]
        public String VehicleTypeName => __VehicleType?.Name;

        /// <summary>运营状态</summary>
        [XmlIgnore, IgnoreDataMember]
        //[ScriptIgnore]
        public RunStatus __RunStatus => Extends.Get(nameof(RunStatus), k => RunStatus.FindByID(RunStatusID));

        /// <summary>运营状态名称</summary>
        [Map(nameof(RunStatusID), typeof(RunStatus), "ID")]
        public String RunStatusName => __RunStatus?.Name;

        /// <summary>使用性质</summary>
        [XmlIgnore, IgnoreDataMember]
        //[ScriptIgnore]
        public UseType _UserTypeCode => Extends.Get(nameof(UseType), k => UseType.FindByID(UseTypeCode));
        /// <summary>使用性质名称</summary>
        [Map(nameof(UseTypeCode), typeof(UseType), "ID")]
        public String UseTypeName => _UserTypeCode?.Name;
        #endregion

        #region 扩展查询
        /// <summary>根据车辆编号查找</summary>
        /// <param name="vehicleId">车辆编号</param>
        /// <returns>实体对象</returns>
        public static Vehicle FindByID(Int32 vehicleId)
        {
            if (vehicleId <= 0) return null;

            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.ID == vehicleId);

            // 单对象缓存
            return Meta.SingleCache[vehicleId];

            //return Find(_.VehicleID == vehicleId);
        }

        /// <summary>根据车牌号查找</summary>
        /// <param name="plateNo">车牌号</param>
        /// <returns>实体列表</returns>
        public static IList<Vehicle> FindAllByPlateNo(String plateNo)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e => e.PlateNo.EqualIgnoreCase(plateNo)&&e.Deleted==false);

            return FindAll(_.PlateNo == plateNo);
        }

        /// <summary>根据deleted查找</summary>
        /// <param name="deleted">是否删除</param>
        /// <returns>实体对象</returns>
        public static IList<Vehicle> FindByDeleted(bool isDeleted)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e => e.Deleted == isDeleted);

            // 单对象缓存
            //return Meta.SingleCache[id];

            return FindAll(_.Deleted == isDeleted);
        }
        /// <summary>根据车牌号查找</summary>
        /// <param name="plateNo">车牌号</param>
        /// <returns>实体对象</returns>
        public static Vehicle FindByPlateNo(String plateNo)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.PlateNo.EqualIgnoreCase(plateNo));

            // 单对象缓存
            //return Meta.SingleCache.GetItemWithSlaveKey(plateNo) as Vehicle;

            return Find(_.PlateNo == plateNo);
        }

        /// <summary>根据部门名称、车牌号查找</summary>
        /// <param name="departmentName">部门名称</param>
        /// <param name="plateNo">车牌号</param>
        /// <returns>实体列表</returns>
        public static IList<Vehicle> FindAllByDepartmentNameAndPlateNo(String departmentName, String plateNo)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e => e.DepartmentName.EqualIgnoreCase(departmentName) && e.PlateNo.EqualIgnoreCase(plateNo));

            return FindAll(_.DepartmentName == departmentName & _.PlateNo == plateNo);
        }

        /// <summary>根据Sim卡号查找</summary>
        /// <param name="simNo">Sim卡号</param>
        /// <returns>实体列表</returns>
        public static IList<Vehicle> FindAllBySimNo(String simNo)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e => e.SimNo.EqualIgnoreCase(simNo));

            return FindAll(_.SimNo == simNo);
        }
        /// <summary>根据Sim卡号查找</summary>
        /// <param name="simNo">Sim卡号</param>
        /// <returns>实体列表</returns>
        public static IList<Vehicle> FindAll()
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e => e.Deleted==false);

            return FindAll(_.Deleted == false);
        }
        #endregion

        #region 高级查询
        /// <summary>高级查询</summary>
        /// <param name="plateNo">车牌号</param>
        /// <param name="start">更新时间开始</param>
        /// <param name="end">更新时间结束</param>
        /// <param name="key">关键字</param>
        /// <param name="page">分页参数信息。可携带统计和数据权限扩展查询等信息</param>
        /// <returns>实体列表</returns>
        public static IList<Vehicle> Search(String plateNo, DateTime start, DateTime end, String key, PageParameter page)
        {
            var exp = new WhereExpression();

            if (!plateNo.IsNullOrEmpty()) exp &= _.PlateNo == plateNo;
            exp &= _.UpdateTime.Between(start, end);
            exp &= _.Deleted == false;
            if (!key.IsNullOrEmpty()) exp &= _.PlateNo.Contains(key) | _.SimNo.Contains(key) | _.Driver.Contains(key) | _.DepartmentName.Contains(key) | _.Region.Contains(key) | _.DriverMobile.Contains(key) | _.Owner.Contains(key) | _.CreateUser.Contains(key) | _.CreateIP.Contains(key) | _.UpdateUser.Contains(key) | _.UpdateIP.Contains(key) | _.Remark.Contains(key);

            return FindAll(exp, page);
        }
        /// <summary>
        /// 高级查询
        /// </summary>
        /// <param name="plateNo"></param>
        /// <param name="plateColorCode"></param>
        /// <param name="runStatusCode"></param>
        /// <param name="vehicleTypeCode"></param>
        /// <param name="key"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static IList<Vehicle> Search(String VehicleID, string plateColorCode, string runStatusCode,string vehicleTypeCode, string areaID, String key, PageParameter page)
        {
            var exp = new WhereExpression();

            if (!VehicleID.IsNullOrEmpty()) exp &= _.ID == VehicleID;
            if (!plateColorCode.IsNullOrEmpty()) exp &= _.PlateColorCode == plateColorCode;
            if (!runStatusCode.IsNullOrEmpty()) exp &= _.RunStatusID == runStatusCode;
            if (!vehicleTypeCode.IsNullOrEmpty()) exp &= _.VehicleTypeCode == vehicleTypeCode;
            if(!areaID.IsNullOrEmpty()) exp&=_.Region==areaID;  
            exp &= _.Deleted == false;
            if (!key.IsNullOrEmpty()) exp &= _.PlateNo.Contains(key) | _.SimNo.Contains(key) | _.Driver.Contains(key) | _.DriverMobile.Contains(key) | _.Owner.Contains(key) | _.CreateUser.Contains(key) | _.CreateIP.Contains(key) | _.UpdateUser.Contains(key) | _.UpdateIP.Contains(key) | _.Remark.Contains(key);

            return FindAll(exp, page);
        }
        /// <summary>
        /// 下拉车辆查询
        /// </summary>
        /// <param name="vehicleIds"></param>
        /// <param name="enable"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="key"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static IList<Vehicle> Search(IList<Int32> vehicleIds,Boolean? enable, DateTime start, DateTime end, String key, PageParameter page)
        {
            var exp = new WhereExpression();
            if (vehicleIds != null && vehicleIds.Count > 0) exp &= _.ID.In(vehicleIds);
            if (enable != null) exp &= _.Deleted == enable;
            exp &= _.UpdateTime.Between(start, end);
            if (!key.IsNullOrEmpty()) exp &= _.PlateNo.Contains(key) | _.SimNo.Contains(key) | _.Driver.Contains(key);
            return FindAll(exp, page);
        }


        // Select Count(VehicleID) as VehicleID,PlateNo From Vehicle Where CreateTime>'2020-01-24 00:00:00' Group By PlateNo Order By VehicleID Desc limit 20
        static readonly FieldCache<Vehicle> _PlateNoCache = new FieldCache<Vehicle>(nameof(PlateNo))
        {
            //Where = _.CreateTime > DateTime.Today.AddDays(-30) & Expression.Empty
        };

        /// <summary>获取车牌号列表，字段缓存10分钟，分组统计数据最多的前20种，用于魔方前台下拉选择</summary>
        /// <returns></returns>
        public static IDictionary<String, String> GetPlateNoList() => _PlateNoCache.FindAllName();
        /// <summary>高级查询</summary>
        /// <param name="plateNo">车牌号</param>
        /// <param name="simNo">Sim卡号</param>
        /// <param name="departmentName">部门名称</param>
        /// <param name="start">更新时间开始</param>
        /// <param name="end">更新时间结束</param>
        /// <param name="key">关键字</param>
        /// <param name="page">分页参数信息。可携带统计和数据权限扩展查询等信息</param>
        /// <returns>实体列表</returns>
        public static IList<Vehicle> Search(String plateNo, String simNo, String departmentName, DateTime start, DateTime end, String key, PageParameter page)
        {
            var exp = new WhereExpression();

            if (!plateNo.IsNullOrEmpty()) exp &= _.PlateNo == plateNo;
            if (!simNo.IsNullOrEmpty()) exp &= _.SimNo == simNo;
            if (!departmentName.IsNullOrEmpty()) exp &= _.DepartmentName == departmentName;
            exp &= _.UpdateTime.Between(start, end);
            if (!key.IsNullOrEmpty()) exp &= _.PlateNo.Contains(key) | _.SimNo.Contains(key) | _.Driver.Contains(key) | _.DepartmentName.Contains(key) | _.Region.Contains(key) | _.Industry.Contains(key) | _.UseType.Contains(key) | _.PlateformId.Contains(key) | _.TerminalId.Contains(key) | _.TerminalModel.Contains(key) | _.TerminalVendorId.Contains(key) | _.DriverMobile.Contains(key) | _.Owner.Contains(key) | _.CreateUser.Contains(key) | _.CreateIP.Contains(key) | _.UpdateUser.Contains(key) | _.UpdateIP.Contains(key) | _.Remark.Contains(key) | _.UseTypeCode.Contains(key);

            return FindAll(exp, page);
        }

        // Select Count(ID) as ID,DepartmentName From Vehicle Where CreateTime>'2020-01-24 00:00:00' Group By DepartmentName Order By ID Desc limit 20
        static readonly FieldCache<Vehicle> _DepartmentNameCache = new FieldCache<Vehicle>(nameof(DepartmentName))
        {
            //Where = _.CreateTime > DateTime.Today.AddDays(-30) & Expression.Empty
        };

        /// <summary>获取部门名称列表，字段缓存10分钟，分组统计数据最多的前20种，用于魔方前台下拉选择</summary>
        /// <returns></returns>
        public static IDictionary<String, String> GetDepartmentNameList() => _DepartmentNameCache.FindAllName();

        // Select Count(ID) as ID,SimNo From Vehicle Where CreateTime>'2020-01-24 00:00:00' Group By SimNo Order By ID Desc limit 20
        static readonly FieldCache<Vehicle> _SimNoCache = new FieldCache<Vehicle>(nameof(SimNo))
        {
            //Where = _.CreateTime > DateTime.Today.AddDays(-30) & Expression.Empty
        };

        /// <summary>获取Sim卡号列表，字段缓存10分钟，分组统计数据最多的前20种，用于魔方前台下拉选择</summary>
        /// <returns></returns>
        public static IDictionary<String, String> GetSimNoList() => _SimNoCache.FindAllName();
        #endregion

        #region 业务操作
        #endregion
    }
}