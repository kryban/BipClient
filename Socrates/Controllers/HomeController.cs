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
        Brp.IngeschrevenPersoonClient ingeschrevenPersoonClient;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            ingeschrevenPersoonClient = new Brp.IngeschrevenPersoonClient(new HttpClient());
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
            var brpPersoon = ingeschrevenPersoonClient.GetAsync(bsnZoek).Result;
            Persoon result = Mapper.BrpPersoon_naar_SocratesPersoon.Map(brpPersoon);
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
