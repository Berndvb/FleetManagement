using FleetManagement.Framework.Models.Enums;

namespace FleetManagement.Domain.Models
{
    public class TankkaartOpties
    {
        public string Id { get; set; }

        public EBrandstofType BrandstofType { get; set; }

        public string ExtraServices { get; set; }
    }
}
