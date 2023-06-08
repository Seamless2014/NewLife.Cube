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
using PlateColor = VehicleVedioManage.BasicData.Entity.PlateColor;

namespace VehicleVedioManage.BackManagement.Entity
{
    public partial class JT809Command : Entity<JT809Command>
    {
        #region 对象操作
        static JT809Command()
        {
            // 累加字段，生成 Update xx Set Count=Count+1234 Where xxx
            //var df = Meta.Factory.AdditionalFields;
            //df.Add(nameof(Cmd));

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

        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化JT809Command[809指令]数据……");

        //    var entity = new JT809Command();
        //    entity.SimNo = "abc";
        //    entity.PlateNo = "abc";
        //    entity.Descr = "abc";
        //    entity.Cmd = 0;
        //    entity.CmdData = "abc";
        //    entity.CreateTime = DateTime.Now;
        //    entity.Owner = "abc";
        //    entity.Status = "abc";
        //    entity.Remark = "abc";
        //    entity.SN = 0;
        //    entity.UserId = 0;
        //    entity.Deleted = true;
        //    entity.PlateColor = 0;
        //    entity.SubCmd = 0;
        //    entity.TenantId = 0;
        //    entity.Source = "abc";
        //    entity.UpdateTime = DateTime.Now;
        //    entity.GpsId = "abc";
        //    entity.Data = "abc";
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化JT809Command[809指令]数据！");
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
        /// <summary>用户编码</summary>
        [XmlIgnore, IgnoreDataMember]
        //[ScriptIgnore]
        public User User => Extends.Get(nameof(User), k => User.FindByID(UserId));

        /// <summary>用户名称</summary>
        [Map(nameof(UserId), typeof(User), "ID")]
        public String UserName => User?.Name;

        /// <summary>车牌颜色</summary>
        [XmlIgnore, IgnoreDataMember]
        //[ScriptIgnore]
        public PlateColor __PlateColor => Extends.Get(nameof(VehicleVedioManage.BasicData.Entity.PlateColor), k => VehicleVedioManage.BasicData.Entity.PlateColor.FindByCode(PlateColor));

        /// <summary>车牌颜色名称</summary>
        [Map(nameof(PlateColor), typeof(PlateColor), "Code")]
        public String? PlateColorName => __PlateColor?.Name;

        #endregion

        #region 扩展查询
        /// <summary>根据指令编码查找</summary>
        /// <param name="cmdId">指令编码</param>
        /// <returns>实体对象</returns>
        public static JT809Command FindByCmdId(Int32 cmdId)
        {
            if (cmdId <= 0) return null;

            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.CmdId == cmdId);

            // 单对象缓存
            return Meta.SingleCache[cmdId];

            //return Find(_.CmdId == cmdId);
        }

        /// <summary>根据车牌号、车牌颜色查找</summary>
        /// <param name="plateNo">车牌号</param>
        /// <param name="plateColor">车牌颜色</param>
        /// <returns>实体对象</returns>
        public static JT809Command FindByPlateNoAndPlateColor(String plateNo, Byte plateColor)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.PlateNo.EqualIgnoreCase(plateNo) && e.PlateColor == plateColor);

            return Find(_.PlateNo == plateNo & _.PlateColor == plateColor);
        }

        /// <summary>根据Sim卡查找</summary>
        /// <param name="simNo">Sim卡</param>
        /// <returns>实体列表</returns>
        public static IList<JT809Command> FindAllBySimNo(String simNo)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e => e.SimNo.EqualIgnoreCase(simNo));

            return FindAll(_.SimNo == simNo);
        }
        #endregion

        #region 高级查询

        // Select Count(CmdId) as CmdId,Category From JT809Command Where CreateTime>'2020-01-24 00:00:00' Group By Category Order By CmdId Desc limit 20
        //static readonly FieldCache<JT809Command> _CategoryCache = new FieldCache<JT809Command>(nameof(Category))
        //{
        //Where = _.CreateTime > DateTime.Today.AddDays(-30) & Expression.Empty
        //};

        ///// <summary>获取类别列表，字段缓存10分钟，分组统计数据最多的前20种，用于魔方前台下拉选择</summary>
        ///// <returns></returns>
        //public static IDictionary<String, String> GetCategoryList() => _CategoryCache.FindAllName();
        /// <summary>高级查询</summary>
        /// <param name="simNo">Sim卡</param>
        /// <param name="plateNo">车牌号</param>
        /// <param name="plateColor">车牌颜色</param>
        /// <param name="start">更新时间开始</param>
        /// <param name="end">更新时间结束</param>
        /// <param name="key">关键字</param>
        /// <param name="page">分页参数信息。可携带统计和数据权限扩展查询等信息</param>
        /// <returns>实体列表</returns>
        public static IList<JT809Command> Search(String simNo, String plateNo, Byte plateColor, DateTime start, DateTime end, String key, PageParameter page)
        {
            var exp = new WhereExpression();

            if (!simNo.IsNullOrEmpty()) exp &= _.SimNo == simNo;
            if (!plateNo.IsNullOrEmpty()) exp &= _.PlateNo == plateNo;
            if (plateColor >= 0) exp &= _.PlateColor == plateColor;
            exp &= _.CreateTime.Between(start, end);
            if (!key.IsNullOrEmpty()) exp &= _.SimNo.Contains(key) | _.PlateNo.Contains(key) | _.Descr.Contains(key) | _.CmdData.Contains(key) | _.Owner.Contains(key) | _.Status.Contains(key) | _.Remark.Contains(key) | _.Source.Contains(key) | _.GpsId.Contains(key) | _.Data.Contains(key);

            return FindAll(exp, page);
        }

        // Select Count(CmdId) as CmdId,PlateNo From JT809Command Where CreateTime>'2020-01-24 00:00:00' Group By PlateNo Order By CmdId Desc limit 20
        static readonly FieldCache<JT809Command> _PlateNoCache = new FieldCache<JT809Command>(nameof(PlateNo))
        {
            //Where = _.CreateTime > DateTime.Today.AddDays(-30) & Expression.Empty
        };

        /// <summary>获取车牌号列表，字段缓存10分钟，分组统计数据最多的前20种，用于魔方前台下拉选择</summary>
        /// <returns></returns>
        public static IDictionary<String, String> GetPlateNoList() => _PlateNoCache.FindAllName();

        // Select Count(CmdId) as CmdId,SimNo From JT809Command Where CreateTime>'2020-01-24 00:00:00' Group By SimNo Order By CmdId Desc limit 20
        static readonly FieldCache<JT809Command> _SimNoCache = new FieldCache<JT809Command>(nameof(SimNo))
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