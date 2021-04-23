using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var departman = context.Departmans.Where(x => x.Durum == true).ToList();
            return View(departman);
        }

        public ActionResult departmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman departman)
        {
            context.Departmans.Add(departman);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DepartmanGuncelle(int id)
        {
            var departman = context.Departmans.Find(id);
            return View("DepartmanGuncelle", departman);
        }
        [HttpPost]
        public ActionResult departmanGuncelle(Departman departman)
        {
            var dep = context.Departmans.Find(departman.DepartmanId);
            dep.DepartmanAdi = departman.DepartmanAdi;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {
            var departman = context.Departmans.Find(id);
            departman.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var personels = context.Personels.Where(x => x.DepartmanId == id).ToList();
            var departmanAd = context.Departmans.Where(x => x.DepartmanId == id).Select(y => y.DepartmanAdi).FirstOrDefault();
            ViewBag.DepartmanAdi = departmanAd;
            return View(personels);
        }

        public ActionResult PersonelSatislari(int id)
        {
            var satislar = context.SatisHareketleris.Where(x => x.PersonalId == id).ToList();
            var personelAd = context.Personels.Where(x => x.PersonalId == id).Select(y => y.PersonalAdi + " " + y.PersonalSoyadi).FirstOrDefault();
            ViewBag.PersonelAdi = personelAd;
            return View(satislar);
        }
    }
}