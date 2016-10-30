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
      
        public ActionResult Index(string usr, string pwd)
        {
           
            if (Session["user"]==null)
            {
                return RedirectToAction("Login", "Account", "Login");
            }
            else 
            {
             
                return View();
            }
          
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
