using FleetManagement.Framework.Models.Enums;

namespace FleetManagement.Domain.Models
{
    public class IdentityVehicle : IBaseClass
    {
        public int Id { get; set; }

        public string Chassisnumber { get; set; }

        public FuelType FuelType { get; set; }

        public CarType CarType { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string LicensePlates { get; set; }
    }
}
