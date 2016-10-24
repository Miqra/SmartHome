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
            if (usr == "ismayil" && Crypto.DeCrypt(pwd) == "123")
            {
                return View();
            }
            return RedirectToAction("Login", "Account", "Login");
        }
        [HttpPost]
        public EmptyResult SendData()
        {
            UdpClient udpClient = new UdpClient();
            IPAddress ip = IPAddress.Parse("192.168.0.1");
            IPEndPoint ipEndPoint = new IPEndPoint(ip, 2050);
            byte[] content = new byte[2] { 1, 1 };
            int count = udpClient.Send(content, content.Length, ipEndPoint);
            return new EmptyResult();
        }



    }
}
