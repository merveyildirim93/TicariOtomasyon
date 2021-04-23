using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var cariler = context.Caris.Where(x => x.Durum == true).ToList();
            return View(cariler);
        }

        public ActionResult cariEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult cariEkle(Cari cari)
        {
            cari.Durum = true;
            context.Caris.Add(cari);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
           var cari = context.Caris.Find(id);
            cari.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGetir(int id)
        {
            var cari = context.Caris.Find(id);
            return View("CariGetir", cari);
        }

        [HttpGet]
        public ActionResult CariGuncelle(int id)
        {
            var cari = context.Caris.Find(id);
            return View("CariGuncelle", cari);
        }
        [HttpPost]
        public ActionResult cariGuncelle(Cari gelenCari)
        {
            if(!ModelState.IsValid) return View("CariGuncelle");
            var cari = context.Caris.Find(gelenCari.CariId);
            cari.CariAdi = gelenCari.CariAdi;
            cari.CariSoyadi = gelenCari.CariSoyadi;
            cari.CariSehir = gelenCari.CariSehir;
            cari.CariMail = gelenCari.CariMail;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSatislar(int id)
        {
            var satislar = context.SatisHareketleris.Where(x => x.CariId == id).ToList();
            var cariAd = context.Caris.Where(x => x.CariId == id).Select(y => y.CariAdi + " " + y.CariSoyadi).FirstOrDefault();
            ViewBag.CariAdi = cariAd;
            return View(satislar);
        }
    }
}