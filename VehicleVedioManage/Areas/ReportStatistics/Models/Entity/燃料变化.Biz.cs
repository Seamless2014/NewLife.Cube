﻿using System;
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
    public partial class FuelChangeRecord : Entity<FuelChangeRecord>
    {
        #region 对象操作
        static FuelChangeRecord()
        {
            // 累加字段，生成 Update xx Set Count=Count+1234 Where xxx
            //var df = Meta.Factory.AdditionalFields;
            //df.Add(nameof(TenantId));

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
            // CheckExist(isNew, nameof(EnclosureId));
        }

        ///// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //protected override void InitData()
        //{
        //    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
        //    if (Meta.Session.Count > 0) return;

        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化FuelChangeRecord[燃料变化记录]数据……");

        //    var entity = new FuelChangeRecord();
        //    entity.PlateNo = "abc";
        //    entity.Fuel = 0.0;
        //    entity.Type = "abc";
        //    entity.HappenTime = DateTime.Now;
        //    entity.CreateTime = DateTime.Now;
        //    entity.Deleted = true;
        //    entity.Manual = "abc";
        //    entity.Location = "abc";
        //    entity.Latitude = 0.0;
        //    entity.Longitude = 0.0;
        //    entity.Mileage = 0.0;
        //    entity.Owner = "abc";
        //    entity.Remark = "abc";
        //    entity.TenantId = 0;
        //    entity.EnclosureId = 0;
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化FuelChangeRecord[燃料变化记录]数据！");
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
        /// <summary>根据燃料变化记录编号查找</summary>
        /// <param name="id">燃料变化记录编号</param>
        /// <returns>实体对象</returns>
        public static FuelChangeRecord FindByID(Int32 id)
        {
            if (id <= 0) return null;

            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.ID == id);

            // 单对象缓存
            return Meta.SingleCache[id];

            //return Find(_.ID == id);
        }

        /// <summary>根据围栏编码查找</summary>
        /// <param name="enclosureId">围栏编码</param>
        /// <returns>实体对象</returns>
        public static FuelChangeRecord FindByEnclosureId(Int32 enclosureId)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.EnclosureId == enclosureId);

            return Find(_.EnclosureId == enclosureId);
        }
        /// <summary>根据车牌号查找</summary>
        /// <param name="plateNo">车牌号</param>
        /// <returns>实体列表</returns>
        public static IList<FuelChangeRecord> FindAllByPlateNo(String plateNo)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e => e.PlateNo.EqualIgnoreCase(plateNo));

            return FindAll(_.PlateNo == plateNo);
        }
        #endregion

        #region 高级查询
        /// <summary>高级查询</summary>
        /// <param name="enclosureId">围栏编码</param>
        /// <param name="start">创建时间开始</param>
        /// <param name="end">创建时间结束</param>
        /// <param name="key">关键字</param>
        /// <param name="page">分页参数信息。可携带统计和数据权限扩展查询等信息</param>
        /// <returns>实体列表</returns>
        public static IList<FuelChangeRecord> Search(Int32 enclosureId, DateTime start, DateTime end, String key, PageParameter page)
        {
            var exp = new WhereExpression();

            if (enclosureId >= 0) exp &= _.EnclosureId == enclosureId;
            exp &= _.CreateTime.Between(start, end);
            if (!key.IsNullOrEmpty()) exp &= _.PlateNo.Contains(key) | _.Type.Contains(key) | _.Manual.Contains(key) | _.Location.Contains(key) | _.Owner.Contains(key) | _.Remark.Contains(key);

            return FindAll(exp, page);
        }

        /// <summary>高级查询</summary>
        /// <param name="plateNo">车牌号</param>
        /// <param name="enclosureId">围栏编码</param>
        /// <param name="start">创建时间开始</param>
        /// <param name="end">创建时间结束</param>
        /// <param name="key">关键字</param>
        /// <param name="page">分页参数信息。可携带统计和数据权限扩展查询等信息</param>
        /// <returns>实体列表</returns>
        public static IList<FuelChangeRecord> Search(String plateNo, Int32 enclosureId, DateTime start, DateTime end, String key, PageParameter page)
        {
            var exp = new WhereExpression();

            if (!plateNo.IsNullOrEmpty()) exp &= _.PlateNo == plateNo;
            if (enclosureId >= 0) exp &= _.EnclosureId == enclosureId;
            exp &= _.CreateTime.Between(start, end);
            if (!key.IsNullOrEmpty()) exp &= _.PlateNo.Contains(key) | _.Type.Contains(key) | _.Manual.Contains(key) | _.Location.Contains(key) | _.Owner.Contains(key) | _.Remark.Contains(key);

            return FindAll(exp, page);
        }

        // Select Count(ID) as ID,PlateNo From FuelChangeRecord Where CreateTime>'2020-01-24 00:00:00' Group By PlateNo Order By ID Desc limit 20
        static readonly FieldCache<FuelChangeRecord> _PlateNoCache = new FieldCache<FuelChangeRecord>(nameof(PlateNo))
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