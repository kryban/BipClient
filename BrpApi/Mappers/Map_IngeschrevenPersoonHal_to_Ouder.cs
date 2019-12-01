using BrpApi.BevragingIngeschrevenPersoon;
using BrpApi.Enums;
using BrpApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrpApi.Mappers
{
    public class Map_IngeschrevenPersoonHal_to_Ouder
    {
        public Models.Ouder Map(IngeschrevenPersoonHal brpResultaat, int indicatie)
        {
            Persoon ouder = new Map_IngeschrevenPersoonHal_to_Persoon().Map(brpResultaat);

            return new Models.Ouder(ouder)
            {
                OuderIndicatie = (enmOuderIndicatie)indicatie
            };
        }
    }
}
