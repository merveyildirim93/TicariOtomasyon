using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;
namespace TicariOtomasyon.Controllers
{
    public class ToDoListController : Controller
    {
        Context context = new Context();
        // GET: ToDoList
        public ActionResult Index()
        {
            var yapilacaklar = context.Yapilacaklars.ToList();
            return View(yapilacaklar);
        }
    }
}