using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        // GET: Ouders
        public ActionResult Index()
        {
            var response = client.GetverblijfplaatshistorieAsync("0", null,null,null,null,null).Result;
            IEnumerable<VerblijfplaatshistorieHal> result = response._embedded.Verblijfplaatshistorie;

            //IEnumerable<VerblijfplaatshistorieHal> result = new List<VerblijfplaatshistorieHal>() { DummyVerblijfplaatshistorie };

            return View(result);
        }

        // GET: Ouders/Details/5
        public ActionResult Details(int id)
        {
            var response = client.GetverblijfplaatshistorieAsync(id.ToString(), null,null,null,null,null).Result;
            IEnumerable<VerblijfplaatshistorieHal> result = response._embedded.Verblijfplaatshistorie;

            //var dummyLocal = DummyVerblijfplaatshistorie;
            //dummyLocal.Huisnummer = DummyVerblijfplaatshistorie.Huisnummer + id;
            //IEnumerable<VerblijfplaatshistorieHal> result = new List<VerblijfplaatshistorieHal>() { dummyLocal };

            return View(result);
        }

    }
}