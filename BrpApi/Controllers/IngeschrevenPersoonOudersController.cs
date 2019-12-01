using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BrpApi.BevragingIngeschrevenPersoon;
using BrpApi.Mappers;
using BrpApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BrpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngeschrevenPersoonOudersController : ControllerBase
    {
        BipClient client;

        private readonly ILogger<IngeschrevenPersoonOudersController> logger;

        public IngeschrevenPersoonOudersController(ILogger<IngeschrevenPersoonOudersController> logger)
        {
            this.logger = logger;
            client = new BipClient(new HttpClient());
        }

        // GET: api/IngeschrevenPersoonOuders
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/IngeschrevenPersoonOuders/5
        [HttpGet("{id}", Name = "GetOuders")]
        public IEnumerable<Models.Ouder> Get(string id)
        {
            List<Models.Ouder> retVal = new List<Models.Ouder>();
            OuderHalCollectie brpSubResults;

            brpSubResults = client.IngeschrevenpersonenBurgerservicenummeroudersAsync(id, null).Result;

            int i = 0;
            foreach (var subResult in brpSubResults._embedded.Ouders)
            {
                try
                {
                    IngeschrevenPersoonHal ouderPersoon = client.IngeschrevenNatuurlijkPersoonAsync(subResult.Burgerservicenummer, null, null, null).Result;
                    Models.Ouder ouder = new Mappers.Map_IngeschrevenPersoonHal_to_Ouder().Map(ouderPersoon, i++);
                    retVal.Add(ouder);
                }
                catch(AggregateException e)
                { };
            }

            return retVal;
        }
    }
}
