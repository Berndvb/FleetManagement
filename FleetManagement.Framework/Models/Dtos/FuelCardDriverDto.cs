using System;

namespace FleetManagement.Framework.Models.Dtos
{
    public class FuelCardDriverDto
    {
        public int Id { get; set; }

        public bool Active { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ClosureDate { get; set; }

        public FuelCardDto FuelCard { get; set; }

        public DriverDto Driver { get; set; }

        public FuelCardDriverDto(
            int id,
            bool active,
            DateTime creationDate,
            DateTime closureDate,
            FuelCardDto fuelCard,
            DriverDto driver)
        {
            Id = id;
            Active = active;
            CreationDate = creationDate;
            ClosureDate = closureDate;
            FuelCard = fuelCard;
            Driver = driver;
        }
        public FuelCardDriverDto()
        {
        }
    }
}
