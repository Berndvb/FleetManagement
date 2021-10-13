using FleetManagement.Domain.Models;
using System;

namespace FleetManagement.BLL.Models.Dtos.WriteDtos
{
    public class AddFuelCardDriverDto
    {

        public bool Active { get; set; }

        public DateTime CreationDate { get; set; }

        public FuelCard FuelCard { get; set; }

        public Driver Driver { get; set; }

        public AddFuelCardDriverDto(
            bool active,
            DateTime  creationDate,
            FuelCard fuelCard,
            Driver driver)
        {
            Active = active;
            CreationDate = creationDate;
            FuelCard = fuelCard;
            Driver = driver;
        }

    }
}
