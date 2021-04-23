using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;
using PagedList;
using PagedList.Mvc;


namespace TicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        Context context = new Context();
        public ActionResult Index(int page = 1)
        {
            var kategoriler = context.Kategoris.ToList().ToPagedList(page,5);
            return View(kategoriler);
        }
        [HttpGet]
        public ActionResult kategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori kategori)
        {
            context.Kategoris.Add(kategori);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var kategori = context.Kategoris.Find(id);
            context.Kategoris.Remove(kategori);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult kategoriGuncelle(int id)
        {
            var kategori = context.Kategoris.Find(id);
            return View("KategoriGuncelle", kategori);
        }
        [HttpPost]
        public ActionResult KategoriGuncelle(Kategori kategori)
        {
            var category = context.Kategoris.Find(kategori.KategoriId);
            category.KategoriAd = kategori.KategoriAd;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}