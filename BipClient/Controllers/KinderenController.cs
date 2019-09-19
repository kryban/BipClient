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

        private KindHal DummyKind
        {
            get
            {
                var retval = new KindHal();
                retval.Burgerservicenummer = "222222221";
                retval.Naam = new Naam() { Geslachtsnaam="Kind1", Voorletters="JJ", Voornamen="Jan" };

                return retval;
            }

        }

        // GET: Kinderen
        public ActionResult Index()
        {
            var response = client.IngeschrevenpersonenBurgerservicenummerkinderenAsync("999993653", null).Result;
            IEnumerable<KindHal> result = response._embedded.Kinderen;

            //IEnumerable<KindHal> result = new List<KindHal>() { DummyKind };

            return View(result);
        }

        // GET: Kinderen/Details/5
        public ActionResult Details(int id)
        {
            var response = client.IngeschrevenpersonenBurgerservicenummerkinderenAsync(id.ToString(), null).Result;
            IEnumerable<KindHal> result = response._embedded.Kinderen;

            //var dummyLocal = DummyKind;
            //dummyLocal.Burgerservicenummer = id.ToString();
            //dummyLocal.Naam.Geslachtsnaam = DummyKind.Naam.Geslachtsnaam + "-" + id.ToString();
            //IEnumerable<KindHal> result = new List<KindHal>() { dummyLocal};

            return View(result);
        }
    }
}