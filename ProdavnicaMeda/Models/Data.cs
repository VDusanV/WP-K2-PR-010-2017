using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ProdavnicaMeda.Models
{
    public class Data
    {
        public static Dictionary<string,Korisnik> UcitajAdministratore()
        {
            Dictionary<string, Korisnik> ret = new Dictionary<string, Korisnik>() { };
            string path =HttpContext.Current.Server.MapPath("~/App_Data/Administratori.txt");
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
               string[] tokens = line.Split(';');

            
                string[] datumi = tokens[6].Split('/');
                DateTime date = new DateTime(Int32.Parse(datumi[2]), Int32.Parse(datumi[1]), Int32.Parse(datumi[0]));

                Korisnik k = new Korisnik(tokens[0], tokens[1], tokens[2], tokens[3], (Pol)(Enum.Parse(typeof(Pol), tokens[4])), tokens[5], date, TipKorisnika.ADMINISTRATOR) { };
                ret.Add(k.KorisnickoIme, k);
            }
            sr.Close();
            stream.Close();
            return ret;
        }

        public static List<Proizvod> UcitajProizvode()
        {
            List<Proizvod> ret = new List<Proizvod>() { };
            string path = HttpContext.Current.Server.MapPath("~/App_Data/Proizvodi.txt");
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] tokens = line.Split(';');
                double c;
                int k;
                try
                {
                    c = double.Parse(tokens[6]);
                    k = Int32.Parse(tokens[7]);
                }
                catch (Exception)
                {
                    c = 0;
                    k = 0;
                    
                }
                Proizvod p = new Proizvod(tokens[0], tokens[1], tokens[2], tokens[3],tokens[4],tokens[5],c,k) { };
                ret.Add(p);
            }
            sr.Close();
            stream.Close();
            return ret;
        }

        public static void UpisiKorisnika(Korisnik k)
        {
            string s = k.KorisnickoIme+';' + k.Lozinka + ';' + k.Ime + ';' + k.Prezime + ';' + k.Pol.ToString() + ';' + k.Email + ';' + k.DatumRodjenja.ToString();

           string path = HttpContext.Current.Server.MapPath("~/App_Data/Korisnici.txt");


            using (StreamWriter outputFile = new StreamWriter(Path.Combine(path), true))
            {
                outputFile.WriteLine(s);
            }
        }
        public static Dictionary<string,Korisnik> UcitajKorisnike()
        {
            Dictionary<string, Korisnik> ret = new  Dictionary<string, Korisnik>() { };
             string path = HttpContext.Current.Server.MapPath("~/App_Data/korisnici.txt");
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] tokens = line.Split(';');
             
                Korisnik p = new Korisnik(tokens[0], tokens[1], tokens[2], tokens[3], (Pol)Enum.Parse(typeof(Pol),tokens[4]), tokens[5],DateTime.Now,TipKorisnika.KUPAC) { };
                ret.Add(p.KorisnickoIme,p);
            }
            sr.Close();
            stream.Close();
            return ret;
        }
    }
}