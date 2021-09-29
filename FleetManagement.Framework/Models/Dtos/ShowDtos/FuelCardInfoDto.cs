using FleetManagement.Framework.Helpers;
using FleetManagement.Framework.Models.Enums;
using System;
using System.Collections.Generic;

namespace FleetManagement.Framework.Models.Dtos.ShowDtos
{
    public class FuelCardInfoDto
    {
        public FuelCardDriverDto FuelCardDriver { get; set; }

        public FuelCardDto FuelCard { get; set; }

        public FuelCardInfoDto(
            FuelCardDriverDto fuelCardDriver,
            FuelCardDto fuelCard)
        {
            FuelCardDriver = fuelCardDriver;
            FuelCard = fuelCard;
        }

        public class FuelCardDriverDto
        {
            public int Id { get; set; }

            public bool Active { get; set; }

            public DateTime CreationDate { get; set; }

            public DateTime ClosureDate { get; set; }

            public FuelCardDriverDto(
                int id,
                bool active,
                DateTime creationDate,
                DateTime closureDate)
            {
                Id = id;
                Active = active;
                CreationDate = creationDate;
                ClosureDate = closureDate;
            }
        }

        public class FuelCardDto
        {
            public int Id { get; set; }

            public string CardNumber { get; set; }

            public DateTime ExpirationDate { get; set; }

            public AuthenticatieTypes AuthenticationType { get; set; }

            public FuelCardOptionsDto FuelCardOptions { get; set; }

            public bool Blocked { get; set; }

            public FuelCardDto(
                int id,
                string cardNumber,
                DateTime expirationDate,
                AuthenticatieTypes authenticationType,
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
            
            public class FuelCardOptionsDto 
            {
                public int Id { get; set; }

                public FuelTypes Fueltype { get; set; }

                public List<string> ExtraServices { get; set; }

                public FuelCardOptionsDto(
                    int id,
                    FuelTypes fuelType,
                    string extraServices)
                {
                    Id = id;
                    Fueltype = fuelType;
                    ExtraServices = extraServices.SplitToText();
                }
            }
        }
    }
}
