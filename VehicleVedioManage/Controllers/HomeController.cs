using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using XCode.Membership;

namespace CubeDemo.Controllers
{
    /// <summary>主页面</summary>
    //[AllowAnonymous]
    public class HomeController : ControllerBaseX
    {
        private IHostEnvironment _hostEnvironment;
        private static string contentRootPath = "";
        public HomeController(IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            contentRootPath = _hostEnvironment.ContentRootPath;
        }
        /// <summary>主页面</summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            PageSetting.EnableNavbar = false;
            ViewBag.Message = "车载物联网平台";
            return View("Index");
        }
    }
}