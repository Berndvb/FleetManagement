using FleetManagement.Domain.Interfaces;
using FleetManagement.Framework.Models.Enums;

namespace FleetManagement.Domain.Models
{
    public class IdentityVehicle : IBaseClass
    {
        public int Id { get; set; }

        public string Chassisnumber { get; set; }

        public FuelTypes FuelType { get; set; }

        public CarTypes CarType { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string LicensePlates { get; set; }
    }
}
