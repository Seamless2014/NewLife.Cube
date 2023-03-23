//using System.Collections;
//using System.Collections.Specialized;
//using System.Text;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;
//using NewLife.Log;
//using VehicleVedioManage.BackManagement.Entity;
//using VehicleVedioManage.BasicData.Entity;
//using VehicleVedioManage.Web.Models;
//using XCode.Membership;

//namespace VehicleVedioManage.Controllers
//{
//    public abstract class BaseController : Controller
//    {
//        /**
//	     * 存放当前在线用户信息的key
//	     */
//        protected static String ONLINE_USER_KEY = "currUserInfo";

//        protected static String ONLINE_USER_PERMISSION = "user_permission";

//        /**
//         * 存放授权部门Id map的可以
//         */
//        protected static String SESSION_KEY_DEP = "session_key_department";
//        /**
//         * session中存放地图工具栏权限菜单的key
//         */
//        protected static String SESSION_MAP_TOOL_MENU = "MapToolMenu";


//        /**
//         * session中存放功能权限的key
//         */
//        protected static String SESSION_WEB_FUNC = "WebFunc";


//        /**
//         * session中存放命令工具栏权限菜单的key
//         */
//        protected static String SESSION_COMMAND_TOOL_MENU = "CommandToolMenu";

//        /**
//         * session中存放命令车辆树右键菜单的key
//         */
//        protected static String SESSION_RIGHT_MENU = "RightMenu";

//        /**
//         * session中存放快捷菜单的key
//         */
//        protected static String SESSION_SHORT_CUT_MENU = "ShortCutMenu";
//        /**
//         * session中存放主菜单的key
//         */
//        protected static String SESSION_MAIN_MENU = "MainMenu";


//        protected static String SESSION_KEY_SYSTEM_CONFIG = "systemConfig";

//        protected static String SESSION_KEY_FUNCTION_MAP = "userFuncMap";

//        /**
//         * 假删除调转名称
//         */
//        protected static String FAKE_DELETED = "fakeDeleted";

//        protected static String DELETED = "deleted";

//        protected static String VIEW = "view";

//        protected static String SAVE_SUCCESS = "save";

//        protected static String CREATE = "create";

//        protected static String LIST_ALL = "listAll";

//        protected String message = "";

//        protected static String LIST = "list";

//        public IBaseDao BaseDao { get; set; }

//        public IQueryService QueryService { get; set; }
//        public IDepartmentService DepartmentService { get; set; }

//        public IBasicDataService BasicDataService { get; set; }

//        public IBaseService BaseService { get; set; }
//        public IVehicleService VehicleService { get; set; }


//        public virtual System.Type getEntityType()
//        {
//            throw new NotImplementedException();
//        }


//        //得到当前租户的ID,以便于数据隔离
//        protected int GetTenantId()
//        {
//            return 0;
//        }

//        public void Onlines()
//        {
//        }

//        public void AddCookies(Hashtable ht)
//        {
//        }

//        protected override void OnActionExecuting(ActionExecutingContext filterContext)
//        {
//            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

//            string sessionCookie = Request.Headers["Cookie"];

//            //log.Info("sessincookie:" + sessionCookie);

//            HttpCookie oldCookie = Request.Cookies["ASP.NET_SessionId"];
//            //if (oldCookie != null)
//            //log.Info("sessionId:" + oldCookie.Value);

//            // check if session is supported  

//            if (Session != null)
//            {

//                // check if a new session id was generated  
//                if (Session.IsNewSession)
//                {
//                    // If it says it is a new session, but an existing cookie exists, then it must  
//                    // have timed out                     

//                    if ((null != sessionCookie) && (sessionCookie.IndexOf("ASP.NET_SessionId") >= 0))
//                    {
//                        log.Error("网页已经过期，请重新登录");
//                        if (oldCookie != null)
//                        {
//                            RemoveOnlineUser(oldCookie.Value);
//                        }
//                    }
//                }
//            }

//            //RedirectToAction("SessionTimeOut", "Error");
//            if (getOnlineUser() != null || controllerName.Equals("Home")
//                || controllerName.Equals("Error") || controllerName.Equals("MobileHome"))
//                return;

//            if (oldCookie != null)
//            {
//                RemoveOnlineUser(oldCookie.Value);
//            }


//            filterContext.Result = json(new JsonMessage(false, "网页已经过期，请重新登录！"));

//            //Response.Clear();

//            //RouteData routeData = filterContext.RouteData;//new RouteData();

//            //routeData.Values["controller"] = "Error";

//            //routeData.Values.Add("action", "SessionTimeOut");

//            //filterContext. = true;

//            //IController errorController = new ErrorController();

