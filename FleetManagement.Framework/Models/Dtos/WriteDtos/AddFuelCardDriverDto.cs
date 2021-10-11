using FleetManagement.Framework.Models.Dtos.ReadDtos;
using System;

namespace FleetManagement.Framework.Models.WriteDtos
{
    public class AddFuelCardDriverDto
    {

        public bool Active { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ClosureDate { get; set; }

        public FuelCardDto FuelCard { get; set; }

        public DriverDetailsDto Driver { get; set; }

        public AddFuelCardDriverDto(
            bool active,
            DateTime creationDate,
            DateTime closureDate,
            FuelCardDto fuelCard,
            DriverDetailsDto driver)
        {
            Active = active;
            CreationDate = creationDate;
            ClosureDate = closureDate;
            FuelCard = fuelCard;
            Driver = driver;
        }
        public AddFuelCardDriverDto()
        {
        }
    }
}
