using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProje.Models.Entity;

namespace MvcProje.Controllers
{
    public class MusterilerController : Controller
    {
        // GET: Musteriler
        MvcStokEntities db = new MvcStokEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLMUSTERILER.ToList();
            return View(degerler);
        }

        [HttpPost]
        public ActionResult MusteriEkle(TBLMUSTERILER Musteri)
        {
            try
            {
                db.TBLMUSTERILER.Add(Musteri);
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
            var urun = db.TBLMUSTERILER.Find(id);
            if (urun != null)
            {
                db.TBLMUSTERILER.Remove(urun);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        //yukarıdaki sil kod bloğu sweetalert ile silme işlemini gerçekleştiriyor

        public JsonResult MusteriGetir(int id)
        {
            var musteri = db.TBLMUSTERILER.Find(id);
            if (musteri != null)
            {
                return Json(new
                {
                    MUSTERIID = musteri.MUSTERIID,
                    MUSTERIAD = musteri.MUSTERIAD,
                    MUSTERISOYAD = musteri.MUSTERISOYAD,
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }
        //musteri isim ve soy isimleri getiriyor kutulara getirmeyi sağlıyor

        [HttpPost]
        public ActionResult MusteriGuncelle(TBLMUSTERILER musteri)
        {
            var mus = db.TBLMUSTERILER.Find(musteri.MUSTERIID);
            if (mus != null)
            {
                mus.MUSTERIAD = musteri.MUSTERIAD;
                mus.MUSTERISOYAD = musteri.MUSTERISOYAD;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        //musteri ve soy isimlerini  güncelleme işlemi yapıyoruz 
    }

}