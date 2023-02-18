using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using NewLife;
using NewLife.Data;
using NewLife.Log;
using NewLife.Model;
using NewLife.Reflection;
using NewLife.Threading;
using NewLife.Web;
using XCode;
using XCode.Cache;
using XCode.Configuration;
using XCode.DataAccessLayer;
using XCode.Membership;
using XCode.Shards;

namespace NewLife.BasicData.Entity
{
    public partial class Vehicle : Entity<Vehicle>
    {
        #region 对象操作
        static Vehicle()
        {
            // 累加字段，生成 Update xx Set Count=Count+1234 Where xxx
            //var df = Meta.Factory.AdditionalFields;
            //df.Add(nameof(tenantId));

            // 过滤器 UserModule、TimeModule、IPModule
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
        }

        ///// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //protected override void InitData()
        //{
        //    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
        //    if (Meta.Session.Count > 0) return;

        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化Vehicle[Vehicle]数据……");

        //    var entity = new Vehicle();
        //    entity.plateNo = "abc";
        //    entity.vehicleType = "abc";
        //    entity.plateColor = "abc";
        //    entity.Monitor = "abc";
        //    entity.Driver = "abc";
        //    entity.Status = "abc";
        //    entity.runStatus = "abc";
        //    entity.Total = 0.0;
        //    entity.Remain = 0.0;
        //    entity.Deleted = true;
        //    entity.CreateDate = DateTime.Now;
        //    entity.tenantId = 0;
        //    entity.gpsId = "abc";
        //    entity.VideoDeviceId = "abc";
        //    entity.SortId = 0;
        //    entity.VehicleDeviceType = "abc";
        //    entity.DvrOnline = true;
        //    entity.MotorID = "abc";
        //    entity.installDate = DateTime.Now;
        //    entity.simNo = "abc";
        //    entity.DVRCard = "abc";
        //    entity.DriverMobile = "abc";
        //    entity.MonitorMobile = "abc";
        //    entity.vehColor = "abc";
        //    entity.operPermit = "abc";
        //    entity.LastCheckTime = DateTime.Now;
        //    entity.buyDate = DateTime.Now;
        //    entity.OnlineTime = DateTime.Now;
        //    entity.OfflineTime = DateTime.Now;
        //    entity.Vendor = "abc";
        //    entity.factoryNo = "abc";
        //    entity.Owner = "abc";
        //    entity.Remark = "abc";
        //    entity.depId = 0;
        //    entity.gpsTerminalType = "abc";
        //    entity.useType = "abc";
        //    entity.Industry = "abc";
        //    entity.Routes = "abc";
        //    entity.Region = "abc";
        //    entity.termId = 0;
        //    entity.buyTime = DateTime.Now;
        //    entity.memberId = 0;
        //    entity.endDate = DateTime.Now;
        //    entity.startDate = DateTime.Now;
        //    entity.Type = "abc";
        //    entity.Unit = "abc";
        //    entity.Weight = 0.0;
        //    entity.Authorize = true;
        //    entity.depName = "abc";
        //    entity.Password = "abc";
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化Vehicle[Vehicle]数据！");
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
        /// <summary>根据vehicleId查找</summary>
        /// <param name="vehicleId">vehicleId</param>
        /// <returns>实体对象</returns>
        public static Vehicle FindByvehicleId(Int32 vehicleId)
        {
            if (vehicleId <= 0) return null;

            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.vehicleId == vehicleId);

            // 单对象缓存
            return Meta.SingleCache[vehicleId];

            //return Find(_.vehicleId == vehicleId);
        }
        #endregion

        #region 高级查询

        // Select Count(vehicleId) as vehicleId,Category From Vehicle Where CreateTime>'2020-01-24 00:00:00' Group By Category Order By vehicleId Desc limit 20
        //static readonly FieldCache<Vehicle> _CategoryCache = new FieldCache<Vehicle>(nameof(Category))
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