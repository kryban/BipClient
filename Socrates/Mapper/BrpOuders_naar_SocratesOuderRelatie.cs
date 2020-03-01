using System;
using System.Collections.Generic;
using Socrates.Brp;
using Socrates.Models;

namespace Socrates.Mapper
{
    internal class BrpOuders_naar_SocratesOuderRelatie
    {
        internal static List<Relatie> Map(Models.Persoon hoofdpersoon, ICollection<Ouder> brpOuders)
        {
            var o = brpOuders;
            List<Relatie> relaties = new List<Relatie>();

            foreach(var ouder in brpOuders)
            {
                var r = new Relatie
                {
                    Persoon = hoofdpersoon,
                    SoortRelatie = enmSoortRelatie.kindVan,
                    PersoonRelatie = new Models.Persoon
                    {
                        Aanhef = ouder.Aanhef,
                        Aanschrijfwijze = ouder.Aanschrijfwijze,
                        Burgerservicenummer = ouder.Burgerservicenummer,
                        DatumGeboorte = ouder.DatumGeboorte,
                        DatumGeboorteBevolking = ouder.DatumGeboorteBevolking,
                        DatumOverlijden = ouder.DatumOverlijden,
                        Geboorteland = ouder.Geboorteland,
                        Geheim = ouder.Geheim,
                        Geslacht = (enmGeslacht)ouder.Geslacht,
                        Naam = ouder.Naam,
                        Nationaliteit1 = ouder.Nationaliteit1,
                        Nationaliteit2 = ouder.Nationaliteit2,
                        Voorletters = ouder.Voorletters,
                        Voornamen = ouder.Voornamen,
                        Voorvoegsels = ouder.Voorvoegsels
                    }
                };

                relaties.Add(r);
            }
            return relaties;
        }
    }
}