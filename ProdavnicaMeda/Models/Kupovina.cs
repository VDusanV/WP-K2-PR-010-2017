using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProdavnicaMeda.Models
{
    public class Kupovina
    {
        public Korisnik Kupac { get; set; }
        public Proizvod _Proizvod { get; set; }
        public DateTime DatumKupovine { get; set; }
        public int NarucenBrojTegli { get; set; }
        public double NaplacenaCena { get; set; }

    }
}