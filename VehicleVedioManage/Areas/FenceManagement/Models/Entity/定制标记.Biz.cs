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

namespace VehicleVedioManage.FenceManagement.Entity
{
    public partial class CustomMarker : Entity<CustomMarker>
    {
        #region 对象操作
        static CustomMarker()
        {
            // 累加字段，生成 Update xx Set Count=Count+1234 Where xxx
            //var df = Meta.Factory.AdditionalFields;
            //df.Add(nameof(DepId));

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

        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化CustomMarker[定制标记]数据……");

        //    var entity = new CustomMarker();
        //    entity.Name = "abc";
        //    entity.Code = "abc";
        //    entity.Owner = "abc";
        //    entity.Phone = "abc";
        //    entity.Mobile = "abc";
        //    entity.Layer = "abc";
        //    entity.DepId = 0;
        //    entity.Office = "abc";
        //    entity.Longitude = 0.0;
        //    entity.Latitude = 0.0;
        //    entity.Deleted = true;
        //    entity.CreateTime = DateTime.Now;
        //    entity.TenantId = 0;
        //    entity.IsEnclosure = true;
        //    entity.Scope = 0;
        //    entity.Remark = "abc";
        //    entity.Fixed = true;
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化CustomMarker[定制标记]数据！");
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
        public Department _Department => Extends.Get(nameof(Department), k => Department.FindByID(DepId));

        /// <summary>部门名称</summary>
        [Map(nameof(DepId), typeof(Department), "ID")]
        public String? DepartmentName => _Department?.Name;
        #endregion

        #region 扩展查询
        /// <summary>根据标记编码查找</summary>
        /// <param name="markerId">标记编码</param>
        /// <returns>实体对象</returns>
        public static CustomMarker FindByMarkerId(Int32 markerId)
        {
            if (markerId <= 0) return null;

            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.MarkerId == markerId);

            // 单对象缓存
            return Meta.SingleCache[markerId];

            //return Find(_.MarkerId == markerId);
        }
        #endregion

        #region 高级查询

        // Select Count(MarkerId) as MarkerId,Category From CustomMarker Where CreateTime>'2020-01-24 00:00:00' Group By Category Order By MarkerId Desc limit 20
        //static readonly FieldCache<CustomMarker> _CategoryCache = new FieldCache<CustomMarker>(nameof(Category))
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