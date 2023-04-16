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
    public partial class GPSRealData : Entity<GPSRealData>
    {
        #region 对象操作
        static GPSRealData()
        {
            // 累加字段，生成 Update xx Set Count=Count+1234 Where xxx
            //var df = Meta.Factory.AdditionalFields;
            //df.Add(nameof(Direction));

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
            Longitude = Math.Round(Longitude, 6);
            Latitude = Math.Round(Latitude, 6);
            Velocity = Math.Round(Velocity, 6);
            Gas = Math.Round(Gas, 6);
            Mileage = Math.Round(Mileage, 6);
            RecordVelocity = Math.Round(RecordVelocity, 6);
            //if (isNew && !Dirtys[nameof(CreateTime)]) CreateTime = DateTime.Now;
            //if (!Dirtys[nameof(UpdateTime)]) UpdateTime = DateTime.Now;
        }

        ///// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //protected override void InitData()
        //{
        //    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
        //    if (Meta.Session.Count > 0) return;

        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化GPSRealData[实时数据]数据……");

        //    var entity = new GPSRealData();
        //    entity.SimNo = "abc";
        //    entity.PlateNo = "abc";
        //    entity.Location = "abc";
        //    entity.SendTime = DateTime.Now;
        //    entity.Longitude = 0.0;
        //    entity.Latitude = 0.0;
        //    entity.Velocity = 0.0;
        //    entity.Direction = 0;
        //    entity.Status = "abc";
        //    entity.Gas = 0.0;
        //    entity.Mileage = 0.0;
        //    entity.RecordVelocity = 0.0;
        //    entity.Remain = 0.0;
        //    entity.Online = true;
        //    entity.Signal = 0;
        //    entity.AlarmState = "abc";
        //    entity.DVRStatus = "abc";
        //    entity.Altitude = 0.0;
        //    entity.Valid = true;
        //    entity.DepId = 0;
        //    entity.VehicleId = 0;
        //    entity.UpdateTime = DateTime.Now;
        //    entity.CreateTime = DateTime.Now;
        //    entity.EnclosureId = 0;
        //    entity.EnclosureType = 0;
        //    entity.EnclosureAlarm = 0;
        //    entity.OverSpeedAreaType = 0;
        //    entity.OverSpeedAreaId = 0;
        //    entity.RouteSegmentId = 0;
        //    entity.RunTimeOnRoute = 0;
        //    entity.RouteAlarmType = 0;
        //    entity.OnlineDate = DateTime.Now;
        //    entity.FuelLevelData = "abc";
        //    entity.FuelData = "abc";
        //    entity.AreaId = 0;
        //    entity.AreaAlarm = 0;
        //    entity.AreaType = 0;
        //    entity.PlatformId = 0;
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化GPSRealData[实时数据]数据！");
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
        public static GPSRealData FindByID(Int32 id)
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
        public static GPSRealData FindByPlateNo(String plateNo)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.PlateNo.EqualIgnoreCase(plateNo));

            return Find(_.PlateNo == plateNo);
        }
        #endregion

        #region 高级查询
        /// <summary>高级查询</summary>
        /// <param name="plateNo">车牌号</param>
        /// <param name="start">发送时间开始</param>
        /// <param name="end">发送时间结束</param>
        /// <param name="key">关键字</param>
        /// <param name="page">分页参数信息。可携带统计和数据权限扩展查询等信息</param>
        /// <returns>实体列表</returns>
        public static IList<GPSRealData> Search(String plateNo, DateTime start, DateTime end, String key, PageParameter page)
        {
            var exp = new WhereExpression();

            if (!plateNo.IsNullOrEmpty()) exp &= _.PlateNo == plateNo;
            exp &= _.SendTime.Between(start, end);
            if (!key.IsNullOrEmpty()) exp &= _.SimNo.Contains(key) | _.PlateNo.Contains(key) | _.Location.Contains(key) | _.Status.Contains(key) | _.AlarmState.Contains(key) | _.DVRStatus.Contains(key) | _.FuelLevelData.Contains(key) | _.FuelData.Contains(key);

            return FindAll(exp, page);
        }

        // Select Count(ID) as ID,PlateNo From GPSRealData Where CreateTime>'2020-01-24 00:00:00' Group By PlateNo Order By ID Desc limit 20
        static readonly FieldCache<GPSRealData> _PlateNoCache = new FieldCache<GPSRealData>(nameof(PlateNo))
        {
            //Where = _.CreateTime > DateTime.Today.AddDays(-30) & Expression.Empty
        };

        /// <summary>获取车牌号列表，字段缓存10分钟，分组统计数据最多的前20种，用于魔方前台下拉选择</summary>
        /// <returns></returns>
        public static IDictionary<String, String> GetPlateNoList() => _PlateNoCache.FindAllName();
        #endregion

        #region 业务操作
        #endregion
    }
}