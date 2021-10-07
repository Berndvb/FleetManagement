using FleetManagement.Framework.Models.Enums;
using System;
using System.Collections.Generic;

namespace FleetManagement.Framework.Models.Dtos
{
    public class FuelCardDto
    {
        public int Id { get; set; }

        public string CardNumber { get; set; }

        public DateTime ExpirationDate { get; set; }

        public AuthenticatieType AuthenticationType { get; set; }

        public FuelCardOptionsDto FuelCardOptions { get; set; }

        public List<FuelCardDriverDto> FuelCardDrivers { get; set; }

        public bool Blocked { get; set; }

        public FuelCardDto(
            int id,
            string cardNumber,
            DateTime expirationDate,
            AuthenticatieType authenticationType,
            FuelCardOptionsDto fuelCardOptions,
            List<FuelCardDriverDto> fuelCardDrivers,
            bool blocked)
        {
            Id = id;
            CardNumber = cardNumber;
            ExpirationDate = expirationDate;
            AuthenticationType = authenticationType;
            FuelCardOptions = fuelCardOptions;
            Blocked = blocked;
            FuelCardDrivers = fuelCardDrivers;
        }

        public FuelCardDto()
        {
        }
    }
}
