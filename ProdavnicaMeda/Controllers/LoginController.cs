using ProdavnicaMeda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProdavnicaMeda.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {          
            
                Dictionary<string, Korisnik> korisnici = Data.UcitajKorisnike();
                return View(korisnici);      
        }
        public ActionResult Loguj(string korisnicko,string lozinka)
        {
            Dictionary<string, Korisnik> korisnici = (Dictionary<string, Korisnik>)HttpContext.Application["korisnici"];
            if(korisnici.ContainsKey(korisnicko) && korisnici[korisnicko].Lozinka == lozinka)
            {
                
                Session["korisnik"] = korisnici[korisnicko];
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Dictionary<string, Korisnik> admini = (Dictionary<string, Korisnik>)HttpContext.Application["admini"];
                if(admini.ContainsKey(korisnicko) && admini[korisnicko].Lozinka == lozinka)
                {
                    Session["admin"] = admini[korisnicko];
                    return RedirectToAction("Index", "Home");

                }


                ViewBag.Message = "Neuspesno logovanje";
                return View("Index");
            }
        }
    }
}