//            //errorController.Execute(new RequestContext(HttpContext, routeData));



//        }


//        protected override void OnException(ExceptionContext filterContext)
//        {
//            // 此处进行异常记录，可以记录到数据库或文本，也可以使用其他日志记录组件。

//            string errorMessage = filterContext.Exception.Message;

//            // 执行基类中的OnException
//            base.OnException(filterContext);

//            log.Error("controller exception:" + errorMessage);
//            log.Error(filterContext.Exception.StackTrace);

//            // 重定向到异常显示页或执行其他异常处理方法
//            //Response.Redirect("/");

//            //return;

//            Response.Clear();

//            RouteData routeData = new RouteData();

//            routeData.Values.Add("controller", "Error");

//            routeData.Values.Add("action", "HttpError500");

//            routeData.Values.Add("error", errorMessage);

//            filterContext.ExceptionHandled = true;

//            IController errorController = new ErrorController();

//            errorController.Execute(new RequestContext(HttpContext, routeData));

//        }


//        protected ActionResult json(object _data)
//        {
//            //return new JsonNetResult(_data);
//            return Json(_data, JsonRequestBehavior.AllowGet);
//        }

//        protected ActionResult json(Boolean success, object data)
//        {
//            return json(new JsonMessage(success, data));
//        }


//        protected ActionResult json(Boolean success, String msg)
//        {
//            return json(new JsonMessage(success, msg));
//        }


//        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
//        {
//            return new CustomJsonResult { Data = data, ContentType = contentType, ContentEncoding = contentEncoding, JsonRequestBehavior = behavior };
//        }


//        protected ActionResult json(Boolean success)
//        {
//            return json(new JsonMessage(success));
//        }

//        public virtual ActionResult Delete(int EntityId)
//        {

//            try
//            {
//                BaseDao.delete(getEntityType(), EntityId);
//                return json(new JsonMessage(true));
//            }
//            catch (Exception ex)
//            {
//                return json(new JsonMessage(false, ex.Message));
//            }
//        }


//        public virtual ActionResult FakeDelete(int EntityId)
//        {
//            //EntityId = -1;

//            try
//            {
//                //BaseDao.delete(getEntityType(), EntityId);
//                TenantEntity entity = (TenantEntity)BaseDao.load(getEntityType(), EntityId);

//                entity.Deleted = true;

//                BaseDao.saveOrUpdate(entity);

//                return json(new JsonMessage(true));
//            }
//            catch (Exception ex)
//            {
//                return json(new JsonMessage(false, ex.Message));
//            }
//        }


//        public virtual ActionResult Edit(int EntityID = 0)
//        {
//            Object entity = null;
//            if (EntityID == 0)
//            {
//                entity = Activator.CreateInstance(this.getEntityType());
//            }
//            else
//            {
//                entity = BaseDao.load(getEntityType(), EntityID);
//            }

//            //object temp = entity.MemberwiseClone();

//            // return json(entity);
//            ViewData["Entity"] = entity;
//            ViewData["entity"] = entity;
//            return View("edit");
//        }
//        public virtual ActionResult Cancel(int EntityId)
//        {
//            TenantEntity entity = (TenantEntity)BaseDao.load(getEntityType(), EntityId);

//            entity.Deleted = true;

//            BaseDao.saveOrUpdate(entity);


//            return json(new JsonMessage(true, entity));
//        }

//        public virtual ActionResult Update(int EntityId)
//        {

//            Hashtable ht = getRequestParameter();
//            object entity = populate(EntityId, ht);

//            try
//            {
//                TenantEntity te = (TenantEntity)entity;
//                te.CreateDate = DateTime.Now;
//                BaseDao.saveOrUpdate(entity);
//                // EntityId = ((IEntity)entity).EntityId;

//                //return json(new JsonMessage(true, entity));
//                ViewData["Message"] = "保存成功";
//            }
//            catch (Exception ex)
//            {
//                log.Error(ex.Message, ex);
//                ViewData["Message"] = "保存错误：" + ex.Message;
//            }
//            ViewData["Entity"] = entity;
//            return View("edit");
//        }


//        public UserInfo getOnlineUser()
//        {
//            UserInfo u = (UserInfo)Session[ONLINE_USER_KEY];

//            return u;
//        }


//        public void setOnlineUser(UserInfo u)
//        {
//            this.PutInSession(ONLINE_USER_KEY, u);
//        }


//        public Object GetFromSession(String sessionKey)
//        {
//            return Session[sessionKey];
//        }

//        protected Hashtable GetUserPermission()
//        {
//            Hashtable u = (Hashtable)Session[ONLINE_USER_PERMISSION];

//            return u;
//        }

