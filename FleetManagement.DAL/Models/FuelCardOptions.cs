using FleetManagement.Domain.Interfaces.Models;
using FleetManagement.Framework.Models.Enums;

namespace FleetManagement.Domain.Models
{
    public class FuelCardOptions : IBaseClass
    {
        public int Id { get; set; }

        public FuelType Fueltype { get; set; }

        public string ExtraServices { get; set; }
    }
}
