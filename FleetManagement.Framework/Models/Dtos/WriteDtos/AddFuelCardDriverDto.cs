using FleetManagement.Framework.Models.Dtos.ReadDtos;
using FleetManagement.Framework.Models.Dtos.WriteDtos;
using System;

namespace FleetManagement.Framework.Models.WriteDtos
{
    public class AddFuelCardDriverDto
    {

        public bool Active { get; set; }

        public DateTime CreationDate { get; set; }

        public FuelCardDto FuelCard { get; set; }

        public AddDriverDetailsDto Driver { get; set; }

        public AddFuelCardDriverDto(
            bool active,
            DateTime  creationDate,
            FuelCardDto fuelCard,
            AddDriverDetailsDto driver)
        {
            Active = active;
            CreationDate = creationDate;
            FuelCard = fuelCard;
            Driver = driver;
        }

    }
}
