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
        // GET: IngeschrevenPersoon
        public ActionResult Index()
        {
            ReisdocumentHal response = client.ReisdocumentenReisdocumentnummerAsync("999990317", null).Result;
            //ReisdocumentHal response = new ReisdocumentHal() { Reisdocumentnummer= "123321", SoortReisdocument = new Waardetabel() { Code = "2", Omschrijving="Twee" } } ;

            return View(response);
        }

        // GET: IngeschrevenPersoon/Details/5
        public ActionResult Details(int id)
        {
            ReisdocumentHal response = client.ReisdocumentenReisdocumentnummerAsync(id.ToString(),null).Result;
            //ReisdocumentHal response = new ReisdocumentHal() { Reisdocumentnummer = "123321"+id.ToString(), SoortReisdocument = new Waardetabel() { Code = "2", Omschrijving = "Twee" } };

            return View(response);
        }
    }
}