using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;


namespace TicariOtomasyon.Controllers
{

    public class UrunController : Controller
    {
        Context context = new Context();
        // GET: Urun
        public ActionResult Index(string search)
        {
            var urunler = from x in context.Uruns select x;
            if (!string.IsNullOrEmpty(search))
            {
                urunler = urunler.Where(y => y.UrunAdi.Contains(search));
            }
            return View(urunler.ToList());
        }
        [HttpGet]
        public ActionResult urunEkle()
        {
            List<SelectListItem> kategoriler = (from category in context.Kategoris.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = category.KategoriAd,
                                                    Value = category.KategoriId.ToString()
                                                }).ToList();
            ViewBag.KategoriListesi = kategoriler;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(Urun urun)
        {
            context.Uruns.Add(urun);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var urun = context.Uruns.Find(id);
            urun.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult urunGuncelle(int id)
        {
            List<SelectListItem> kategoriler = (from category in context.Kategoris.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = category.KategoriAd,
                                                    Value = category.KategoriId.ToString()
                                                }).ToList();
            ViewBag.KategoriListesi = kategoriler;
            var urun = context.Uruns.Find(id);
            return View("UrunGuncelle", urun);
        }
        [HttpPost]
        public ActionResult UrunGuncelle(Urun urun)
        {
            var products = context.Uruns.Find(urun.UrunId);
            products.UrunAdi = urun.UrunAdi;
            products.AlisFiyati = urun.AlisFiyati;
            products.KategoriId = urun.KategoriId;
            products.Marka = urun.Marka;
            products.SatisFiyati = urun.SatisFiyati;
            products.UrunFotografi = urun.UrunFotografi;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunListesi()
        {
            var urunler = context.Uruns.Where(x => x.Durum == true).ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult satisYap(int id)
        {
            List<SelectListItem> personels = (from x in context.Personels.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.PersonalAdi + " " + x.PersonalSoyadi,
                                                  Value = x.PersonalId.ToString()
                                              }).ToList();
            List<SelectListItem> uruns = (from x in context.Uruns.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.UrunAdi,
                                              Value = x.UrunId.ToString()
                                          }).ToList(); ;
            List<SelectListItem> caris = (from x in context.Caris.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CariAdi + " " + x.CariSoyadi,
                                              Value = x.CariId.ToString()
                                          }).ToList(); ;
            ViewBag.PersonelListe = personels;
            ViewBag.UrunListe = uruns;
            ViewBag.CariListe = caris;

            var urunBul = context.Uruns.Find(id);
            ViewBag.Fiyat = urunBul.SatisFiyati;
            ViewBag.Urun = urunBul.UrunAdi;
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public ActionResult SatisYap(SatisHareketleri satis)
        {
            context.SatisHareketleris.Add(satis);
            context.SaveChanges();
            return RedirectToAction("Index", "Satislar");
        }
    }
}