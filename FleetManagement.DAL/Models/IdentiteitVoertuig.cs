using FleetManagement.Framework.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Domain.Models
{
    public class IdentiteitVoertuig
    {
        public string Id { get; set; }

        public string Chassisnummer { get; set; }

        public EBrandstofType BrandstofType { get; set; }

        public EWagenType WagenType { get; set; }

        public string Merk { get; set; }

        public string Nummerplaten { get; set; }
    }
}
