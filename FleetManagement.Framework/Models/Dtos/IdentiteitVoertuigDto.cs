using FleetManagement.Framework.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.Framework.Models.Dtos
{
    public class IdentiteitVoertuigDto
    {
        public string Chassisnummer { get; set; }

        public EBrandstofType BrandstofType { get; set; }

        public EWagenType WagenType { get; set; }

        public string Merk { get; set; }

        public List<string> Nummerplaten { get; set; }
    }
}
