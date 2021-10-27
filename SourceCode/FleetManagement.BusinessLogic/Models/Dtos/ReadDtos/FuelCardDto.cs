using FleetManagement.Framework.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace FleetManagement.BLL.Models.Dtos.ReadDtos
{
    public class FuelCardDto
    {
        public int Id { get; set; }

        public string CardNumber { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string Pincode { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AuthenticationType AuthenticationType { get; set; }

        public bool Blocked { get; set; }

        public FuelCardOptionsDto FuelCardOptions { get; set; }

        public List<FuelCardDriverDto> FuelCardDrivers { get; set; }
    }
}
