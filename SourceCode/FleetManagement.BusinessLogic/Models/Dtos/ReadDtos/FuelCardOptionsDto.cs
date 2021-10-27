using FleetManagement.Framework.Models.Enums;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace FleetManagement.BLL.Models.Dtos.ReadDtos
{
    public class FuelCardOptionsDto
    {
        public int Id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FuelType Fueltype { get; set; }

        public List<string> ExtraServices { get; set; }
    }
}
