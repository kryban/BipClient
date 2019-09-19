using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bip.Models
{
    public class Zoekdata
    {
        public string bsn { get; set; }

        public string api_version { get; set; }

        public string expand { get; set; }

        public string fields { get; set; }

        public string burgerservicenummer { get; set; }

        public DateTimeOffset? geboorte__datum { get; set; }

        public string geboorte__plaats { get; set; }

        public Geslacht_enum? geslachtsaanduiding { get; set; }

        public bool? inclusiefoverledenpersonen { get; set; }

        public string naam__geslachtsnaam { get; set; }

        public string naam__voornamen { get; set; }

        public string verblijfplaats__gemeentevaninschrijving { get; set; }

        public string verblijfplaats__huisletter { get; set; }

        public int? verblijfplaats__huisnummer { get; set; }

        public string verblijfplaats__huisnummertoevoeging { get; set; }

        public string verblijfplaats__identificatiecodenummeraanduiding { get; set; }

        public string verblijfplaats__naamopenbareruimte { get; set; }

        public string verblijfplaats__postcode { get; set; }

        public string naam__voorvoegsel { get; set; }
    }
}
