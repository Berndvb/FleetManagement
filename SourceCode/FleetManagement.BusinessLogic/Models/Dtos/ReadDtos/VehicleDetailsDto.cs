using System.Collections.Generic;

namespace FleetManagement.BLL.Models.Dtos.ReadDtos
{
    public class VehicleDetailsDto
    {
        public int Id { get; set; }

        public IdentityVehicleDto Identity { get; set; }

        public List<int> Mileage { get; set; }

        public List<MaintenanceDto> Maintenance { get; set; }

        public List<RepareDto> Reparations { get; set; }

        public List<DriverVehicleDto> DriverVehicles { get; set; }

        public List<AppealDto> Appeals { get; set; }
    }
}
