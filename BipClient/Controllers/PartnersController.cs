using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bip.Controllers
{
    public class PartnersController : Controller
    {
        BipClient client;

        public PartnersController()
        {
            client = new BipClient(new System.Net.Http.HttpClient());
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Zoek(string bsnZoek, string apiVersionZoek)
        {
            var response = client.IngeschrevenpersonenBurgerservicenummerpartnersAsync(bsnZoek, apiVersionZoek).Result;
            IEnumerable<PartnerHal> result = response._embedded.Partners;

            //var dummyLocal = DummyPartner;
            //dummyLocal.Burgerservicenummer = id.ToString();
            //dummyLocal.Naam.Geslachtsnaam = DummyPartner.Naam.Geslachtsnaam + "-" + id.ToString();
            //IEnumerable<PartnerHal> result = new List<PartnerHal>() { dummyLocal };

            return View(result);
        }

        private PartnerHal DummyPartner
        {
            get
            {
                var retval = new PartnerHal();
                retval.Burgerservicenummer = "333333331";
                retval.Naam = new Naam() { Geslachtsnaam = "PartnertEen", Voorvoegsel = "van", Voorletters = "JP", Voornamen = "Jan-Part" };

                return retval;
            }
        }
    }
}