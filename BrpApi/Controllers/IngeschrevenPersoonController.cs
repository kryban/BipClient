using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BrpApi.BevragingIngeschrevenPersoon;
using BrpApi.Models;
using BrpApi.Mappers;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
//using System.Web.Http;

namespace BrpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngeschrevenPersoonController : ControllerBase
    {
        BipClient client;

        private readonly ILogger<IngeschrevenPersoonController> logger;

        public IngeschrevenPersoonController(ILogger<IngeschrevenPersoonController>logger)
        {
            this.logger = logger;
            client = new BipClient(new HttpClient());
        }

        // GET: api/BevragingIngeschrevenPersoon
        [HttpGet]
        public IEnumerable<string> Get()
        {
            //throw new NotImplementedException();
            return new List<string> { "default" };
        }

        // GET: api/IngeschrevenPersoon/5
        //[HttpGet("{id}", Name = "GetNatuurlijkPersoon")]
        [HttpGet("/api/ingeschrevenpersoon/{id}")]
        //[Route("api/ingeschrevenpersoon")]
        public Persoon GetPersoon(string id)
        {
            Persoon retVal;
            IngeschrevenPersoonHal brpResult;

            brpResult = client.IngeschrevenNatuurlijkPersoonAsync(id, null, null, null).Result;

            retVal = new Map_IngeschrevenPersoonHal_to_Persoon().Map(brpResult);

            return retVal;
        }

        // GET: api/IngeschrevenPersoonOuders/5
        [HttpGet("/api/ingeschrevenpersoon/{id}/ouders")]
        public IEnumerable<Persoon> GetOuders(string id)
        {
            List<Persoon> retVal = new List<Persoon>();
            OuderHalCollectie brpSubResults;

            brpSubResults = client.IngeschrevenpersonenBurgerservicenummeroudersAsync(id, null).Result;

            int i = 0;
            foreach (var subResult in brpSubResults._embedded.Ouders)
            {
                try
                {
                    IngeschrevenPersoonHal ouderPersoon = client.IngeschrevenNatuurlijkPersoonAsync(subResult.Burgerservicenummer, null, null, null).Result;
                    Persoon ouder = new Map_IngeschrevenPersoonHal_to_Persoon().Map(ouderPersoon);
                    retVal.Add(ouder);
                }
                catch (AggregateException e)
                { };
            }

            return retVal;
        }
    }
}
