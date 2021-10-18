using FleetManagement.Framework.Models.Enums;

namespace FleetManagement.Domain.Models
{
    public class FuelCardOptions : IBaseClass
    {
        public int Id { get; private set; }

        public FuelType Fueltype { get; private set; }

        public string ExtraServices { get; private set; }
    }
}
