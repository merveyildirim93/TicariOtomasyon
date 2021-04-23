using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var personeller = context.Personels.ToList();
            return View(personeller);
        }

        public ActionResult personelEkle()
        {
            List<SelectListItem> departmanlar = (from departman in context.Departmans.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = departman.DepartmanAdi,
                                                     Value = departman.DepartmanId.ToString()
                                                 }).ToList();
            ViewBag.DepartmanListesi = departmanlar;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel personel)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string yol = "~/Image/Personel/" + dosyaAdi;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                personel.ProfilFotografi = "/Image/Personel/" + dosyaAdi;
            }
            context.Personels.Add(personel);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult personelGuncelle(int id)
        {
            List<SelectListItem> departmanlar = (from departman in context.Departmans.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = departman.DepartmanAdi,
                                                     Value = departman.DepartmanId.ToString()
                                                 }).ToList();
            ViewBag.DepartmanListesi = departmanlar;
            var personel = context.Personels.Find(id);
            return View("PersonelGuncelle", personel);
        }
        [HttpPost]
        public ActionResult PersonelGuncelle(Personel personel)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string yol = "~/Image/Personel/" + dosyaAdi;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                personel.ProfilFotografi = "/Image/Personel/" + dosyaAdi;
            }
            var pers = context.Personels.Find(personel.PersonalId);
            pers.PersonalAdi = personel.PersonalAdi;
            pers.PersonalSoyadi = personel.PersonalSoyadi;
            pers.ProfilFotografi = personel.ProfilFotografi;
            pers.DepartmanId = personel.DepartmanId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}