using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bip.Controllers
{
    public class KinderenController : Controller
    {
        BipClient client;

        public KinderenController()
        {
            client = new BipClient(new System.Net.Http.HttpClient());
        }
        
        // GET: Kinderen
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Zoek(string apiVersionZoek, string bsnZoek)
        {
            IEnumerable<IngeschrevenPersoon> ingeschrevenPersonen;

            try
            {
                var response = client.IngeschrevenpersonenBurgerservicenummerkinderenAsync(bsnZoek, apiVersionZoek).Result;
                IEnumerable<KindHal> result = response._embedded.Kinderen;

                //var dummyLocal = DummyKind;
                //dummyLocal.Burgerservicenummer = id.ToString();
                //dummyLocal.Naam.Geslachtsnaam = DummyKind.Naam.Geslachtsnaam + "-" + id.ToString();
                //IEnumerable<KindHal> result = new List<KindHal>() { dummyLocal};

                return View(result);
            }
            catch (Exception e)
            {
                ViewBag.ResponseError = e.InnerException;
                return View();
            }
        }

        private KindHal DummyKind
        {
            get
            {
                var retval = new KindHal();
                retval.Burgerservicenummer = "222222221";
                retval.Naam = new Naam() { Geslachtsnaam = "Kind1", Voorletters = "JJ", Voornamen = "Jan" };

                return retval;
            }

        }
    }
}