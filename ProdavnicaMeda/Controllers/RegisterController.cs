using ProdavnicaMeda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProdavnicaMeda.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dodaj(Korisnik k)
        {
            Dictionary<string, Korisnik> korisnici = (Dictionary<string, Korisnik>)HttpContext.Application["korisnici"];

            korisnici.Add(k.KorisnickoIme,k);
            Data.UpisiKorisnika(k);
            return RedirectToAction("Index", "login");
        }
    }
}