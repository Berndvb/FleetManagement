using FleetManagement.Framework.Models.Enums;
using System;
using System.Text.Json.Serialization;

namespace FleetManagement.BLL.Models.Dtos.ReadDtos
{
    public class AppealDto
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AppealType AppealType { get; set; }

        public DateTime? FirstDatePlanning { get; set; }

        public DateTime? SecondDatePlanning { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AppealStatus Status { get; set; }

        public VehicleOverviewDto Vehicle { get; set; }

        public DriverOverviewDto Driver { get; set; }

        public string Message { get; set; }
    }
}
