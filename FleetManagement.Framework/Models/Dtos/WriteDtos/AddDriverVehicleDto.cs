using FleetManagement.Framework.Models.Dtos.ReadDtos;
using System;

namespace FleetManagement.Framework.Models.Dtos.WriteDtos

{
    public class AddDriverVehicleDto
    {

        public VehicleDetailsDto Vehicle { get; set; }

        public DriverDetailsDto Driver { get; set; }

        public bool Active { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ClosureDate { get; set; }

        public AddDriverVehicleDto(
            bool active,
            DateTime creationDate,
            DateTime? closureDate,
            VehicleDetailsDto vehicle,
            DriverDetailsDto driver)
        {
            Active = active;
            CreationDate = creationDate;
            ClosureDate = closureDate;
            Vehicle = vehicle;
            Driver = driver;
        }

        public AddDriverVehicleDto()
        {
        }
    }
}
