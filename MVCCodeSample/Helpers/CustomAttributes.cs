using Membership.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCodeSample.Helpers
{
    public class AuthorizeUserAttribute : AuthorizeAttribute
    {
        public string Role { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);

            if (!isAuthorized)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(Role))
            {
                using (var unit = new UnitOfWork())
                {
                    return unit.UserRepository.IsInRole(httpContext.User.Identity.Name, Role);
                }
            }
            return true;
        }
    }
}