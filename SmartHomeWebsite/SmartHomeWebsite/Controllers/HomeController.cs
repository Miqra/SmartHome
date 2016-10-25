using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.Mvc;

namespace SmartHomeWebsite.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        Crypto Crypto = new Crypto();
        [HttpGet]
        public ActionResult Index(string usr, string pwd)
        {
            var username = System.Web.HttpContext.Current.Session["Username"];
            var password = System.Web.HttpContext.Current.Session["Password"];
            if (username != "" && password != "")
            {
                return View();
            }
            else if (usr == "ismayil" && Crypto.DeCrypt(pwd) == "123")
            {
                this.Session["Username"] = usr;
                this.Session["Password"] = "123";
                return View();
            }
            return RedirectToAction("Login", "Account", "Login");
        }
        [HttpPost]
        public JsonResult SendData(string text,string text2)
        {
           
            UdpClient udpClient = new UdpClient();
            IPAddress ip = IPAddress.Parse("192.168.0.1");
            IPEndPoint ipEndPoint = new IPEndPoint(ip, 2050);
            byte[] content = new byte[2] {Convert.ToByte(text), Convert.ToByte(text2) };
            int count = udpClient.Send(content, content.Length, ipEndPoint);
            return Json(count, JsonRequestBehavior.AllowGet);
        }



    }
}
