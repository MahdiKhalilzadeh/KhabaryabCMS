using KhabaryabCMS.Models;
using KhabaryabCMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KhabaryabCMS.Controllers
{
    public class AccountController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        public ActionResult SignIn()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return Redirect("/");
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(SignInViewModel model, string ReturnUrl = "/")
        {
            if (Request.IsAuthenticated)
                return Redirect("/");

            if (!ModelState.IsValid)
            {
                model.Password = "";
                return View(model);
            }

            Admin admin = db.Admins.FirstOrDefault(i => i.Username.ToLower() == model.Username.ToLower() && i.Password == model.Password);
            if (admin == null)
            {
                ModelState.AddModelError("Username", "کاربری با این نام کاربری یا رمز ورود پیدا نشد!");
                return View(model);
            }

            FormsAuthentication.SetAuthCookie(model.Username, model.RememberSession);
            return Redirect("/");
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}