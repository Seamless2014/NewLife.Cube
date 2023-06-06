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

namespace VehicleVedioManage.BasicData.Entity
{
    public partial class VehicleType : Entity<VehicleType>
    {
        #region 对象操作
        static VehicleType()
        {
            // 累加字段，生成 Update xx Set Count=Count+1234 Where xxx
            //var df = Meta.Factory.AdditionalFields;
            //df.Add(nameof(Code));

            // 过滤器 UserModule、TimeModule、IPModule
            Meta.Modules.Add<UserModule>();
            Meta.Modules.Add<TimeModule>();
            Meta.Modules.Add<IPModule>();
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

            // 检查唯一索引
            // CheckExist(isNew, nameof(ID));
        }

        ///// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //protected override void InitData()
        //{
        //    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
        //    if (Meta.Session.Count > 0) return;

        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化VehicleType[车辆类型]数据……");

        //    var entity = new VehicleType();
        //    entity.ID = 0;
        //    entity.Code = 0;
        //    entity.Description = "abc";
        //    entity.ParentCode = 0;
        //    entity.Name = "abc";
        //    entity.CreateUser = "abc";
        //    entity.CreateUserID = 0;
        //    entity.CreateIP = "abc";
        //    entity.CreateTime = DateTime.Now;
        //    entity.UpdateUser = "abc";
        //    entity.UpdateUserID = 0;
        //    entity.UpdateIP = "abc";
        //    entity.UpdateTime = DateTime.Now;
        //    entity.Remark = "abc";
        //    entity.CreateDate = DateTime.Now;
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化VehicleType[车辆类型]数据！");
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
        /// <summary>父级</summary>
        [XmlIgnore, ScriptIgnore, IgnoreDataMember]
        public VehicleType Parent => Extends.Get(nameof(VehicleType), k => FindByID(ParentID));

        /// <summary>父级</summary>
        [Map(__.ParentID, typeof(VehicleType), __.ID)]
        public String ParentName => Parent?.ToString();

        /// <summary>父级路径</summary>
        public String ParentPath
        {
            get
            {
                var list = new List<VehicleType>();
                var ids = new List<Int32>();
                var p = Parent;
                while (p != null && !ids.Contains(p.ID))
                {
                    list.Add(p);
                    ids.Add(p.ID);

                    p = p.Parent;
                }
                if (list != null && list.Count > 0) return list.Join("/", r => r.Description);

                return Parent?.ParentName;
            }
        }

        /// <summary>路径</summary>
        public String Path
        {
            get
            {
                var p = ParentPath;
                if (p.IsNullOrEmpty()) return Description;
                return p + "/" + Description;
            }
        }
        #endregion

        #region 扩展查询
        /// <summary>根据编号查找</summary>
        /// <param name="id">编号</param>
        /// <returns>实体对象</returns>
        public static VehicleType FindByID(Int32 id)
        {
            if (id <= 0) return null;

            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.ID == id);

            // 单对象缓存
            return Meta.SingleCache[id];

            //return Find(_.ID == id);
        }
        /// <summary>根据编码查找</summary>
        /// <param name="id">编号</param>
        /// <returns>实体对象</returns>
        public static VehicleType FindByCode(Int32 code)
        {
            if (code <= 0) return null;

            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.Code == code);

            // 单对象缓存
            return Meta.SingleCache[code];

            //return Find(_.ID == id);
        }

        /// <summary>根据名称查找</summary>
        /// <param name="name">名称</param>
        /// <returns>实体列表</returns>
        public static IList<VehicleType> FindAllByName(String name)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e => e.Name.EqualIgnoreCase(name));

            return FindAll(_.Name == name);
        }

        /// <summary>查找所有</summary>
        /// <returns>实体列表</returns>
        public static IList<VehicleType> FindAll()
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e =>e.ID>0);

            return FindAll();
        }
        #endregion

        #region 高级查询

        // Select Count(Id) as Id,Category From VehicleType Where CreateTime>'2020-01-24 00:00:00' Group By Category Order By Id Desc limit 20
        //static readonly FieldCache<VehicleType> _CategoryCache = new FieldCache<VehicleType>(nameof(Category))
        //{
        //Where = _.CreateTime > DateTime.Today.AddDays(-30) & Expression.Empty
        //};

        ///// <summary>获取类别列表，字段缓存10分钟，分组统计数据最多的前20种，用于魔方前台下拉选择</summary>
        ///// <returns></returns>
        //public static IDictionary<String, String> GetCategoryList() => _CategoryCache.FindAllName();

        /// <summary>高级查询</summary>
        /// <param name="name">名称</param>
        /// <param name="start">更新时间开始</param>
        /// <param name="end">更新时间结束</param>
        /// <param name="key">关键字</param>
        /// <param name="page">分页参数信息。可携带统计和数据权限扩展查询等信息</param>
        /// <returns>实体列表</returns>
        public static IList<VehicleType> Search(String name, DateTime start, DateTime end, String key, PageParameter page)
        {
            var exp = new WhereExpression();

            if (!name.IsNullOrEmpty()) exp &= _.Name == name;
            exp &= _.UpdateTime.Between(start, end);
            if (!key.IsNullOrEmpty()) exp &= _.Description.Contains(key) | _.Name.Contains(key) | _.CreateUser.Contains(key) | _.CreateIP.Contains(key) | _.UpdateUser.Contains(key) | _.UpdateIP.Contains(key) | _.Remark.Contains(key);

            return FindAll(exp, page);
        }

        #endregion

        #region 业务操作
        #endregion
    }
}