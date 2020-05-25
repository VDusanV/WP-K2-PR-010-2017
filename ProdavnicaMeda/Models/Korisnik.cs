using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProdavnicaMeda.Models
{
    public enum TipKorisnika
    {
        ADMINISTRATOR,
        KUPAC
    }
    public enum Pol
    {
        MUSKI,
        ZENSKI
    }
    public class Korisnik
    {
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public Pol Pol { get; set; }
        public string Email { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public TipKorisnika Uloga { get; set; }

        public Korisnik()
        {
            KorisnickoIme = "";
            Lozinka = "";
            Ime = "";
            Prezime = "";
            Pol = Pol.MUSKI;
            Email = "";
            DatumRodjenja = DateTime.Now;
            Uloga = TipKorisnika.KUPAC;
        }
        public Korisnik(string q,string w,string e,string r, Pol t, string y,DateTime u,TipKorisnika i)
        {
            KorisnickoIme =q;
            Lozinka = w;
            Ime = e;
            Prezime =r;
            Pol = t;
            Email = y;
            DatumRodjenja = u;
            Uloga = i;
        }
    }
}