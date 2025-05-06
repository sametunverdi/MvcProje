using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProje.Models.Entity;


namespace MvcProje.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcStokEntities db = new MvcStokEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLURUNLER.ToList();
            return View(degerler);
        }

        [HttpPost]
        public ActionResult UrunEkle(TBLURUNLER Urun)
        {
            try
            {
                db.TBLURUNLER.Add(Urun);
                db.SaveChanges();
                return Json(new { success = true });
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }
        //yukarıdaki kod bloğu ürün ekleme işine yarıyor

        public ActionResult SIL(int id)
        {
            var urun = db.TBLURUNLER.Find(id);
            if (urun != null)
            {
                db.TBLURUNLER.Remove(urun);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        //yukarıdaki sil kod bloğu sweetalert ile silme işlemini gerçekleştiriyor
    }
}