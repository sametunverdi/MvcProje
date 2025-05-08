using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class DilController : Controller
    {
        public ActionResult Degistir(string lang)
        {
            if (!string.IsNullOrEmpty(lang))
            {
                Session["lang"] = lang;
            }

            // Geldiği sayfaya geri yönlendir
            string returnUrl = Request.UrlReferrer != null ? Request.UrlReferrer.ToString() : "/";
            return Redirect(returnUrl);
        }
    }
}