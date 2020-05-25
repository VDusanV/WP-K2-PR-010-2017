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
            return View();
        }
        public ActionResult Loguj(string korisnicko,string lozinka)
        {
            Dictionary<string, Korisnik> korisnici = (Dictionary<string, Korisnik>)HttpContext.Application["korisnici"];
            if(korisnici.ContainsKey(korisnicko) && korisnici[korisnicko].Lozinka == lozinka)
            {
                
                Session["ulogovan"] = korisnici[korisnicko];
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Neuspesno logovanje";
                return View("Index");
            }
        }
    }
}