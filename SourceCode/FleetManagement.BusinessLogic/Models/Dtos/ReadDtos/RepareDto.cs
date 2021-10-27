using FleetManagement.Framework.Models.Enums;
using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace FleetManagement.BLL.Models.Dtos.ReadDtos
{
    public class RepareDto : AdministrationDto
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ReparationStatus ReparationStatus { get; set; }

        public DateTime IncidentDate { get; set; }

        public string DamageDescription { get; set; }

        public string InsuranceCompany { get; set; }

        public string ReferenceNumber { get; set; }
    }
}
