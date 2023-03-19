﻿using XCode;
using XCode.Membership;

namespace VehicleVedioManage.BackManagement.Entity
{
    public partial class DriverInfo : Entity<DriverInfo>
    {
        #region 对象操作
        static DriverInfo()
        {
            // 累加字段，生成 Update xx Set Count=Count+1234 Where xxx
            //var df = Meta.Factory.AdditionalFields;
            //df.Add(nameof(VehicleId));

            // 过滤器 UserModule、TimeModule、IPModule
            Meta.Modules.Add<TimeModule>();
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
            //if (isNew && !Dirtys[nameof(CreateTime)]) CreateTime = DateTime.Now;
            //if (!Dirtys[nameof(UpdateTime)]) UpdateTime = DateTime.Now;
        }

        ///// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //protected override void InitData()
        //{
        //    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
        //    if (Meta.Session.Count > 0) return;

        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化DriverInfo[司机信息]数据……");

        //    var entity = new DriverInfo();
        //    entity.CompanyNo = "abc";
        //    entity.VehicleId = 0;
        //    entity.DriverCode = "abc";
        //    entity.DriverName = "abc";
        //    entity.Sex = "abc";
        //    entity.DriverLicence = "abc";
        //    entity.IdentityCard = "abc";
        //    entity.NativePlace = "abc";
        //    entity.Address = "abc";
        //    entity.Telephone = "abc";
        //    entity.MobilePhone = "abc";
        //    entity.Birthday = DateTime.Now;
        //    entity.DrivingType = "abc";
        //    entity.ExamineYear = DateTime.Now;
        //    entity.HarnessesAge = 0;
        //    entity.Status = 0;
        //    entity.Appointment = DateTime.Now;
        //    entity.BaseSalary = 0.0;
        //    entity.RoyaltiesScale = 0.0;
        //    entity.AppraisalIntegral = 0.0;
        //    entity.DriverRFID = "abc";
        //    entity.Password = "abc";
        //    entity.OperatorID = 0;
        //    entity.Register = DateTime.Now;
        //    entity.Remark = "abc";
        //    entity.UpdateTime = DateTime.Now;
        //    entity.LicenseAgency = "abc";
        //    entity.CertificationDate = DateTime.Now;
        //    entity.InvalidDate = DateTime.Now;
        //    entity.Corp = "abc";
        //    entity.MonitorOrg = "abc";
        //    entity.MonitorPhone = "abc";
        //    entity.ServiceLevel = 0;
        //    entity.BgTitle = "abc";
        //    entity.Location = "abc";
        //    entity.PhotoFormat = "abc";
        //    entity.PhotoLength = 0;
        //    entity.Owner = "abc";
        //    entity.JobCard = "abc";
        //    entity.Deleted = true;
        //    entity.CreateTime = DateTime.Now;
        //    entity.TenantId = 0;
        //    entity.MainDriver = 0;
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化DriverInfo[司机信息]数据！");
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
        #endregion

        #region 扩展查询
        /// <summary>根据驾驶员编码查找</summary>
        /// <param name="driverId">驾驶员编码</param>
        /// <returns>实体对象</returns>
        public static DriverInfo FindByDriverId(Int32 driverId)
        {
            if (driverId <= 0) return null;

            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.DriverId == driverId);

            // 单对象缓存
            return Meta.SingleCache[driverId];

            //return Find(_.DriverId == driverId);
        }
        #endregion

        #region 高级查询

        // Select Count(DriverId) as DriverId,Category From DriverInfo Where CreateTime>'2020-01-24 00:00:00' Group By Category Order By DriverId Desc limit 20
        //static readonly FieldCache<DriverInfo> _CategoryCache = new FieldCache<DriverInfo>(nameof(Category))
        //{
        //Where = _.CreateTime > DateTime.Today.AddDays(-30) & Expression.Empty
        //};

        ///// <summary>获取类别列表，字段缓存10分钟，分组统计数据最多的前20种，用于魔方前台下拉选择</summary>
        ///// <returns></returns>
        //public static IDictionary<String, String> GetCategoryList() => _CategoryCache.FindAllName();
        #endregion

        #region 业务操作
        #endregion
    }
}