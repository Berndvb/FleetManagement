using FleetManagement.Framework.Models.Enums;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace FleetManagement.BLL.Models.Dtos.ReadDtos
{
    public class DriverOverviewDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DriversLicenseType DriversLicenseType { get; set; }

        public bool InService { get; set; }
    }
}
