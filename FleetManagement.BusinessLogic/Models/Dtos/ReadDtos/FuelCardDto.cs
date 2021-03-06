using System;
using System.Collections.Generic;
using FleetManagement.Framework.Models.Enums;

namespace FleetManagement.BLL.Models.Dtos.ReadDtos
{
    public class FuelCardDto
    {
        public int Id { get; set; }

        public string CardNumber { get; set; }

        public DateTime ExpirationDate { get; set; }

        public AuthenticationType AuthenticationType { get; set; }

        public FuelCardOptionsDto FuelCardOptions { get; set; }

        public List<FuelCardDriverDto> FuelCardDrivers { get; set; }

        public bool Blocked { get; set; }

        public FuelCardDto(
            int id,
            string cardNumber,
            DateTime expirationDate,
            AuthenticationType authenticationType,
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
