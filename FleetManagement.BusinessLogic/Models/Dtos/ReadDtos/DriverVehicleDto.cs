using System;

namespace FleetManagement.BLL.Models.Dtos.ReadDtos
{
    public class DriverVehicleDto
    {
        public int Id { get; set; }

        public VehicleDetailsDto Vehicle { get; set; }

        public DriverDetailsDto Driver { get; set; }

        public bool Active { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ClosureDate { get; set; }

        public DriverVehicleDto(
            int id,
            bool active,
            DateTime creationDate,
            DateTime? closureDate,
            VehicleDetailsDto vehicle,
            DriverDetailsDto driver)
        {
            Id = id;
            Active = active;
            CreationDate = creationDate;
            ClosureDate = closureDate;
            Vehicle = vehicle;
            Driver = driver;
        }

        public DriverVehicleDto()
        {
        }
    }
}
