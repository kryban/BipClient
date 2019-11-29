using Socrates.Brp;
using Socrates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Socrates.Mapper
{
    public class BrpPersoon_naar_SocratesPersoon
    {
        internal static Models.Persoon Map(Brp.Persoon brpPersoon)
        {
            var p = brpPersoon;
            return new Models.Persoon
            {
                Aanhef = p.Aanhef,
                Aanschrijfwijze = p.Aanschrijfwijze,
                Burgerservicenummer = p.Burgerservicenummer,
                DatumGeboorte = p.DatumGeboorte,
                DatumGeboorteBevolking = p.DatumGeboorteBevolking,
                DatumOverlijden = p.DatumOverlijden,
                Geboorteland = p.Geboorteland,
                Geheim = p.Geheim,
                Geslacht = (enmGeslacht)p.Geslacht,
                Naam = p.Naam,
                Nationaliteit1 = p.Nationaliteit1,
                Nationaliteit2 = p.Nationaliteit2,
                Voorletters = p.Voorletters,
                Voornamen = p.Voornamen,
                Voorvoegsels = p.Voorvoegsels
            };
        }
    }
}
