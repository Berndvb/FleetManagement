using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Models.Enums;
using System;
using System.Collections.Generic;

namespace FleetManagement.BLL.Models.Dtos.WriteDtos
{
    public class UpdateFuelCardDto
    {
        public int Id { get; set; }

        public string CardNumber { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string Pincode { get; set; }

        public AuthenticationType AuthenticationType { get; set; }

        public bool Blocked { get; set; }

        public FuelCardOptions FuelCardOptions { get; set; }

        public List<FuelCardDriverDto> FuelCardDrivers { get; set; }
    }
}
