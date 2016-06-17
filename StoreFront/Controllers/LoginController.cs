using StoreFront.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StoreFront.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            var x = new LoginViewModel();
            return View(x);
        }

        public ActionResult Login(LoginViewModel login)
        {
            using (var context = new StoreFrontDal.StoreFrontEntities())
            {
                var user = context.Users.FirstOrDefault(x => x.UserName == login.UserName && "test" == login.Password);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);

                    login.Name = user.UserName;
                    return View(login);
                }

                return View("Index", "Login", login);
            }
        }
    }
}