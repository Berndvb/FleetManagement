using FleetManagement.Framework.Helpers;
using FleetManagement.Framework.Models.Enums;
using System.Collections.Generic;

namespace FleetManagement.Framework.Models.Dtos
{
    public class IdentiteitVoertuigDto
    {
        public string Chassisnummer { get; set; }

        public EBrandstofType BrandstofType { get; set; }

        public EWagenType WagenType { get; set; }

        public string Merk { get; set; }

        public List<string> Nummerplaten { get; set; }

        public IdentiteitVoertuigDto(
            string chassisnummer,
            EBrandstofType brandstofType,
            EWagenType wagenType,
            string merk,
            string nummerplaten)
        {
            Chassisnummer = chassisnummer;
            BrandstofType = brandstofType;
            WagenType = wagenType;
            Merk = merk;
            Nummerplaten = nummerplaten.SplitToText(); 
        }
    }
}
