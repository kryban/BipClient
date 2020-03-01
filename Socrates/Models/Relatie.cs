using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Socrates.Models
{
    public class Relatie : Persoon
    {
        public string BsnHoofdklant { get; set; }

        public enmSoortRelatie SoortRelatie { get; set; }
    }
}
