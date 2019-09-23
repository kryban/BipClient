using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Bip.Controllers
{
    public class IngeschrevenPersoonController : Controller
    {
        BipClient client;

        public IngeschrevenPersoonController()
        {
            client = new BipClient(new System.Net.Http.HttpClient());
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Zoek(string apiVersionZoek,string expandZoek,string fieldsZoek,string bsnZoek)
        {
            IEnumerable<IngeschrevenPersoon> ingeschrevenPersonen;

            try
            {
                IngeschrevenPersoonHal response = client.IngeschrevenNatuurlijkPersoonAsync(bsnZoek,apiVersionZoek,expandZoek,fieldsZoek).Result;
                //ingeschrevenPersonen = new List<IngeschrevenPersoon>() { DummyIngeschrevenPersoon };

                return View(response);

            }
            catch (Exception e)
            {
                ViewBag.ResponseError = e.InnerException;
                return View();
            }
        }
    }
}