//        protected bool HasPermission(string key)
//        {
//            Hashtable ht = GetUserPermission();

//            return ht != null && ht.Contains(key);
//        }

//        protected void setAuthorizedDep(UserInfo user)
//        {
//            //如果是车牌号登录用户是没有部门权限的
//            if (user == null)
//                return;

//            Hashtable authorizedDepIdMap = new Hashtable();
//            IList<Department> depSet = user.Departments;

//            if (user.UserFlag == UserInfo.USER_FLAG_SUPER_ADMIN && depSet.Count == 0)
//            {
//                //如果是超级用户，将加所有权限,可以分配所有管理部门
//                String hql = "from Department where deleted = ?";
//                IList allDepList = this.BaseService.query(hql, false);
//                foreach (Object obj in allDepList)
//                {
//                    Department dep = (Department)obj;
//                    authorizedDepIdMap[dep.Code
//                        ] = dep.Code;

//                }
//            }
//            else
//            {
//                foreach (Department dep in depSet)
//                {
//                    if (dep.Enable == false)
//                    {
//                        authorizedDepIdMap[dep.Code] = dep.Code;
//                    }
//                }
//            }

//            //授权管理的部门
//            Session[SESSION_KEY_DEP] = authorizedDepIdMap;
//        }
//        protected List<int> getAuthorizedDepIdList()
//        {
//            Hashtable depIdMap = (Hashtable)Session[SESSION_KEY_DEP];
//            ICollection values = depIdMap.Values;

//            List<int> res = new List<int>();
//            foreach (int depId in values)
//            {
//                res.Add(depId);
//            }
//            return res;
//        }

//        /**
//	 * 用户是否有某个功能的权限
//	 * @param funcName
//	 * @return
//	 */
//        protected bool isAuthorized(String funcName)
//        {
//            Dictionary<String, FuncModel> funcMap = (Dictionary<String, FuncModel>)GetFromSession(SESSION_KEY_FUNCTION_MAP);
//            return funcMap != null && funcMap.ContainsKey(funcName);
//        }
//        /**
//	 * 每个用户会分配经过授权的车组,判断车组是否是用户的权限中所辖部门.
//	 * @param depId
//	 * @return
//	 */
//        protected bool isAuthorizedDep(int depId)
//        {
//            Hashtable depIdMap = (Hashtable)Session[SESSION_KEY_DEP];
//            return depIdMap != null && depIdMap.ContainsKey(depId);
//        }

//        public void PutInSession(string key, Object obj)
//        {
//            Session[key] = obj;
//        }

//        protected object populate(int EntityId, Hashtable ht)
//        {
//            return this.populate(EntityId, ht, this.getEntityType());
//        }
//        protected object populate(int EntityId, Hashtable ht, Type classType)
//        {
//            object entity = null;
//            if (EntityId > 0)
//            {
//                entity = BaseDao.load(classType, EntityId);
//            }
//            else
//            {
//                object[] args = { };
//                ht[EntityId] = 0;
//                ht["CreateDate"] = System.DateTime.Now;
//                ht["CreatId"] = getOnlineUser().EntityId.ToString();
//                ht["TenantId"] = getOnlineUser().TenantId.ToString();
//                entity = Activator.CreateInstance(classType, args);
//            }
//            PropertyHandler.copyProperties(entity, ht);

//            return entity;
//        }



//        protected Hashtable getRequestParameter()
//        {
//            NameValueCollection ns = Request.QueryString;

//            Hashtable ht = new Hashtable();

//            string[] keys = ns.AllKeys;

//            for (int m = 0; m < keys.Length; m++)
//            {
//                string key = keys[m];

//                string[] value = ns.GetValues(key);

//                if (value.Length == 1 && value[0].Length > 0)
//                {
//                    ht.Add(key, value[0]);
//                }
//                else
//                {
//                    //ht.Add(key, value);
//                }

//            }

//            for (int i = 0; i < Request.Form.Count; i++)
//            {
//                ht["" + Request.Form.Keys[i]] = "" + Request.Form[i];
//            }


//            return ht;
//        }
//        /// <summary>
//        /// 获取参数值数组
//        /// </summary>
//        /// <param name="ht"></param>
//        /// <param name="paramName"></param>
//        /// <returns></returns>
//        protected string[] getParameterValues(Hashtable ht, string paramName)
//        {
//            object obj = ht[paramName];

//            if (obj == null)
//                return null;

//            if (obj.GetType().Name == "String")
//                return new string[] { (string)obj };

//            return (string[])obj;
//        }
//        /// <summary>
//        /// 获取参数值
//        /// </summary>
//        /// <param name="ht"></param>
//        /// <param name="paramName"></param>
//        /// <returns></returns>
//        protected string getParameterValue(Hashtable ht, string paramName)
//        {
//            object obj = ht[paramName];

