using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartHomeWebsite.Models;

namespace SmartHomeWebsite.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        public ActionResult Login()
        {
            if (Session["user"]!=null)
            {
              return  RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username,string password)
        {
            if ("ismayil".Equals(username) && "123".Equals(password))
            {
                Session["user"] = new User { Login = username, Username = "DEMO", Password = password };
                return RedirectToAction("Index", "Home");
            }
          
              
           
            return View();
        }

        public ActionResult Logout ()
        {
            Session.Clear();
            return RedirectToAction("Login","Account");
        }

    }
}
