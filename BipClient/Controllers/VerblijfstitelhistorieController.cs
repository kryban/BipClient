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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Zoek(string bsnZoek, string apiVersionZoek, string fieldsZoek, DateTimeOffset peilDatumZoek, DateTimeOffset periodeVanZoek, DateTimeOffset periodeTotZoek)
        {
            var response = client.GetverblijfstitelhistorieAsync(
                bsnZoek
                , apiVersionZoek
                , fieldsZoek
                , peilDatumZoek.Year == 1 ? (DateTimeOffset?)null : peilDatumZoek
                , periodeVanZoek.Year == 1 ? (DateTimeOffset?)null : periodeVanZoek
                , periodeTotZoek.Year == 1 ? (DateTimeOffset?)null : periodeTotZoek).Result;

            IEnumerable<VerblijfstitelhistorieHal> result = response._embedded.Verblijfstitelhistorie;

            //var dummyLocal = DummyPartnerhistorie;
            //dummyLocal.Naam.Geslachtsnaam = DummyPartnerhistorie.Naam.Geslachtsnaam + id.ToString();
            //IEnumerable<PartnerhistorieHal> result = new List<PartnerhistorieHal>() { dummyLocal };

            return View(result);
        }

        private VerblijfstitelhistorieHal DummyVerblijfstitelhistorie
        {
            get
            {
                var retval = new VerblijfstitelhistorieHal();

                return retval;
            }

        }
    }
}