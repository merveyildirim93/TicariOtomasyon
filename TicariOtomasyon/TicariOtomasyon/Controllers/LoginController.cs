using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public PartialViewResult YeniCariKaydi(Cari cari)
        {
            context.Caris.Add(cari);
            context.SaveChanges();
            return PartialView("Index");
        }
        [HttpPost]
        public ActionResult cariGiris(Cari formBilgileri)
        {
            var kullanici = context.Caris.FirstOrDefault(x => x.CariMail == formBilgileri.CariMail && x.CariSifre == formBilgileri.CariSifre);
            if (kullanici != null)
            {
                FormsAuthentication.SetAuthCookie(formBilgileri.CariMail, false);
                Session["CariMail"] = formBilgileri.CariMail;
                return RedirectToAction("Index","CariPanel");
            }
            else
            {
                return View("Index");
            }

        }

    }
}