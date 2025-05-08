using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProje.Models.Entity;

namespace MvcProje.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        MvcStokEntities db = new MvcStokEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public ActionResult Index(string KULLANICIAD, string SIFRE)
        {
            if (KULLANICIAD == "admin" && SIFRE == "1234") // örnek kullanıcı
            {
                Session["KULLANICI"] = KULLANICIAD; // kullanıcıyı oturuma al
                return RedirectToAction("Index", "Kategori"); // tam sayfa yönlendirme
            }

            ViewBag.Mesaj = "Kullanıcı adı veya şifre hatalı!";
            return View();
        }


        public ActionResult Logout()
        {
            Session.Abandon(); // oturumu tamamen bitirir
            return RedirectToAction("Index", "Login");
            //bunu çıkış yapmak için ekledim
        }
    }
}