using ProdavnicaMeda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ProdavnicaMeda
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            HttpContext.Current.Application["korisnici"] = new Dictionary<string, Korisnik>() { };
            HttpContext.Current.Application["admini"] = Data.UcitajAdministratore();
            HttpContext.Current.Application["proizvodi"] = Data.UcitajProizvode();
        }
    }
}
