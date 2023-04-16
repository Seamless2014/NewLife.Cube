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

namespace VehicleVedioManage.BackManagement.Entity
{
    public partial class TerminalParam : Entity<TerminalParam>
    {
        #region 对象操作
        static TerminalParam()
        {
            // 累加字段，生成 Update xx Set Count=Count+1234 Where xxx
            //var df = Meta.Factory.AdditionalFields;
            //df.Add(nameof(SN));

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

            // 检查唯一索引
            // CheckExist(isNew, nameof(PlateNo));
        }

        ///// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //protected override void InitData()
        //{
        //    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
        //    if (Meta.Session.Count > 0) return;

        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化TerminalParam[终端参数]数据……");

        //    var entity = new TerminalParam();
        //    entity.SimNo = "abc";
        //    entity.PlateNo = "abc";
        //    entity.Code = "abc";
        //    entity.Value = "abc";
        //    entity.FieldType = "abc";
        //    entity.CreateDate = DateTime.Now;
        //    entity.UpdateDate = DateTime.Now;
        //    entity.Status = "abc";
        //    entity.SN = 0;
        //    entity.TenantId = 0;
        //    entity.Deleted = true;
        //    entity.Owner = "abc";
        //    entity.Remark = "abc";
        //    entity.CommandId = 0;
        //    entity.GPSId = "abc";
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化TerminalParam[终端参数]数据！");
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
        /// <summary>根据参数编码查找</summary>
        /// <param name="paramId">参数编码</param>
        /// <returns>实体对象</returns>
        public static TerminalParam FindByParamId(Int32 paramId)
        {
            if (paramId <= 0) return null;

            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.ParamId == paramId);

            // 单对象缓存
            return Meta.SingleCache[paramId];

            //return Find(_.ParamId == paramId);
        }

        /// <summary>根据车牌号查找</summary>
        /// <param name="plateNo">车牌号</param>
        /// <returns>实体对象</returns>
        public static TerminalParam FindByPlateNo(String plateNo)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.PlateNo.EqualIgnoreCase(plateNo));

            return Find(_.PlateNo == plateNo);
        }

        /// <summary>根据Sim卡查找</summary>
        /// <param name="simNo">Sim卡</param>
        /// <returns>实体列表</returns>
        public static IList<TerminalParam> FindAllBySimNo(String simNo)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e => e.SimNo.EqualIgnoreCase(simNo));

            return FindAll(_.SimNo == simNo);
        }
        #endregion

        #region 高级查询
        /// <summary>高级查询</summary>
        /// <param name="simNo">Sim卡</param>
        /// <param name="plateNo">车牌号</param>
        /// <param name="key">关键字</param>
        /// <param name="page">分页参数信息。可携带统计和数据权限扩展查询等信息</param>
        /// <returns>实体列表</returns>
        public static IList<TerminalParam> Search(String simNo, String plateNo, String key, PageParameter page)
        {
            var exp = new WhereExpression();

            if (!simNo.IsNullOrEmpty()) exp &= _.SimNo == simNo;
            if (!plateNo.IsNullOrEmpty()) exp &= _.PlateNo == plateNo;
            if (!key.IsNullOrEmpty()) exp &= _.SimNo.Contains(key) | _.PlateNo.Contains(key) | _.Code.Contains(key) | _.Value.Contains(key) | _.FieldType.Contains(key) | _.Status.Contains(key) | _.Owner.Contains(key) | _.Remark.Contains(key) | _.GPSId.Contains(key);

            return FindAll(exp, page);
        }

        // Select Count(ParamId) as ParamId,SimNo From TerminalParam Where CreateTime>'2020-01-24 00:00:00' Group By SimNo Order By ParamId Desc limit 20
        static readonly FieldCache<TerminalParam> _SimNoCache = new FieldCache<TerminalParam>(nameof(SimNo))
        {
            //Where = _.CreateTime > DateTime.Today.AddDays(-30) & Expression.Empty
        };

        /// <summary>获取Sim卡列表，字段缓存10分钟，分组统计数据最多的前20种，用于魔方前台下拉选择</summary>
        /// <returns></returns>
        public static IDictionary<String, String> GetSimNoList() => _SimNoCache.FindAllName();
        #endregion

        #region 业务操作
        #endregion
    }
}