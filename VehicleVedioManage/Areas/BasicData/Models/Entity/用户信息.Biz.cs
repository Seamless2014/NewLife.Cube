using System.Runtime.Serialization;
using System.Xml.Serialization;
using NewLife;
using XCode;
using XCode.Membership;

namespace VehicleVedioManage.BasicData.Entity
{
    public partial class UserInfo : Entity<UserInfo>
    {
        #region 对象操作
        static UserInfo()
        {
            // 累加字段，生成 Update xx Set Count=Count+1234 Where xxx
            //var df = Meta.Factory.AdditionalFields;
            //df.Add(nameof(userId));

            // 过滤器 UserModule、TimeModule、IPModule
            Meta.Modules.Add<TimeModule>();
        }

        /// <summary>验证并修补数据，通过抛出异常的方式提示验证失败。</summary>
        /// <param name="isNew">是否插入</param>
        public override void Valid(Boolean isNew)
        {
            // 如果没有脏数据，则不需要进行任何处理
            if (!HasDirty) return;

            // 这里验证参数范围，建议抛出参数异常，指定参数名，前端用户界面可以捕获参数异常并聚焦到对应的参数输入框
            if (Name.IsNullOrEmpty()) throw new ArgumentNullException(nameof(Name), "Name不能为空！");
            if (loginName.IsNullOrEmpty()) throw new ArgumentNullException(nameof(loginName), "loginName不能为空！");
            if (Password.IsNullOrEmpty()) throw new ArgumentNullException(nameof(Password), "Password不能为空！");

            // 建议先调用基类方法，基类方法会做一些统一处理
            base.Valid(isNew);

            // 在新插入数据或者修改了指定字段时进行修正
            //if (!Dirtys[nameof(updateTime)]) updateTime = DateTime.Now;
        }

        ///// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //protected override void InitData()
        //{
        //    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
        //    if (Meta.Session.Count > 0) return;

        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化UserInfo[用户信息]数据……");

        //    var entity = new UserInfo();
        //    entity.userId = 0;
        //    entity.Name = "abc";
        //    entity.loginName = "abc";
        //    entity.Password = "abc";
        //    entity.Remark = "abc";
        //    entity.userState = "abc";
        //    entity.mapCenterLat = 0.0;
        //    entity.mapCenterLng = 0.0;
        //    entity.mapLevel = 0;
        //    entity.mapType = "abc";
        //    entity.updateTime = DateTime.Now;
        //    entity.userFlag = 0;
        //    entity.createDate = DateTime.Now;
        //    entity.Deleted = true;
        //    entity.tenantId = 0;
        //    entity.Owner = "abc";
        //    entity.UserType = "abc";
        //    entity.Job = "abc";
        //    entity.Department = 0;
        //    entity.Phone = "abc";
        //    entity.Mail = "abc";
        //    entity.regionId = 0;
        //    entity.loginTime = DateTime.Now;
        //    entity.phoneNo = "abc";
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化UserInfo[用户信息]数据！");
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
        /// <summary>userId</summary>
        [XmlIgnore, IgnoreDataMember]
        //[ScriptIgnore]
        public User User => Extends.Get(nameof(User), k => User.FindByID(userId));

        /// <summary>userId</summary>
        [Map(nameof(userId), typeof(User), "ID")]
        public String UserName => User?.Name;

        /// <summary>regionId</summary>
        [XmlIgnore, IgnoreDataMember]
        //[ScriptIgnore]
        public Area Region ;

        /// <summary>regionId</summary>
        [Map(nameof(regionId), typeof(Area), "Id")]
        public String RegionName => Region?.Name;

        #endregion

        #region 扩展查询
        #endregion

        #region 高级查询

        // Select Count(Id) as Id,Category From UserInfo Where CreateTime>'2020-01-24 00:00:00' Group By Category Order By Id Desc limit 20
        //static readonly FieldCache<UserInfo> _CategoryCache = new FieldCache<UserInfo>(nameof(Category))
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