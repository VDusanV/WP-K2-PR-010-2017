using ProdavnicaMeda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProdavnicaMeda.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Proizvod> p = (List<Proizvod>)HttpContext.Application["proizvodi"];
            return View(p);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Sortiraj()
        {
            List<Proizvod> p = (List<Proizvod>)HttpContext.Application["proizvodi"];
            //DORADITI PO CEMU SE SORTIRA
            List<Proizvod> sorted = p.OrderBy(l => l.Naziv).ToList();
            return View("Index",sorted);

        }
    }
}