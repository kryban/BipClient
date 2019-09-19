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

        private PartnerHal DummyPartner
        {
            get
            {
                var retval = new PartnerHal();
                retval.Burgerservicenummer = "333333331";
                retval.Naam = new Naam() { Geslachtsnaam = "PartnertEen", Voorvoegsel="van", Voorletters = "JP", Voornamen = "Jan-Part" };

                return retval;
            }

        }

        // GET: Ouders
        public ActionResult Index()
        {
            var response = client.IngeschrevenpersonenBurgerservicenummerpartnersAsync("999993653", null).Result;
            IEnumerable<PartnerHal> result = response._embedded.Partners;

            //IEnumerable<PartnerHal> result = new List<PartnerHal>() { DummyPartner };

            return View(result);
        }

        // GET: Ouders/Details/5
        public ActionResult Details(int id)
        {
            var response = client.IngeschrevenpersonenBurgerservicenummerpartnersAsync(id.ToString(), null).Result;
            IEnumerable<PartnerHal> result = response._embedded.Partners;

            //var dummyLocal = DummyPartner;
            //dummyLocal.Burgerservicenummer = id.ToString();
            //dummyLocal.Naam.Geslachtsnaam = DummyPartner.Naam.Geslachtsnaam + "-" + id.ToString();
            //IEnumerable<PartnerHal> result = new List<PartnerHal>() { dummyLocal };

            return View(result);
        }

    }
}