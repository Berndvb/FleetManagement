using FleetManagement.Domain.Interfaces;
using FleetManagement.Framework.Models.Enums;

namespace FleetManagement.Domain.Models
{
    public class FuelCardOptions : IBaseClass
    {
        public int Id { get; set; }

        public FuelTypes Fueltype { get; set; }

        public string ExtraServices { get; set; }
    }
}
