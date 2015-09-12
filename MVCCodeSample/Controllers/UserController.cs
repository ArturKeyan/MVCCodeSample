using MVCCodeSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCCodeSample.Controllers
{
    public class UserController : BaseController
    {
        // GET: /User/Login
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (unit.UserRepository.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, true);                      
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username/email and password combination");
                }
            }

            return View(model);
        }


        // GET: /User/Register
        [HttpGet]
        public ActionResult Register()
        {
            var model = new RegisterVModel()
            {
                Roles = GetRolesListItems()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegisterVModel model)
        {
            if (ModelState.IsValid)
            {
                if (unit.UserRepository.RegisterUser(model.UserName, model.Email, model.Password, model.RoleId))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, true);    
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError("", "User registration failed");
                }
            }

            model.Roles = GetRolesListItems();
            return View(model);
        }

        // Get: /User/Logout
        [HttpGet]
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }
        
        public IEnumerable<SelectListItem> GetRolesListItems()
        {
            return unit.RoleRepository.GetAll().Select(m => new SelectListItem
            {
                Text = m.Name,
                Value = m.Id.ToString()
            });
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return Redirect("/");
            }
        }
    }
}
