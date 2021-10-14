using FleetManagement.Domain.Models;
using System;

namespace FleetManagement.BLL.Models.Dtos.WriteDtos

{
    public class AddDriverVehicleDto
    {

        public int VehicleId { get; set; }

        public int DriverId { get; set; }

        public bool Active { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ClosureDate { get; set; }
    }
}
