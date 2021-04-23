using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        Context context = new Context();

        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var cariGetir = context.Caris.FirstOrDefault(x => x.CariMail == mail);
            return View(cariGetir);
        }

        //[HttpPost]
        //public ActionResult Index(Cari cari)
        //{
        //    var mail = (string)Session["CariMail"];
        //    var gelenCari = context.Caris.Find(x => x.);
        //    gelenCari.CariAdi = cari.CariAdi;
        //    gelenCari.CariMail = cari.CariMail;
        //    gelenCari.CariSehir = cari.CariSehir;
        //    gelenCari.CariSifre = cari.CariSifre;
        //    gelenCari.CariSoyadi = cari.CariSoyadi;
        //    context.SaveChanges();
        //    return View();
        //}
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var cariId = context.Caris.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariId).FirstOrDefault();
            var cariSiparisleri = context.SatisHareketleris.Where(x => x.CariId == cariId).ToList();
            return View(cariSiparisleri);
        }

        public ActionResult GelenMesajlar()
        {
            return View();
        }

    }
}