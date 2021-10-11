using FleetManagement.Framework.Helpers;
using System.Collections.Generic;

namespace FleetManagement.Framework.Models.Dtos.ReadDtos
{
    public class VehicleDetailsDto
    {
        public int Id { get; set; }

        public IdentityVehicleDto Identity { get; set; }

        public List<int> Mileage { get; set; }

        public List<MaintenanceDto> Maintenance { get; set; }

        public List<RepareDto> Reparations { get; set; }

        public List<DriverVehicleDto> Drivers { get; set; }

        public List<AppealDto> Appeals { get; set; }

        public VehicleDetailsDto(
            int id,
            IdentityVehicleDto identity,
            string mileage,
            List<MaintenanceDto> maintenance,
            List<RepareDto> reparations,
            List<AppealDto> appeals)
        {
            Id = id;
            Identity = identity;
            Mileage = mileage.SplitToNumbers();
            Maintenance = maintenance;
            Reparations = reparations;
            Appeals = appeals;
        }

        public VehicleDetailsDto()
        {
        }
    }
}
