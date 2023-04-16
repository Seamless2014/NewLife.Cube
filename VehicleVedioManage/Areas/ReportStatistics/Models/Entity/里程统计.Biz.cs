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
    public partial class MileageStatistic : Entity<MileageStatistic>
    {
        #region 对象操作
        static MileageStatistic()
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
            //if (isNew && !Dirtys[nameof(CreateTime)]) CreateTime = DateTime.Now;
        }

        ///// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //protected override void InitData()
        //{
        //    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
        //    if (Meta.Session.Count > 0) return;

        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化MileageStatistic[里程统计]数据……");

        //    var entity = new MileageStatistic();
        //    entity.PlateNo = "abc";
        //    entity.IntervalDescr = "abc";
        //    entity.Hour = 0.0;
        //    entity.StaticDate = DateTime.Now;
        //    entity.IntervalType = 0;
        //    entity.Mileage = 0.0;
        //    entity.Oil = 0.0;
        //    entity.Oil1 = 0.0;
        //    entity.Oil2 = 0.0;
        //    entity.Mileage1 = 0.0;
        //    entity.Mileage2 = 0.0;
        //    entity.DepName = "abc";
        //    entity.TenantId = 0;
        //    entity.CreateTime = DateTime.Now;
        //    entity.Remark = "abc";
        //    entity.Deleted = true;
        //    entity.Owner = "abc";
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化MileageStatistic[里程统计]数据！");
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
        /// <summary>根据功能编码查找</summary>
        /// <param name="functionId">功能编码</param>
        /// <returns>实体对象</returns>
        public static MileageStatistic FindByFunctionId(Int32 functionId)
        {
            if (functionId <= 0) return null;

            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.FunctionId == functionId);

            // 单对象缓存
            return Meta.SingleCache[functionId];

            //return Find(_.FunctionId == functionId);
        }
        /// <summary>根据车牌号查找</summary>
        /// <param name="plateNo">车牌号</param>
        /// <returns>实体对象</returns>
        public static MileageStatistic FindByPlateNo(String plateNo)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.PlateNo.EqualIgnoreCase(plateNo));

            return Find(_.PlateNo == plateNo);
        }

        /// <summary>根据部门名称、车牌号查找</summary>
        /// <param name="depName">部门名称</param>
        /// <param name="plateNo">车牌号</param>
        /// <returns>实体列表</returns>
        public static IList<MileageStatistic> FindAllByDepNameAndPlateNo(String depName, String plateNo)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e => e.DepName.EqualIgnoreCase(depName) && e.PlateNo.EqualIgnoreCase(plateNo));

            return FindAll(_.DepName == depName & _.PlateNo == plateNo);
        }
        #endregion

        #region 高级查询
        /// <summary>高级查询</summary>
        /// <param name="plateNo">车牌号</param>
        /// <param name="depName">部门名称</param>
        /// <param name="start">创建时间开始</param>
        /// <param name="end">创建时间结束</param>
        /// <param name="key">关键字</param>
        /// <param name="page">分页参数信息。可携带统计和数据权限扩展查询等信息</param>
        /// <returns>实体列表</returns>
        public static IList<MileageStatistic> Search(String plateNo, String depName, DateTime start, DateTime end, String key, PageParameter page)
        {
            var exp = new WhereExpression();

            if (!plateNo.IsNullOrEmpty()) exp &= _.PlateNo == plateNo;
            if (!depName.IsNullOrEmpty()) exp &= _.DepName == depName;
            exp &= _.CreateTime.Between(start, end);
            if (!key.IsNullOrEmpty()) exp &= _.PlateNo.Contains(key) | _.IntervalDescr.Contains(key) | _.DepName.Contains(key) | _.Remark.Contains(key) | _.Owner.Contains(key);

            return FindAll(exp, page);
        }

        // Select Count(FunctionId) as FunctionId,DepName From MileageStatistic Where CreateTime>'2020-01-24 00:00:00' Group By DepName Order By FunctionId Desc limit 20
        static readonly FieldCache<MileageStatistic> _DepNameCache = new FieldCache<MileageStatistic>(nameof(DepName))
        {
            //Where = _.CreateTime > DateTime.Today.AddDays(-30) & Expression.Empty
        };

        /// <summary>获取部门名称列表，字段缓存10分钟，分组统计数据最多的前20种，用于魔方前台下拉选择</summary>
        /// <returns></returns>
        public static IDictionary<String, String> GetDepNameList() => _DepNameCache.FindAllName();
        #endregion

        #region 业务操作
        #endregion
    }
}