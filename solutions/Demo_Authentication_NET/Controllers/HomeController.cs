using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_Authentication_NET.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles="User,Administrator,Developer")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //[Authorize(Roles="Administrator,Developer")]
        public ActionResult Contact()
        {
            if (User.IsInRole("Administrator") || User.IsInRole("Developer"))
            {
                ViewBag.Message = "Your contact page.";

                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}