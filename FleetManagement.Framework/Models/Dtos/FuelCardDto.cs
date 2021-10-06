using FleetManagement.Framework.Models.Enums;
using System;

namespace FleetManagement.Framework.Models.Dtos
{
    public class FuelCardDto
    {
        public int Id { get; set; }

        public string CardNumber { get; set; }

        public DateTime ExpirationDate { get; set; }

        public AuthenticatieType AuthenticationType { get; set; }

        public FuelCardOptionsDto FuelCardOptions { get; set; }

        public bool Blocked { get; set; }

        public FuelCardDto(
            int id,
            string cardNumber,
            DateTime expirationDate,
            AuthenticatieType authenticationType,
            FuelCardOptionsDto fuelCardOptions,
            bool blocked)
        {
            Id = id;
            CardNumber = cardNumber;
            ExpirationDate = expirationDate;
            AuthenticationType = authenticationType;
            FuelCardOptions = fuelCardOptions;
            Blocked = blocked;
        }

        public FuelCardDto()
        {
        }
    }
}
