using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BrpApi.BevragingIngeschrevenPersoon;
using BrpApi.Models;
using BrpApi.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BrpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngeschrevenPersoonController : ControllerBase
    {
        BipClient client;

        private readonly ILogger<IngeschrevenPersoonController> logger;

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}

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
            return default;
        }

        // GET: api/IngeschrevenPersoon/5
        [HttpGet("{id}", Name = "Get")]
        public Persoon Get(string id)
        {
            Persoon retVal;
            IngeschrevenPersoonHal brpResult;

            brpResult = client.IngeschrevenNatuurlijkPersoonAsync(id, null, null, null).Result;

            retVal = new Map_IngeschrevenPersoonHal_to_Persoon().Map(brpResult);

            return retVal;
        }
    }
}
