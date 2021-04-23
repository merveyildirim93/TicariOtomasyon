using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{
    public class SatislarController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var satislar = context.SatisHareketleris.ToList();
            return View(satislar);
        }


        public ActionResult yeniSatis()
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
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(SatisHareketleri satis)
        {
            context.SatisHareketleris.Add(satis);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult satisGuncelle(int id)
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
            var satis = context.SatisHareketleris.Find(id);
            return View("SatisGuncelle", satis);
        }

        [HttpPost]
        public ActionResult SatisGuncelle(SatisHareketleri satis)
        {
            var satisBul = context.SatisHareketleris.Find(satis.SatisId);
            satisBul.Adet = satis.Adet;
            satisBul.CariId = satis.CariId;
            satisBul.Fiyat = satis.Fiyat;
            satisBul.PersonalId = satis.PersonalId;
            satisBul.Tarih = satis.Tarih;
            satisBul.ToplamTutar = satis.ToplamTutar;
            satisBul.UrunId = satis.UrunId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisDetaylari(int id)
        {
            var detay = context.SatisHareketleris.Where(x => x.SatisId == id).ToList();
            return View(detay);
        }
    }
}