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
        public ActionResult ZoekPersoon(string bsnZoek,string apiVersionZoek,string expandZoek,string fieldsZoek)
        {
            try
            {
                IngeschrevenPersoonHal response = client.IngeschrevenNatuurlijkPersoonAsync(bsnZoek,apiVersionZoek,expandZoek,fieldsZoek).Result;

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