using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProje.Models.Entity;


namespace MvcProje.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcStokEntities db = new MvcStokEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORILER.ToList();
            return View(degerler);
        }


        [HttpPost]
        public ActionResult KategoriEkle(TBLKATEGORILER kategori)
        {
          
            try
            {
                db.TBLKATEGORILER.Add(kategori);
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
            var kategori = db.TBLKATEGORILER.Find(id);
            if (kategori != null)
            {
                db.TBLKATEGORILER.Remove(kategori);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        //yukarıdaki sil kod bloğu sweetalert ile silme işlemini gerçekleştiriyor

        public JsonResult KategoriGetir(int id)
        {
            var kategori = db.TBLKATEGORILER.Find(id);
            if (kategori != null)
            {
                return Json(new
                {
                    KATEGORIID = kategori.KATEGORIID,
                    KATEGORIAD = kategori.KATEGORIAD,
                    KATEGORI_EN = kategori.KATEGORI_EN,
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }
        //kategorileri kutulara getirmeyi sağlıyor

        [HttpPost]
        public ActionResult KategoriGuncelle(TBLKATEGORILER kategori)
        {
            
            var ktg = db.TBLKATEGORILER.Find(kategori.KATEGORIID);
            if (ktg != null)
            {
                ktg.KATEGORIAD = kategori.KATEGORIAD;
                ktg.KATEGORI_EN = kategori.KATEGORI_EN;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        //kategorileri güncelleme işlemi yapıyoruz 

    }



}