//            return (string)obj;
//        }

//        protected void CountOnlineUser(string SessionId, int UserId, string Name)
//        {
//            Hashtable onlineUsers = (Hashtable)HttpContext.Application[ONLINE_USER_KEY];

//            try
//            {

//                if (onlineUsers == null)
//                {
//                    onlineUsers = new Hashtable();
//                    HttpContext.Application[ONLINE_USER_KEY] = onlineUsers;
//                }
//                onlineUsers[SessionId] = UserId + "/" + Name + "/" + System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");



//                UserInfo u = getOnlineUser();

//            }
//            catch (Exception ex)
//            {
//                XTrace.WriteException(ex);
//            }

//        }

//        protected void RemoveOnlineUser(string SessionId)
//        {
//            try
//            {

//                UserInfo u = getOnlineUser();

//                Session[ONLINE_USER_KEY] = null;


//                Session.Clear();

//                Hashtable onlineUsers = (Hashtable)HttpContext.Application[ONLINE_USER_KEY];


//                if (onlineUsers != null && SessionId != null)
//                {
//                    onlineUsers.Remove(SessionId);
//                }
//            }
//            catch (Exception ex)
//            {
//                log.Error("退出登录时，发生异常：" + ex.Message);
//            }

//        }
//        /// <summary>
//        /// 获取系统配置
//        /// </summary>
//        /// <returns></returns>
//        public SystemConfig getSystemConfig()
//        {
//            SystemConfig config = (SystemConfig)GetFromSession(SESSION_KEY_SYSTEM_CONFIG);
//            if (config == null)
//                return new SystemConfig();
//            return config;
//        }

//        /// <summary>
//        /// 获取地图类型
//        /// </summary>
//        /// <returns></returns>
//        protected String getMapType()
//        {
//            UserInfo user = this.getOnlineUser();
//            if (user != null)
//            {
//                return user.MapType;
//            }
//            return Constants.MAP_BAIDU;
//        }

//        /// <summary>
//        /// 用户描述
//        /// </summary>
//        /// <param name="UserId"></param>
//        /// <returns></returns>
//        protected string GetLongUserDescr(int UserId)
//        {
//            Hashtable onlineUsers = (Hashtable)HttpContext.Application[ONLINE_USER_KEY];

//            if (onlineUsers == null)
//                return "";

//            try
//            {

//                IList keys = new ArrayList(onlineUsers.Keys);

//                foreach (String key in keys)
//                {
//                    string userLogin = (string)onlineUsers[key];

//                    if (userLogin != null && userLogin.IndexOf(UserId + "/") == 0)
//                    {
//                        return userLogin;
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                XTrace.WriteException(ex);
//            }

//            return "";
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="message"></param>
//        protected void setMessage(String message)
//        {
//            ViewData["message"] = message;
//            this.message = message;
//        }

//        public void LogOperation(String detail)
//        {
//            try
//            {
//                UserInfo u = this.getOnlineUser();
//                if (u != null)
//                {
//                    OperationLog log = new OperationLog();
//                    log.UserId = u.EntityId;
//                    log.UserName = u.Name;
//                    log.Detail = detail;
//                    log.Url = this.Request.Url.LocalPath;
//                    log.Ip = this.Request.UserHostAddress + "[" + this.Request.UserHostName + "]" + this.Request.Browser.Type;

//                    BaseService.saveOrUpdate(log);
//                }
//            }
//            catch (Exception ex)
//            {
//                XTrace.WriteException(ex);
//            }
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="fieldValue"></param>
//        /// <param name="parentCode"></param>
//        /// <returns></returns>
//        protected String convert(String fieldValue, String parentCode)
//        {
//            BasicInfo bd = BasicDataService.getBasicDataByCode(fieldValue,
//                    parentCode);
//            if (bd != null)
//            {
//                return bd.Name;
//            }
//            return "";
//        }

//        /// <summary>
//        /// 基础数据转换，将数据表中标志字段转换为文字描述
//        /// </summary>
//        /// <param name="rowData"></param>
//        /// <param name="field"></param>
//        /// <param name="parentCode"></param>
//        /// <returns></returns>
//        protected String convert(Hashtable rowData, String field, String parentCode)
//        {
//            String fieldValue = "" + rowData[field];
//            BasicInfo bd = BasicDataService.getBasicDataByCode(fieldValue,
//                    parentCode);
//            if (bd != null)
//            {
//                rowData[field] = bd.Name;
//                return bd.Name;
//            }
//            return "";
//        }

//    }
//}
