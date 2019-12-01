using BrpApi.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrpApi.Models
{
    public class Ouder : Persoon
    {
        public Ouder(Persoon persoon) : base(persoon)
        {

        }

        public enmOuderIndicatie OuderIndicatie { get; set; }
    }
}
