﻿using System;
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

            // Kategori listesini ViewBag'e ata
            ViewBag.Kategoriler = db.TBLKATEGORILER.Select(x => new SelectListItem
            {
                Text = x.KATEGORIAD,
                Value = x.KATEGORIID.ToString()
            }).ToList();

            if (Session["KULLANICI"] == null)  // Eğer giriş yapılmamışsa
            {
                return RedirectToAction("Index", "Login"); // Login sayfasına yönlendir
            } 
            //yukarıdaki kodları kullanıcıyı kısıtlamak için yaptım giriş yapılmamışsa sayfayı görememez

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

        public JsonResult UrunGetir(int id)
        {
            var urun = db.TBLURUNLER.Find(id);
            if (urun != null)
            {
                return Json(new
                {
                    URUNID = urun.URUNID,
                    URUNAD = urun.URUNAD,
                    MARKA = urun.MARKA,
                    URUNKATEGORI = urun.URUNKATEGORI,
                    FIYAT = urun.FIYAT,
                    STOK = urun.STOK,
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }
        //musteri isim ve soy isimleri getiriyor kutulara getirmeyi sağlıyor

        [HttpPost]
        public ActionResult UrunGuncelle(TBLURUNLER urun)
        {
            var urn = db.TBLURUNLER.Find(urun.URUNID);
            if (urn != null)
            {
                urn.URUNAD = urun.URUNAD;
                urn.MARKA = urun.MARKA;
                urn.URUNKATEGORI = urun.URUNKATEGORI;
                urn.FIYAT = urun.FIYAT;
                urn.STOK = urun.STOK;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        //musteri ve soy isimlerini  güncelleme işlemi yapıyoruz 

        private void KategorileriGetir()
        {
            ViewBag.Kategoriler = db.TBLKATEGORILER
                .Select(k => new SelectListItem
                {
                    Text = k.KATEGORIAD,
                    Value = k.KATEGORIID.ToString()
                }).ToList();
        }

    }
}