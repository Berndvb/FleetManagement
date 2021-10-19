using FleetManagement.Framework.Models.Enums;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace FleetManagement.BLL.Models.Dtos.ReadDtos
{
    public class DriverDetailsDto
    {
        public int Id { get; set; }

        public IdentityPersonDto Identity { get; set; }

        public ContactInfoDto Contactinfo { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DriversLicenseType DriversLicenseType { get; set; }

        public bool InService { get; set; }
    }
}
