using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Bip.Controllers
{
    public class OudersController : Controller
    {
        BipClient client;

        public OudersController()
        {
            client = new BipClient(new System.Net.Http.HttpClient());
        }

        public ActionResult Index()
        {
            //var response = client.IngeschrevenpersonenBurgerservicenummeroudersAsync("0", null).Result;
            //IEnumerable<OuderHal> result = response._embedded.Ouders;

            //IEnumerable<OuderHal> result = new List<OuderHal>() { DummyOuder };

            return View();
        }

        public ActionResult Zoek(string apiVersionZoek, string bsnZoek)
        {
            var response = client.IngeschrevenpersonenBurgerservicenummeroudersAsync(bsnZoek, apiVersionZoek).Result;
            IEnumerable<OuderHal> result = response._embedded.Ouders;

            //var dummyLocal = DummyOuder;
            //dummyLocal.Burgerservicenummer = bsnZoek;
            //dummyLocal.Naam.Geslachtsnaam = DummyOuder.Naam.Geslachtsnaam + "-" + bsnZoek;
            //IEnumerable<OuderHal> result = new List<OuderHal>() { dummyLocal };

            return View(result);
        }

        private OuderHal DummyOuder
        {
            get
            {
                var retval = new OuderHal();
                retval.Burgerservicenummer = "333333331";
                retval.Naam = new Naam() { Geslachtsnaam = "OuderEen", Voorletters = "JO", Voornamen = "Jan-Ouder" };

                return retval;
            }
        }
    }
}