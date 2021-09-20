using FleetManagement.Framework.Models.Enums;

namespace FleetManagement.DAL.Models
{
    public class IdentiteitVoertuig
    {
        public string Chassisnummer { get; set; }

        public EBrandstofType BrandstofType { get; set; }

        public EWagenType WagenType { get; set; }

        public string Merk { get; set; }

        public string Nummerplaten { get; set; }
    }
}
