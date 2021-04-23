using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{
    public class KargoController : Controller
    {
        Context context = new Context();
        public ActionResult Index(string search)
        {
            var kargolar = from x in context.Kargoes select x;
            if (!string.IsNullOrEmpty(search))
            {
                kargolar = kargolar.Where(y => y.TakipKodu.Contains(search));
            }
            // var kargolar = context.Kargoes.ToList();
            return View(kargolar.ToList());
        }

        [HttpGet]
        public PartialViewResult yeniKargo()
        {
            Random random = new Random();
            string[] karakter = { "A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "L", "M", "N", "P", "R" };
            int k1, k2, k3;
            k1 = random.Next(0, karakter.Length);
            k2 = random.Next(0, karakter.Length);
            k3 = random.Next(0, karakter.Length);
            int s1, s2, s3;
            s1 = random.Next(100, 1000);
            s2 = random.Next(10, 99);
            s3 = random.Next(10, 99);
            string randomTakipKodu = s1.ToString() + karakter[k1] + s2 + karakter[k2] + s3 + karakter[k3];
            ViewBag.RandomTakipNo = randomTakipKodu;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult YeniKargo(Kargo kargo)
        {
            context.Kargoes.Add(kargo);
            context.SaveChanges();
            return PartialView("Index");
        }

        public ActionResult Detay(string id)
        {
            var detaylar = context.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            ViewBag.TakipKodu = id;
            return View(detaylar);
        }
        //public ActionResult QRKodUret(string takipKodu)
        //{
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        QRCodeGenerator generator = new QRCodeGenerator();
        //        QRCodeGenerator.QRCode kareKod = generator.CreateQrCode(takipKodu, QRCodeGenerator.ECCLevel.Q);
        //        using (Bitmap resim = kareKod.GetGraphic(10))
        //        {
        //            resim.Save(ms, ImageFormat.Png);
        //            ViewBag.karekodImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
        //        }
        //        return View();
        //    }
        //}
    }
}