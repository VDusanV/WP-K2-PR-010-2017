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
            
                List<Proizvod> sorted = new List<Proizvod>() { };
                double s=0;
                if (Request["sortiraj"] == "Nazivu")
                {
                    sorted = p.OrderBy(l => l.Naziv).ToList();
                }
                else if (Request["sortiraj"] == "Vrsti meda")
                {
                    sorted = p.OrderBy(l => l.VrstaMeda).ToList();
                }
                else if(Request["sortiraj"] == "Ceni (opadajuca)")
                {
                    sorted = p.OrderBy(l => l.Cena).ToList();
                }
                else if (Request["cenalist"] != null && Request["cena"]!= null)
                {
                    try
                    {
                        s = double.Parse(Request["cena"]);
                    }
                    catch (Exception)
                    {

                       
                    }
                    if(Request["cenalist"]=="Skuplji od")
                    {
                        foreach (var item in p)
                        {
                            if (s <= item.Cena)
                            {
                                sorted.Add(item);
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in p)
                        {
                            if (s >= item.Cena)
                            {
                                sorted.Add(item);
                            }
                        }
                    }
                }
                else
                {
                        sorted = p.OrderBy(l => l.Cena).ToList();
                        sorted.Reverse();

                }
                return View("Index",sorted);
            
          

        }
    }
}