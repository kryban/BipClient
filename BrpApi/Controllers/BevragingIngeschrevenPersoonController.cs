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

namespace BrpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BevragingIngeschrevenPersoonController : ControllerBase
    {
        BipClient client;

        public BevragingIngeschrevenPersoonController()
        {
            client = new BipClient(new HttpClient());
        }

        //[HttpGet]
        //public object ZoekPersoon(string burgerServiceNummer,string expand, string velden )
        //{
        //    IngeschrevenPersoonHal retVal;

        //    retVal = client.IngeschrevenNatuurlijkPersoonAsync(burgerServiceNummer, null, expand, velden).Result;

        //    return retVal;
        //}
        
        // GET: api/BevragingIngeschrevenPersoon
        [HttpGet]
        public IEnumerable<string> Get()
        {
            throw new NotImplementedException();
        }

        // GET: api/BevragingIngeschrevenPersoon/5
        [HttpGet("{id}", Name = "Get")]
        public Persoon Get(string id)
        {
            Persoon retVal;
            IngeschrevenPersoonHal brpResult;

            brpResult = client.IngeschrevenNatuurlijkPersoonAsync(id, null, null, null).Result;

            retVal = new Map_IngeschrevenPersoonHal_to_Persoon().Map(brpResult);

            return retVal;
        }

        //// POST: api/BevragingIngeschrevenPersoon
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/BevragingIngeschrevenPersoon/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
