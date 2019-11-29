using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrpApi.BevragingIngeschrevenPersoon;
using BrpApi.Enums;
using BrpApi.Models;

namespace BrpApi.Mappers
{
    public class Map_IngeschrevenPersoonHal_to_Persoon
    {
        internal Persoon Map(IngeschrevenPersoonHal brpResult)
        {
            return new Persoon
            {
                Aanhef = brpResult.Naam.Aanhef,
                Aanschrijfwijze = brpResult.Naam.Aanschrijfwijze,
                Burgerservicenummer = Convert.ToInt32(brpResult.Burgerservicenummer),
                DatumGeboorte = new DateTime(brpResult.Geboorte.Datum.Jaar, brpResult.Geboorte.Datum.Maand, brpResult.Geboorte.Datum.Dag),
                DatumGeboorteBevolking = new DateTime(brpResult.Geboorte.Datum.Jaar, brpResult.Geboorte.Datum.Maand, brpResult.Geboorte.Datum.Dag),
                DatumOverlijden = brpResult.Overlijden != null ? new DateTime(brpResult.Overlijden.Datum.Jaar, brpResult.Overlijden.Datum.Maand, brpResult.Overlijden.Datum.Dag) : default,
                Geboorteland = Convert.ToInt32(brpResult.Geboorte.Land.Code),
                Geheim = brpResult.GeheimhoudingPersoonsgegevens,
                Geslacht = (enmGeslacht)brpResult.Geslachtsaanduiding,
                Naam = brpResult.Naam.Geslachtsnaam,
                Nationaliteit1 = Convert.ToInt32(brpResult.Nationaliteit.First().Nationaliteit1.Code),
                Nationaliteit2 = brpResult.Nationaliteit.Count > 1 ? Convert.ToInt32(brpResult.Nationaliteit.ToArray()[1]?.Nationaliteit1.Code) : default,
                Voorletters = brpResult.Naam.Voorletters,
                Voornamen = brpResult.Naam.Voornamen,
                Voorvoegsels = brpResult.Naam.Voornamen,
            };
        }
    }
}
