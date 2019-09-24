using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Bip.Controllers
{
    public class VerblijfplaatshistorieController : Controller
    {
        BipClient client;

        public VerblijfplaatshistorieController()
        {
            client = new BipClient(new System.Net.Http.HttpClient());
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Zoek(string bsnZoek, string apiVersionZoek, string fieldsZoek, DateTimeOffset peilDatumZoek, DateTimeOffset periodeVanZoek, DateTimeOffset periodeTotZoek)
        {
            var response = client.GetverblijfplaatshistorieAsync(
                bsnZoek
                , apiVersionZoek
                , fieldsZoek
                , peilDatumZoek.Year == 1 ? (DateTimeOffset?)null : peilDatumZoek
                , periodeVanZoek.Year == 1 ? (DateTimeOffset?)null : periodeVanZoek
                , periodeTotZoek.Year == 1 ? (DateTimeOffset?)null : periodeTotZoek).Result;

            IEnumerable<VerblijfplaatshistorieHal> result = response._embedded.Verblijfplaatshistorie;

            return View(result);
        }

        private VerblijfplaatshistorieHal DummyVerblijfplaatshistorie
        {
            get
            {
                var retval = new VerblijfplaatshistorieHal();
                retval.Straatnaam = "Straatplein";
                retval.Huisnummer = 34;
                retval.Huisletter = "A";

                return retval;
            }

        }
    }
}
