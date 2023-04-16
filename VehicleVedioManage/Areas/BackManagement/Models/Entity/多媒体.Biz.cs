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
    public partial class MediaItem : Entity<MediaItem>
    {
        #region 对象操作
        static MediaItem()
        {
            // 累加字段，生成 Update xx Set Count=Count+1234 Where xxx
            //var df = Meta.Factory.AdditionalFields;
            //df.Add(nameof(CommandId));

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

            // 检查唯一索引
            // CheckExist(isNew, nameof(PlateNo));
        }

        ///// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //protected override void InitData()
        //{
        //    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
        //    if (Meta.Session.Count > 0) return;

        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化MediaItem[多媒体]数据……");

        //    var entity = new MediaItem();
        //    entity.CommandId = 0;
        //    entity.CommandType = "abc";
        //    entity.PlateNo = "abc";
        //    entity.SimNo = "abc";
        //    entity.SendTime = DateTime.Now;
        //    entity.MediaDataId = 0;
        //    entity.MediaType = 0;
        //    entity.CodeFormat = 0;
        //    entity.ChannelId = 0;
        //    entity.EventCode = 0;
        //    entity.FileName = "abc";
        //    entity.CreateTime = DateTime.Now;
        //    entity.TenantId = 0;
        //    entity.Latitude = 0.0;
        //    entity.Longitude = 0.0;
        //    entity.Speed = 0.0;
        //    entity.Deleted = true;
        //    entity.Owner = "abc";
        //    entity.Remark = "abc";
        //    entity.Location = "abc";
        //    entity.GPSId = "abc";
        //    entity.MultimediaDataId = 0;
        //    entity.MultimediaType = 0;
        //    entity.MultidediaCodeFormat = 0;
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化MediaItem[多媒体]数据！");
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
        /// <summary>根据多媒体项编码查找</summary>
        /// <param name="mediaItemId">多媒体项编码</param>
        /// <returns>实体对象</returns>
        public static MediaItem FindByMediaItemId(Int32 mediaItemId)
        {
            if (mediaItemId <= 0) return null;

            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.MediaItemId == mediaItemId);

            // 单对象缓存
            return Meta.SingleCache[mediaItemId];

            //return Find(_.MediaItemId == mediaItemId);
        }

        /// <summary>根据车牌号查找</summary>
        /// <param name="plateNo">车牌号</param>
        /// <returns>实体对象</returns>
        public static MediaItem FindByPlateNo(String plateNo)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.PlateNo.EqualIgnoreCase(plateNo));

            return Find(_.PlateNo == plateNo);
        }

        /// <summary>根据Sim卡号查找</summary>
        /// <param name="simNo">Sim卡号</param>
        /// <returns>实体列表</returns>
        public static IList<MediaItem> FindAllBySimNo(String simNo)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e => e.SimNo.EqualIgnoreCase(simNo));

            return FindAll(_.SimNo == simNo);
        }
        #endregion

        #region 高级查询
        /// <summary>高级查询</summary>
        /// <param name="plateNo">车牌号</param>
        /// <param name="simNo">Sim卡号</param>
        /// <param name="start">发送时间开始</param>
        /// <param name="end">发送时间结束</param>
        /// <param name="key">关键字</param>
        /// <param name="page">分页参数信息。可携带统计和数据权限扩展查询等信息</param>
        /// <returns>实体列表</returns>
        public static IList<MediaItem> Search(String plateNo, String simNo, DateTime start, DateTime end, String key, PageParameter page)
        {
            var exp = new WhereExpression();

            if (!plateNo.IsNullOrEmpty()) exp &= _.PlateNo == plateNo;
            if (!simNo.IsNullOrEmpty()) exp &= _.SimNo == simNo;
            exp &= _.SendTime.Between(start, end);
            if (!key.IsNullOrEmpty()) exp &= _.CommandType.Contains(key) | _.PlateNo.Contains(key) | _.SimNo.Contains(key) | _.FileName.Contains(key) | _.Owner.Contains(key) | _.Remark.Contains(key) | _.Location.Contains(key) | _.GPSId.Contains(key);

            return FindAll(exp, page);
        }

        // Select Count(MediaItemId) as MediaItemId,SimNo From MediaItem Where CreateTime>'2020-01-24 00:00:00' Group By SimNo Order By MediaItemId Desc limit 20
        static readonly FieldCache<MediaItem> _SimNoCache = new FieldCache<MediaItem>(nameof(SimNo))
        {
            //Where = _.CreateTime > DateTime.Today.AddDays(-30) & Expression.Empty
        };

        /// <summary>获取Sim卡号列表，字段缓存10分钟，分组统计数据最多的前20种，用于魔方前台下拉选择</summary>
        /// <returns></returns>
        public static IDictionary<String, String> GetSimNoList() => _SimNoCache.FindAllName();
        #endregion

        #region 业务操作
        #endregion
    }
}