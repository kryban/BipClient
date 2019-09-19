using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        // GET: Ouders
        public ActionResult Index()
        {
            var response = client.IngeschrevenpersonenBurgerservicenummeroudersAsync("0", null).Result;
            IEnumerable<OuderHal> result = response._embedded.Ouders;

            //IEnumerable<OuderHal> result = new List<OuderHal>() { DummyOuder };

            return View(result);
        }

        // GET: Ouders/Details/5
        public ActionResult Details(int id)
        {
            var response = client.IngeschrevenpersonenBurgerservicenummeroudersAsync(id.ToString(), null).Result;
            IEnumerable<OuderHal> result = response._embedded.Ouders;

            //var dummyLocal = DummyOuder;
            //dummyLocal.Burgerservicenummer = id.ToString();
            //dummyLocal.Naam.Geslachtsnaam = DummyOuder.Naam.Geslachtsnaam + "-" + id.ToString();
            //IEnumerable<OuderHal> result = new List<OuderHal>() { dummyLocal };

            return View(result);
        }

    }
}