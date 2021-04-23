using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;
namespace TicariOtomasyon.Controllers
{
    public class IstatistikController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var toplamCari = context.Caris.Count().ToString();
            ViewBag.ToplamCari = toplamCari;

            var toplamUrun = context.Uruns.Count().ToString();
            ViewBag.ToplamUrun = toplamUrun;

            var toplamPersonel = context.Personels.Count().ToString();
            ViewBag.ToplamPersonel = toplamPersonel;

            var toplamKategori = context.Kategoris.Count().ToString();
            ViewBag.ToplamKategori = toplamKategori;

            var toplamStok = context.Uruns.Sum(x => x.Stok).ToString();
            ViewBag.ToplamStok = toplamStok;

            var kritikUrun = context.Uruns.Count(x => x.Stok <= 20).ToString();
            ViewBag.KritikUrun = kritikUrun;

            var toplamMarka = (from x in context.Uruns select x.Marka).Distinct().Count().ToString();
            ViewBag.ToplamMarka = toplamMarka;

            var maxFiyatliUrun = (from x in context.Uruns orderby x.SatisFiyati descending select x.UrunAdi).FirstOrDefault();
            ViewBag.MaxFiyatliUrun = maxFiyatliUrun;

            var minFiyatliUrun = (from x in context.Uruns orderby x.SatisFiyati ascending select x.UrunAdi).FirstOrDefault();
            ViewBag.MinFiyatliUrun = minFiyatliUrun;

            var beyazEsya = context.Uruns.Count(x => x.KategoriId == 1).ToString();
            ViewBag.BeyazEsya = beyazEsya;

            var televizyon = context.Uruns.Count(x => x.KategoriId == 7).ToString();
            ViewBag.Televizyon = televizyon;

            var kasaTutar = context.SatisHareketleris.Sum(x => x.ToplamTutar).ToString();
            ViewBag.KasaTutar = kasaTutar;

            var bugunkiSatis = context.SatisHareketleris.Count(x => x.Tarih == DateTime.Today).ToString();
            ViewBag.BugunkiSatis = bugunkiSatis;

            var bugunkiKasa = context.SatisHareketleris.Where(x => x.Tarih == DateTime.Today).Sum(y => y.ToplamTutar).ToString();
            ViewBag.BugunkiKasa = bugunkiKasa;

            var maxMarka = context.Uruns.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.MaxMarka = maxMarka;

            var enCokSatan = context.Uruns.Where(u => u.UrunId == (context.SatisHareketleris.GroupBy(x => x.UrunId).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(a => a.UrunAdi).FirstOrDefault();
            ViewBag.EnCokSatan = enCokSatan;
            return View();
        }

        public ActionResult BasitTablolar()
        {
            var sorgu = from x in context.Caris
                        group x by x.CariSehir into sehir
                        select new GrupSiniflari
                        {
                            Sehir = sehir.Key,
                            Adet = sehir.Count()
                        };
            return View(sorgu.ToList());
        }

        public PartialViewResult DepartmanPersonal()
        {
            var personelSorgu = from x in context.Personels
                                group x by x.Departman.DepartmanAdi into personel
                                select new PersonelGrupSinif
                                {
                                    Departman = personel.Key,
                                    Adet = personel.Count()
                                };
            return PartialView(personelSorgu.ToList());
        }

        public PartialViewResult CariPartial()
        {
            var cariler = context.Caris.Where(x => x.Durum == true).Take(7).ToList();
            return PartialView(cariler);
        }

        public PartialViewResult UrunPartial()
        {
            var urunler = context.Uruns.Where(x => x.Durum == true).ToList();
            return PartialView(urunler);
        }

        public PartialViewResult UrunMarkalari()
        {
            var markaSorgu = from x in context.Uruns
                                group x by x.Marka into marka
                                select new MarkaGrupSinif
                                {
                                    Marka = marka.Key,
                                    Adet = marka.Count()
                                };
            return PartialView(markaSorgu.ToList());
        }

        public PartialViewResult UrunKategorileri()
        {
            var kategoriSorgu = from x in context.Uruns
                             group x by x.Kategori.KategoriAd into kategori
                             select new KategoriGrupSinif
                             {
                                 Kategori = kategori.Key,
                                 Adet = kategori.Count()
                             };
            return PartialView(kategoriSorgu.ToList());
        }
    }
}