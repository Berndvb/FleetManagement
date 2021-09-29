using FleetManagement.Framework.Helpers;
using System.Linq;

namespace FleetManagement.Framework.Models.Dtos
{
    public class VehicleDetailsDto
    {
        public IdentityVehicleDto Identity { get; set; }

        public DriverVehicleDto DriverVehicle { get; set; }

        public int Mileage { get; set; }

        public VehicleDetailsDto(
            IdentityVehicleDto identity,
            DriverVehicleDto driverVehicle,
            string mileage)
        {
            Identity = identity;
            DriverVehicle = driverVehicle;
            Mileage = mileage.SplitToNumbers().Last();
        }

        public VehicleDetailsDto()
        {
        }
    }
}
