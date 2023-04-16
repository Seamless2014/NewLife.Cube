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

namespace VehicleVedioManage.ReportStatistics.Entity
{
    public partial class FuelConsumption : Entity<FuelConsumption>
    {
        #region 对象操作
        static FuelConsumption()
        {
            // 累加字段，生成 Update xx Set Count=Count+1234 Where xxx
            //var df = Meta.Factory.AdditionalFields;
            //df.Add(nameof(IntervalType));

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
            // 货币保留6位小数
            Fuel = Math.Round(Fuel, 6);
            Mileage = Math.Round(Mileage, 6);
            Gas1 = Math.Round(Gas1, 6);
            Mileage1 = Math.Round(Mileage1, 6);
            Gas2 = Math.Round(Gas2, 6);
            Mileage2 = Math.Round(Mileage2, 6);
            Gas = Math.Round(Gas, 6);
            Oil = Math.Round(Oil, 6);
            Oil1 = Math.Round(Oil1, 6);
            Oil2 = Math.Round(Oil2, 6);
            //if (isNew && !Dirtys[nameof(CreateTime)]) CreateTime = DateTime.Now;
        }

        ///// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //protected override void InitData()
        //{
        //    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
        //    if (Meta.Session.Count > 0) return;

        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化FuelConsumption[燃料消费]数据……");

        //    var entity = new FuelConsumption();
        //    entity.PlateNo = "abc";
        //    entity.IntervalDescr = "abc";
        //    entity.Hour = 0.0;
        //    entity.StatisticsDate = DateTime.Now;
        //    entity.Fuel = 0.0;
        //    entity.IntervalType = 0;
        //    entity.Mileage = 0.0;
        //    entity.Gas1 = 0.0;
        //    entity.Mileage1 = 0.0;
        //    entity.Gas2 = 0.0;
        //    entity.Mileage2 = 0.0;
        //    entity.Gas = 0.0;
        //    entity.Deleted = "abc";
        //    entity.TenantId = 0;
        //    entity.Remark = "abc";
        //    entity.Owner = "abc";
        //    entity.CreateTime = DateTime.Now;
        //    entity.Oil = 0.0;
        //    entity.Oil1 = 0.0;
        //    entity.Oil2 = 0.0;
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化FuelConsumption[燃料消费]数据！");
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
        /// <summary>根据燃料消耗量编码查找</summary>
        /// <param name="id">燃料消耗量编码</param>
        /// <returns>实体对象</returns>
        public static FuelConsumption FindByID(Int32 id)
        {
            if (id <= 0) return null;

            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.ID == id);

            // 单对象缓存
            return Meta.SingleCache[id];

            //return Find(_.ID == id);
        }
        /// <summary>根据车牌号查找</summary>
        /// <param name="plateNo">车牌号</param>
        /// <returns>实体对象</returns>
        public static FuelConsumption FindByPlateNo(String plateNo)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.PlateNo.EqualIgnoreCase(plateNo));

            return Find(_.PlateNo == plateNo);
        }
        #endregion

        #region 高级查询
        /// <summary>高级查询</summary>
        /// <param name="plateNo">车牌号</param>
        /// <param name="start">创建时间开始</param>
        /// <param name="end">创建时间结束</param>
        /// <param name="key">关键字</param>
        /// <param name="page">分页参数信息。可携带统计和数据权限扩展查询等信息</param>
        /// <returns>实体列表</returns>
        public static IList<FuelConsumption> Search(String plateNo, DateTime start, DateTime end, String key, PageParameter page)
        {
            var exp = new WhereExpression();

            if (!plateNo.IsNullOrEmpty()) exp &= _.PlateNo == plateNo;
            exp &= _.CreateTime.Between(start, end);
            if (!key.IsNullOrEmpty()) exp &= _.PlateNo.Contains(key) | _.IntervalDescr.Contains(key) | _.Deleted.Contains(key) | _.Remark.Contains(key) | _.Owner.Contains(key);

            return FindAll(exp, page);
        }
        // Select Count(ID) as ID,Category From FuelConsumption Where CreateTime>'2020-01-24 00:00:00' Group By Category Order By ID Desc limit 20
        //static readonly FieldCache<FuelConsumption> _CategoryCache = new FieldCache<FuelConsumption>(nameof(Category))
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