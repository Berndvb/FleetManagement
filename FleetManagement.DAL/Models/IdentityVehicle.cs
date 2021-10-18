using FleetManagement.Framework.Models.Enums;

namespace FleetManagement.Domain.Models
{
    public class IdentityVehicle : IBaseClass
    {
        public int Id { get; private set; }

        public string Chassisnumber { get; private set; }

        public FuelType FuelType { get; private set; }

        public CarType CarType { get; private set; }

        public string Brand { get; private set; }

        public string Model { get; private set; }

        public string LicensePlates { get; private set; }
    }
}
