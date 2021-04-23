using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            IENumerableClass numerable = new IENumerableClass();
            numerable.urun = context.Uruns.Where(x => x.UrunId == 1).ToList();
            numerable.urunDetaylari = context.UrunDetaylaris.Where(x => x.UrunId == 1).ToList();
            return View(numerable);
        }
    }
}