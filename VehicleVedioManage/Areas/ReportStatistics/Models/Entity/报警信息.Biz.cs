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
    public partial class WarnMsgInform : Entity<WarnMsgInform>
    {
        #region 对象操作
        static WarnMsgInform()
        {
            // 累加字段，生成 Update xx Set Count=Count+1234 Where xxx
            //var df = Meta.Factory.AdditionalFields;
            //df.Add(nameof(Angle));

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
            ID = Math.Round(ID, 6);
            RedoId = Math.Round(RedoId, 6);
            //if (isNew && !Dirtys[nameof(CreateTime)]) CreateTime = DateTime.Now;
            //if (!Dirtys[nameof(UpdateTime)]) UpdateTime = DateTime.Now;
        }

        ///// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //protected override void InitData()
        //{
        //    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
        //    if (Meta.Session.Count > 0) return;

        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化WarnMsgInform[报警信息]数据……");

        //    var entity = new WarnMsgInform();
        //    entity.Addiinfo = "abc";
        //    entity.Angle = 0;
        //    entity.CreateTime = DateTime.Now;
        //    entity.DataType = 0;
        //    entity.DealResult = "abc";
        //    entity.DealTime = DateTime.Now;
        //    entity.ExtInfo = "abc";
        //    entity.Height = 0;
        //    entity.InfoId = 0;
        //    entity.Lat = 0.0;
        //    entity.Loading = 0;
        //    entity.Lon = 0.0;
        //    entity.OrgWarnId = 0;
        //    entity.Origin = 0;
        //    entity.RedoEndTime = DateTime.Now;
        //    entity.RedoFlag = 0;
        //    entity.RedoId = 0.0;
        //    entity.RedoTime = DateTime.Now;
        //    entity.Result = 0;
        //    entity.Speed = 0;
        //    entity.Status1 = 0;
        //    entity.Status2 = 0;
        //    entity.Status3 = 0;
        //    entity.SubType = 0;
        //    entity.Text = "abc";
        //    entity.UpdateTime = DateTime.Now;
        //    entity.Valid = 0;
        //    entity.VehicleId = 0;
        //    entity.WarnContent = "abc";
        //    entity.WarnSrc = 0;
        //    entity.WarnTime = DateTime.Now;
        //    entity.WarnType = 0;
        //    entity.DealUser = "abc";
        //    entity.Mask = 0;
        //    entity.ExtId = 0;
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化WarnMsgInform[报警信息]数据！");
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
        /// <summary>根据编号查找</summary>
        /// <param name="id">编号</param>
        /// <returns>实体对象</returns>
        public static WarnMsgInform FindByID(Decimal id)
        {

            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.ID == id);

            // 单对象缓存
            return Meta.SingleCache[id];

            //return Find(_.ID == id);
        }
        #endregion

        #region 高级查询

        // Select Count(ID) as ID,Category From WarnMsgInform Where CreateTime>'2020-01-24 00:00:00' Group By Category Order By ID Desc limit 20
        //static readonly FieldCache<WarnMsgInform> _CategoryCache = new FieldCache<WarnMsgInform>(nameof(Category))
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