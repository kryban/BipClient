using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bip.Controllers
{
    public class VerblijfstitelhistorieController : Controller
    {
        BipClient client;

        public VerblijfstitelhistorieController()
        {
            client = new BipClient(new System.Net.Http.HttpClient());
        }

        private VerblijfstitelhistorieHal DummyVerblijfstitelhistorie
        {
            get
            {
                var retval = new VerblijfstitelhistorieHal();

                return retval;
            }

        }

        // GET: Ouders
        public ActionResult Index()
        {
            var response = client.GetverblijfstitelhistorieAsync("999994669", null,null,null,null,null).Result;
            IEnumerable<VerblijfstitelhistorieHal> result = response._embedded.Verblijfstitelhistorie;

            //IEnumerable<VerblijfstitelhistorieHal> result = new List<VerblijfstitelhistorieHal>() { DummyVerblijfstitelhistorie };

            return View(result);
        }

        // GET: Ouders/Details/5
        public ActionResult Details(int id)
        {
            var response = client.GetverblijfstitelhistorieAsync(id.ToString(), null,null,null,null,null).Result;
            IEnumerable<VerblijfstitelhistorieHal> result = response._embedded.Verblijfstitelhistorie;

            //var dummyLocal = DummyVerblijfstitelhistorie;
            //dummyLocal.DatumEinde = new Datum_onvolledig() { Dag = 23, Maand = 12, Jaar = 2019 };
            //IEnumerable<VerblijfstitelhistorieHal> result = new List<VerblijfstitelhistorieHal>() { dummyLocal };

            return View(result);
        }

    }
}