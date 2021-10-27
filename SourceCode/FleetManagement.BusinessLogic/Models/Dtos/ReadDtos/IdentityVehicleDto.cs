using System.Collections.Generic;
using System.Text.Json.Serialization;
using FleetManagement.Framework.Models.Enums;
using Newtonsoft.Json.Converters;

namespace FleetManagement.BLL.Models.Dtos.ReadDtos
{
    public class IdentityVehicleDto
    {
        public int Id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FuelType FuelType { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public List<string> LicensePlates { get; set; }
    }
}
