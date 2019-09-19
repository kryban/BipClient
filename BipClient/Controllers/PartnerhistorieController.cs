using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        // Get
        public ActionResult Index()
        {
            var response = client.GetpartnerhistorieAsync("999993653", null,null,null,null,null).Result;
            IEnumerable<PartnerhistorieHal> result = response._embedded.Partnerhistorie;

            //IEnumerable<PartnerhistorieHal> result = new List<PartnerhistorieHal>() { DummyPartnerhistorie };

            return View(result);
        }

        // GET: Ouders/Details/5
        public ActionResult Details(int id)
        {
            var response = client.GetpartnerhistorieAsync(id.ToString(), null,null,null,null,null).Result;
            IEnumerable<PartnerhistorieHal> result = response._embedded.Partnerhistorie;

            //var dummyLocal = DummyPartnerhistorie;
            //dummyLocal.Naam.Geslachtsnaam = DummyPartnerhistorie.Naam.Geslachtsnaam + id.ToString();
            //IEnumerable<PartnerhistorieHal> result = new List<PartnerhistorieHal>() { dummyLocal };

            return View(result);
        }

    }
}