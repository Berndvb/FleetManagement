using FleetManagement.Framework.Models.Enums;

namespace FleetManagement.Domain.Models
{
    public class FuelCardOptions
    {
        public string Id { get; set; }

        public EFuelType Fueltype { get; set; }

        public string ExtraServices { get; set; }
    }
}
