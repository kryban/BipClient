using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bip.Controllers
{
    public class ReisdocumentController : Controller
    {
        BipClient client;

        public ReisdocumentController()
        {
            client = new BipClient(new System.Net.Http.HttpClient());
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: IngeschrevenPersoon/Details/5
        public ActionResult Zoek(string reisdocumentNummerZoek, string apiVersion)
        {
            ReisdocumentHal response = client.ReisdocumentenReisdocumentnummerAsync(reisdocumentNummerZoek, apiVersion).Result;
            //ReisdocumentHal response = new ReisdocumentHal() { Reisdocumentnummer = "123321"+id.ToString(), SoortReisdocument = new Waardetabel() { Code = "2", Omschrijving = "Twee" } };

            return View(response);
        }
    }
}