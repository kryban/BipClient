using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Socrates.Models
{
    public class Relatie
    {
        public Persoon Persoon { get; set; }

        public Persoon PersoonRelatie { get; set; }

        public enmSoortRelatie SoortRelatie { get; set; }
    }
}
