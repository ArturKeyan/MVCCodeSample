using Membership.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCodeSample.Controllers
{
    public class BaseController : Controller
    {
        protected UnitOfWork unit;

        public BaseController()
        {
            unit = new UnitOfWork();
        }
    }
}