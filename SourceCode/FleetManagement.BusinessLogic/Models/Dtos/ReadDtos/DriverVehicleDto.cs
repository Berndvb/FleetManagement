using System;

namespace FleetManagement.BLL.Models.Dtos.ReadDtos
{
    public class DriverVehicleDto
    {
        public int Id { get; set; }

        public bool Active { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ClosureDate { get; set; }
    }
}
