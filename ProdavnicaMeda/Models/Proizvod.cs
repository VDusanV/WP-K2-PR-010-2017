using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProdavnicaMeda.Models
{
    public class Proizvod
    {
        public string Naziv { get; set; }
        public string VrstaMeda { get; set; }
        public string  Proizvodjac { get; set; }
        public string AdresaProizvodjaca { get; set; }
        public string Boja { get; set; }
        public string  Opis { get; set; }
        public double Cena { get; set; }
        public int KolicinaTegli { get; set; }

        public Proizvod(string naz,string vrsta, string proizvodj, string adr, string boja, string opis, double cena, int kolicina)
        {
            Naziv = naz;
            VrstaMeda = vrsta;
            Proizvodjac = proizvodj;
            AdresaProizvodjaca = adr;
            Boja = boja;
            Opis = opis;
            Cena = cena;
            KolicinaTegli = kolicina;
        }
    }
}