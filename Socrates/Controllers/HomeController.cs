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
        Brp.IngeschrevenPersoonClient brpClient;
        //Brp.IngeschrevenPersoonOudersClient brpClientOuders;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            brpClient = new Brp.IngeschrevenPersoonClient(new HttpClient());
            //brpClientOuders = new Brp.IngeschrevenPersoonOudersClient(new HttpClient());
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

        public IActionResult ZoekPersoonMetRelaties(string bsnZoek)
        {
            Persoon brpHoofdpersoon = HaalPersoonUitBrp(bsnZoek);
            IEnumerable<Relatie> ouders = HaalOudersUitBrp(bsnZoek);
            IEnumerable<Relatie> kinderen = HaalKinderenUitBrp(bsnZoek);
            IEnumerable<Relatie> partners = HaalPartnersUitBrp(bsnZoek);

            var retVal = new aggrBrpPersoon();
            retVal.Hoofdpersoon = brpHoofdpersoon;
            retVal.Ouders = ouders;
            retVal.Kinderen = kinderen;
            retVal.Partners = partners;

            return View(retVal);
        }

        public IActionResult ZoekOuders(string bsn)
        {
            ICollection<Brp.Persoon> brpOuders= brpClient.GetOudersAsync(bsn).Result;

            List<Relatie> ouders = Mapper.BrpRelatie_naar_SocratesRelatie.Map(bsn, brpOuders, enmSoortRelatie.kindVan);

            //var brpOuders = brpClientPersoon.GetAsync(bsn).Result;
            //List<Relatie> ouders = Mapper.BrpOuders_naar_SocratesOuderRelatie.Map(persoon, brpOuders);
            return View(ouders);
        }

        private Persoon HaalPersoonUitBrp(string bsn)
        {
            var brpPersoon = brpClient.GetPersoonAsync(bsn).Result;
            Persoon persoon = Mapper.BrpPersoon_naar_SocratesPersoon.Map(brpPersoon);
            return persoon;
        }

        private IEnumerable<Relatie> HaalOudersUitBrp(string bsn)
        {
            var brpOuders = brpClient.GetOudersAsync(bsn).Result;
            
            var retVal = Mapper.BrpRelatie_naar_SocratesRelatie.Map(bsn,brpOuders, enmSoortRelatie.kindVan);
            return retVal;
        }

        private IEnumerable<Relatie> HaalPartnersUitBrp(string bsn)
        {
            var brpOuders = brpClient.GetPartnersAsync(bsn).Result;

            var retVal = Mapper.BrpRelatie_naar_SocratesRelatie.Map(bsn, brpOuders, enmSoortRelatie.partner);
            return retVal;
        }

        private IEnumerable<Relatie> HaalKinderenUitBrp(string bsn)
        {
            var brpOuders = brpClient.GetKinderenAsync(bsn).Result;

            var retVal = Mapper.BrpRelatie_naar_SocratesRelatie.Map(bsn, brpOuders, enmSoortRelatie.ouderVan);
            return retVal;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
