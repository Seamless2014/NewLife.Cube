//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using GpsNET.Dao;
//using GpsNET.Domain;
//using System.Collections.Concurrent;
//using System.Collections;

//namespace VehicleVedioManage.Web.Service
//{
//    /// <summary>
//    /// 部门服务
//    /// </summary>
//    public class DepartmentService : IDepartmentService
//    {
//        public IBaseDao BaseDao { get; set; }
//        /// <summary>
//        /// 部门基本信息缓存
//        /// </summary>
//        public static ConcurrentDictionary<int, Department> depMap = new ConcurrentDictionary<int, Department>();

//        /// <summary>
//        /// 获取部门
//        /// </summary>
//        /// <param name="depId"></param>
//        /// <returns></returns>
//        public Department getDepartment(int depId)
//        {
//            if (depMap.ContainsKey(depId))
//            {
//                return depMap[depId];
//            }
//            Department d = (Department)BaseDao.load(typeof(Department), depId);
//            depMap[depId] = d;
//            return d;
//        }
//        /// <summary>
//        /// 保存部门
//        /// </summary>
//        /// <param name="dep"></param>
//        public void saveDepartment(Department dep)
//        {
//            String hsql = "from Department where (Name = ?) and EntityId <> ? and Deleted = ? ";
//            Department otherVd = (Department)BaseDao.find(hsql, new Object[] {
//                dep.Name, dep.EntityId, false });
//            if (otherVd != null)
//            {
//                String msg = "部门名称重复，无法保存!";
//                throw new Exception(msg);
//            }

//            BaseDao.saveOrUpdate(dep);
//            depMap[dep.EntityId] = dep;
//        }

//        /// <summary>
//        /// 查找车组下面所有的级联的子车组
//        /// </summary>
//        /// <param name="depId"></param>
//        /// <returns></returns>
//        public List<int> getDepIdList(int depId)
//        {


//            List<int> depIdList = new List<int>();
//            List<int> allList = new List<int>();
//            depIdList.Add(depId);
//            allList.Add(depId);
//            while (depIdList.Count > 0)
//            {
//                depIdList = getChildDepIdList(depIdList, allList);
//            }

//            return allList;
//        }
//        /// <summary>
//        /// 获取子部门ID
//        /// </summary>
//        /// <param name="parentIdList"></param>
//        /// <param name="allList"></param>
//        /// <returns></returns>
//        private List<int> getChildDepIdList(List<int> parentIdList, List<int> allList)
//        {
//            String hql = "from Department where ParentId in (:depIdList) and Deleted = 0";

//            IList result = BaseDao.queryByNamedParam(hql, "depIdList",
//                    parentIdList.ToArray());
//            List<int> depIdList = new List<int>();
//            foreach (Object obj in result)
//            {
//                Department dep = (Department)obj;
//                allList.Add(dep.EntityId);
//                depIdList.Add(dep.EntityId);
//            }
//            return depIdList;
//        }

//    }
//}
