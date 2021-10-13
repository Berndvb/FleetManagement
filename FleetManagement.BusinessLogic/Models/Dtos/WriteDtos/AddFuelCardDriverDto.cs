using FleetManagement.Domain.Models;
using System;

namespace FleetManagement.BLL.Models.Dtos.WriteDtos
{
    public class AddFuelCardDriverDto
    {

        public bool Active { get; set; }

        public DateTime CreationDate { get; set; }

        public int FuelCardId { get; set; }

        public int DriverId { get; set; }

        public AddFuelCardDriverDto(
            bool active,
            DateTime  creationDate,
            int fuelCardId,
            int driverId)
        {
            Active = active;
            CreationDate = creationDate;
            FuelCardId = fuelCardId;
            DriverId = driverId;
        }

    }
}
