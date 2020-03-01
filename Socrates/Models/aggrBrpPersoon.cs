using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Socrates.Models
{
    public class aggrBrpPersoon
    {
        public Persoon Hoofdpersoon { get; set; }
        public IEnumerable<Relatie> Ouders { get; set; }
        public IEnumerable<Relatie> Kinderen { get; set; }
        public IEnumerable<Relatie> Partners { get; set; }
        public IEnumerable<Relatie> Medebewoners { get; set; }
    }
}
