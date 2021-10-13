using System;
using System.Collections.Generic;
using FleetManagement.Framework.Models.Enums;

namespace FleetManagement.BLL.Models.Dtos.WriteDtos
{
    public class AddFuelCardDto
    {
        public string CardNumber { get; set; }

        public DateTime ExpirationDate { get; set; }

        public AuthenticatieType AuthenticationType { get; set; }

        public AddFuelCardOptionsDto FuelCardOptions { get; set; }

        public List<AddFuelCardDriverDto> FuelCardDrivers { get; set; }

        public bool Blocked { get; set; }
    }
}
