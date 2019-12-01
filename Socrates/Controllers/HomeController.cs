using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Socrates.Models;
using System.Net.Http;

namespace Socrates.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Brp.IngeschrevenPersoonClient brpClientPersoon;
        Brp.IngeschrevenPersoonOudersClient brpClientOuders;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            brpClientPersoon = new Brp.IngeschrevenPersoonClient(new HttpClient());
            brpClientOuders = new Brp.IngeschrevenPersoonOudersClient(new HttpClient());
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Persoon()
        {
            return View();
        }

        public IActionResult ZoekPersoon(string bsnZoek)
        {
            Persoon result = HaalPersoonUitBrp(bsnZoek);
            return View(result);
        }

        public IActionResult ZoekOuders(string bsn)
        {
            Persoon persoon = HaalPersoonUitBrp(bsn);

            var brpOuders = brpClientOuders.GetAsync(bsn).Result;
            List<Relatie> ouders = Mapper.BrpOuders_naar_SocratesOuderRelatie.Map(persoon, brpOuders);
            return View(ouders);
        }

        private Persoon HaalPersoonUitBrp(string bsn)
        {
            var brpPersoon = brpClientPersoon.GetAsync(bsn).Result;
            Persoon persoon = Mapper.BrpPersoon_naar_SocratesPersoon.Map(brpPersoon);
            return persoon;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
