using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bip.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Bip.Controllers
{
    public class IngeschrevenPersonenController : Controller
    {
        BipClient client; 
        
        public IngeschrevenPersonenController()
        {
            client = new BipClient(new System.Net.Http.HttpClient());
        }

        public IngeschrevenPersoon DummyIngeschrevenPersoon
        {
            get
            {
                var naamPersoon = new NaamPersoon();
                naamPersoon.Geslachtsnaam = "FooNaam";

                var nationaliteitPersoon = new List<Nationaliteit>() { new Nationaliteit() { Nationaliteit1 = new Waardetabel() { Code = "1", Omschrijving = "NL" } } };

                var retval = new IngeschrevenPersoon();
                retval.Burgerservicenummer = "111111112";
                retval.Naam = naamPersoon;
                retval.Nationaliteit = nationaliteitPersoon;
                return retval;
            }
        }

        // GET: IngeschrevenPersoon
        public ActionResult Index()
        {
            IEnumerable<IngeschrevenPersoon> ingeschrevenPersonen;
            IngeschrevenPersoonHalCollectie response = client.IngeschrevenNatuurlijkPersonenAsync(null, "partners", null, "999993653", null, null, null, null, null, null, null, null, null, null, null, null, null, null).Result;
            ingeschrevenPersonen = response._embedded.Ingeschrevenpersonen;

            //ingeschrevenPersonen = new List<IngeschrevenPersoon>() { DummyIngeschrevenPersoon };

            return View(ingeschrevenPersonen);
        }

        // GET: IngeschrevenPersoon/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Zoek(Zoekdata zoekdata)
        {
            IEnumerable<IngeschrevenPersoon> ingeschrevenPersonen;
            IngeschrevenPersoonHalCollectie response = client.IngeschrevenNatuurlijkPersonenAsync(null, null, null, zoekdata.bsn, zoekdata.geboorte__datum, null, null, null, zoekdata.naam__geslachtsnaam, null, null, null, null, null, null, null, null, null).Result;
            ingeschrevenPersonen = response._embedded.Ingeschrevenpersonen;

            //ingeschrevenPersonen = new List<IngeschrevenPersoon>() { DummyIngeschrevenPersoon };

            return View(ingeschrevenPersonen);
        }

        [HttpPost]
        public ActionResult Zoek(string geslachtsNaamZoek, 
            string apiVersionZoek, 
            string expandZoek, 
            string fieldsZoek, 
            string bsnZoek, 
            DateTimeOffset geboorteDatumZoek, 
            string geboorteplaatsZoek, 
            int geslachtsaanduidingZoek, 
            bool inclusiefoverledenpersonenZoek, 
            string geslachtsnaamZoek, 
            string voornamenZoek, 
            string gemeentevaninschrijvingZoek, 
            string huisletterZoek, 
            int huisnummerZoek, 
            string huisnummertoevoegingZoek, 
            string identificatiecodenummeraanduidingZoek, 
            string naamopenbareruimteZoek, 
            string postcodeZoek, 
            string voorvoegselZoek)
        {
            IEnumerable<IngeschrevenPersoon> ingeschrevenPersonen;

            IngeschrevenPersoonHalCollectie response = client.IngeschrevenNatuurlijkPersonenAsync(
                null // api_version 
                , null // expand
                , null // fields
                , bsnZoek // burgersversivenummer
                , (geboorteDatumZoek.Year == 1 ? default : geboorteDatumZoek)// geboortedatum
                , null // geboorteplaats
                , null // geslachtsaanduiding
                , null // inclusiefoverledenpersonen
                , geslachtsnaamZoek // geslachtsnaam
                , null // voornamen
                , null // gemeentevaninschrijving
                , null // huisletter
                , null // huisnummer
                , null // huisnummertoevoeging
                , null // identificatienummeraanduiding
                , null // naamopennbareruimte
                , null // postcode
                , null // voorvoegsel
                ).Result;

            ingeschrevenPersonen = response._embedded.Ingeschrevenpersonen;

            //ingeschrevenPersonen = new List<IngeschrevenPersoon>() { DummyIngeschrevenPersoon };

            return View(ingeschrevenPersonen);

            /*
             IngeschrevenPersoonHalCollectie response = client.IngeschrevenNatuurlijkPersonenAsync(
                  null // api_version 
                , null // expand
                , null // fields
                , null // burgersversivenummer
                , null // geboortedatum
                , null // geboorteplaats
                , null // geslachtsaanduiding
                , null // inclusiefoverledenpersonen
                , null // geslachtsnaam
                , null // voornamen
                , null // gemeentevaninschrijving
                , null // huisletter
                , null // huisnummer
                , null // huisnummertoevoeging
                , null // identificatienummeraanduiding
                , null // naamopennbareruimte
                , null // postcode
                , null // voorvoegsel
                ).Result;
             */

            //Zoekdata data = new Zoekdata();
            //data.api_version = apiVersionZoek;
            //data.expand = expandZoek;
            //data.fields = fieldsZoek;
            //data.bsn = bsnZoek;
            //data.geboorte__datum = geboorteDatumZoek;
            //data.geboorte__plaats = geboorteplaatsZoek;
            //data.geslachtsaanduiding = null;// (Geslacht_enum)geslachtsaanduidingZoek ;
            //data.inclusiefoverledenpersonen = null;//inclusiefoverledenpersonenZoek;
            //data.naam__geslachtsnaam = geslachtsnaamZoek;
            //data.naam__voornamen = voornamenZoek;
            //data.verblijfplaats__gemeentevaninschrijving = gemeentevaninschrijvingZoek;
            //data.verblijfplaats__huisletter = huisletterZoek;
            //data.verblijfplaats__huisnummer = huisnummerZoek;
            //data.verblijfplaats__huisnummertoevoeging = huisnummertoevoegingZoek;
            //data.verblijfplaats__identificatiecodenummeraanduiding = identificatiecodenummeraanduidingZoek;
            //data.verblijfplaats__naamopenbareruimte = naamopenbareruimteZoek;
            //data.verblijfplaats__postcode = postcodeZoek;
            //data.naam__voorvoegsel = voorvoegselZoek;

        }
    }
}