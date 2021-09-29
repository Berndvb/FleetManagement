using FleetManagement.Framework.Helpers;
using System.Collections.Generic;

namespace FleetManagement.Framework.Models.Dtos
{
    public class VehicleDto
    {
        public int Id { get; set; }

        public IdentityVehicleDto Identity { get; set; }

        public List<int> Mileage { get; set; }

        public List<VehicleMaintenanceDto> Maintenance { get; set; }

        public List<VehicleRepareDto> Reparations { get; set; }

        public List<VehicleAppealDto> Appeals { get; set; }

        public VehicleDto(
            int id,
            IdentityVehicleDto identity,
            string mileage,
            List<VehicleMaintenanceDto> maintenance,
            List<VehicleRepareDto> reparations,
            List<VehicleAppealDto> appeals)
        {
            Id = id;
            Identity = identity;
            Mileage = mileage.SplitToNumbers();
            Maintenance = maintenance;
            Reparations = reparations;
            Appeals = appeals;
        }

        public VehicleDto()
        {
        }
    }
}
