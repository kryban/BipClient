using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Bip.Controllers
{
    public class PartnerhistorieController : Controller
    {
        BipClient client;

        public PartnerhistorieController()
        {
            client = new BipClient(new System.Net.Http.HttpClient());
        }

        // Get
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Zoek(string bsnZoek, string apiVersionZoek, string fieldsZoek, DateTimeOffset peilDatumZoek, DateTimeOffset periodeVanZoek, DateTimeOffset periodeTotZoek)
        {
            var response = client.GetpartnerhistorieAsync(
                bsnZoek
                , apiVersionZoek
                , fieldsZoek
                , peilDatumZoek.Year == 1 ? (DateTimeOffset?)null : peilDatumZoek
                , periodeVanZoek.Year == 1 ? (DateTimeOffset?)null : periodeVanZoek
                , periodeTotZoek.Year == 1 ? (DateTimeOffset?)null : periodeTotZoek).Result;

            IEnumerable <PartnerhistorieHal> result = response._embedded.Partnerhistorie;

            //var dummyLocal = DummyPartnerhistorie;
            //dummyLocal.Naam.Geslachtsnaam = DummyPartnerhistorie.Naam.Geslachtsnaam + id.ToString();
            //IEnumerable<PartnerhistorieHal> result = new List<PartnerhistorieHal>() { dummyLocal };

            return View(result);
        }

        private PartnerhistorieHal DummyPartnerhistorie
        {
            get
            {
                var retval = new PartnerhistorieHal();
                retval.Burgerservicenummer = "555555552";
                retval.Naam = new Naam() { Geslachtsnaam = "Historische partner", Voorletters = "HP" };

                return retval;
            }
        }
    }
}