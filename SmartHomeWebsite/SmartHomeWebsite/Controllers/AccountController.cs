using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHomeWebsite.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        Crypto Crypt = new Crypto();
        public ActionResult Login()
        
        {
            if (Request.RequestType == "POST")
            {
                return RedirectToAction("Index", "Home", new { usr = Request["name"], pwd = Crypt.Crypt(Request["password"]) });
            }
            return View();
        }

    }
}
