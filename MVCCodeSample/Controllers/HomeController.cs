using MVCCodeSample.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCodeSample.Controllers
{
    public class HomeController : BaseController
    {
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        [AuthorizeUser]
        public ActionResult Details()
        {
            return View();
        }

        [AuthorizeUser(Role = "Administrator")]
        public ActionResult DetailsAdmin()
        {
            return View();
        }

        [AuthorizeUser(Role = "Moderator")]
        public ActionResult DetailsMod()
        {
            return View();
        }

    }
}
