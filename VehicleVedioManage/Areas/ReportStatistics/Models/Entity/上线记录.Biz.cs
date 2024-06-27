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
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using NewLife;
using NewLife.Data;
using NewLife.Log;
using NewLife.Model;
using NewLife.Reflection;
using NewLife.Threading;
using NewLife.Web;
using VehicleVedioManage.BasicData.Entity;
using XCode;
using XCode.Cache;
using XCode.Configuration;
using XCode.DataAccessLayer;
using XCode.Membership;
using XCode.Shards;

namespace VehicleVedioManage.ReportStatistics.Entity
{
    public partial class OnlineRecord : Entity<OnlineRecord>
    {
        #region 对象操作
        static OnlineRecord()
        {
            // 累加字段，生成 Update xx Set Count=Count+1234 Where xxx
            //var df = Meta.Factory.AdditionalFields;
            //df.Add(nameof(Processed));

            // 过滤器 UserModule、TimeModule、IPModule
            Meta.Modules.Add<TimeModule>();
        }
        public OnlineRecord()
        {

        }
        public OnlineRecord(GPSRealData rd,string alarmType,string alarmSource,string status)
        {
            Latitude = rd.Latitude;
            Longitude = rd.Longitude;
            Location = rd.Location;
            PlateNo = rd.PlateNo;
            StartTime = rd.SendTime;
            AlarmType = alarmType;
            AlarmSource = alarmSource;
            Velocity = rd.Velocity;
            Status = status;
            VehicleId = rd.VehicleId;
            EndTime = this.StartTime;
            CreateTime = DateTime.Now;//
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

        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化OnlineRecord[上线记录]数据……");

        //    var entity = new OnlineRecord();
        //    entity.PlateNo = "abc";
        //    entity.StartTime = DateTime.Now;
        //    entity.EndTime = DateTime.Now;
        //    entity.TimeSpan = 0.0;
        //    entity.Velocity = 0.0;
        //    entity.Status = "abc";
        //    entity.Driver = "abc";
        //    entity.Latitude = 0.0;
        //    entity.Longitude = 0.0;
        //    entity.Location = "abc";
        //    entity.Latitude1 = 0.0;
        //    entity.Longitude1 = 0.0;
        //    entity.Location1 = "abc";
        //    entity.Processed = 0;
        //    entity.ProcessedTime = DateTime.Now;
        //    entity.Type = "abc";
        //    entity.ChildType = "abc";
        //    entity.Station = 0;
        //    entity.Gas1 = 0.0;
        //    entity.Gas2 = 0.0;
        //    entity.Mileage1 = 0.0;
        //    entity.Mileage2 = 0.0;
        //    entity.VideoFileName = "abc";
        //    entity.Flag = "abc";
        //    entity.Remark = "abc";
        //    entity.CreateTime = DateTime.Now;
        //    entity.Deleted = true;
        //    entity.TenantId = 0;
        //    entity.Owner = "abc";
        //    entity.VehicleId = 0;
        //    entity.ResponseSN = 0;
        //    entity.ProcessedUserId = 0;
        //    entity.ProcessedUserName = "abc";
        //    entity.AlarmSource = "abc";
        //    entity.AlarmType = "abc";
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化OnlineRecord[上线记录]数据！");
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
        /// <summary>报警源</summary>
        [XmlIgnore, ScriptIgnore, IgnoreDataMember]
        public AlarmSource __AlarmSource => Extends.Get(nameof(AlarmSource), k => BasicData.Entity.AlarmSource.FindByCode(AlarmSource));

        /// <summary>报警源</summary>
        [Map(__.AlarmSource)]
        public String AlarmSourceName => __AlarmSource?.Name;
        #endregion

        #region 扩展查询
        /// <summary>根据报警编码查找</summary>
        /// <param name="alarmId">报警编码</param>
        /// <returns>实体对象</returns>
        public static OnlineRecord FindByAlarmId(Int32 alarmId)
        {
            if (alarmId <= 0) return null;

            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.AlarmId == alarmId);

            // 单对象缓存
            return Meta.SingleCache[alarmId];

            //return Find(_.AlarmId == alarmId);
        }
        /// <summary>根据车牌号查找</summary>
        /// <param name="plateNo">车牌号</param>
        /// <returns>实体对象</returns>
        public static OnlineRecord FindByPlateNo(String plateNo)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.PlateNo.EqualIgnoreCase(plateNo));

            return Find(_.PlateNo == plateNo);
        }
        public static OnlineRecord FindByPlateNoStatusAlarmType(string  plateNo,string status,string alarmType)
        {
            if (plateNo.IsNullOrEmpty()) return null;
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.PlateNo.EqualIgnoreCase(plateNo)&e.Status==status & e.AlarmType==alarmType);

            return Find(_.PlateNo == plateNo & _.Status == status & _.AlarmType == alarmType);
        }
        #endregion

        #region 高级查询
        /// <summary>高级查询</summary>
        /// <param name="plateNo">车牌号</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="start">起始时间开始</param>
        /// <param name="end">起始时间结束</param>
        /// <param name="key">关键字</param>
        /// <param name="page">分页参数信息。可携带统计和数据权限扩展查询等信息</param>
        /// <returns>实体列表</returns>
        public static IList<OnlineRecord> Search(String plateNo, DateTime endTime, DateTime start, DateTime end, String key, PageParameter page)
        {
            var exp = new WhereExpression();

            if (!plateNo.IsNullOrEmpty()) exp &= _.PlateNo == plateNo;
            exp &= _.StartTime.Between(start, end);
            if (!key.IsNullOrEmpty()) exp &= _.PlateNo.Contains(key) | _.Status.Contains(key) | _.Driver.Contains(key) | _.Location.Contains(key) | _.Location1.Contains(key) | _.Type.Contains(key) | _.ChildType.Contains(key) | _.VideoFileName.Contains(key) | _.Flag.Contains(key) | _.Remark.Contains(key) | _.Owner.Contains(key) | _.ProcessedUserName.Contains(key) | _.AlarmSource.Contains(key) | _.AlarmType.Contains(key);

            return FindAll(exp, page);
        }

        public static OnlineRecord SearchOne(string plateNo, String status,string alarmType, PageParameter page)
        {
            var exp = new WhereExpression();

            if (!plateNo.IsNullOrEmpty()) exp &= _.PlateNo == plateNo;
            if (!status.IsNullOrEmpty()) exp &= _.Status == status;
            if(!alarmType.IsNullOrEmpty()) exp &= _.AlarmType == alarmType;
            return Find(exp, page);
        }

        // Select Count(AlarmId) as AlarmId,PlateNo From OnlineRecord Where EndTime>'2020-01-24 00:00:00' Group By PlateNo Order By AlarmId Desc limit 20
        static readonly FieldCache<OnlineRecord> _PlateNoCache = new FieldCache<OnlineRecord>(nameof(PlateNo))
        {
            //Where = _.EndTime > DateTime.Today.AddDays(-30) & Expression.Empty
        };

        /// <summary>获取车牌号列表，字段缓存10分钟，分组统计数据最多的前20种，用于魔方前台下拉选择</summary>
        /// <returns></returns>
        public static IDictionary<String, String> GetPlateNoList() => _PlateNoCache.FindAllName();
        #endregion

        #region 业务操作
        #endregion
    }
}