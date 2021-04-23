using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var faturalar = context.Faturas.ToList();
            return View(faturalar);
        }

        public ActionResult yeniFatura()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniFatura(Fatura fatura)
        {
            context.Faturas.Add(fatura);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult faturaGuncelle(int id)
        {
            var fatura = context.Faturas.Find(id);
            return View("FaturaGuncelle", fatura);
        }

        [HttpPost]
        public ActionResult FaturaGuncelle(Fatura fatura)
        {
            var faturalar = context.Faturas.Find(fatura.FaturaId);
            faturalar.FaturaSaati = fatura.FaturaSaati;
            faturalar.FaturaSeriNo = fatura.FaturaSeriNo;
            faturalar.FaturaSiraNo = fatura.FaturaSiraNo;
            faturalar.FaturaTarihi = fatura.FaturaTarihi;
            faturalar.TeslimAlan = fatura.TeslimAlan;
            faturalar.TeslimEden = fatura.TeslimEden;
            faturalar.Tutar = fatura.Tutar;
            faturalar.VergiDairesi = fatura.VergiDairesi;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult FaturaDetay(int id)
        {
            var detay = context.FaturaKalems.Where(x => x.FaturaId == id).ToList();
            var faturaNo = context.Faturas.Where(x => x.FaturaId == id).Select(y => y.FaturaSeriNo + "" + y.FaturaSiraNo).FirstOrDefault();
            ViewBag.FaturaNo = faturaNo;
            return PartialView(detay);
        }

        public ActionResult yeniFaturaKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniFaturaKalem(FaturaKalem kalem)
        {
            context.FaturaKalems.Add(kalem);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}