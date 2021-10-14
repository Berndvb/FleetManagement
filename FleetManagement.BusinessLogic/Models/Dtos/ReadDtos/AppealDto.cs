using System;
using FleetManagement.Framework.Models.Enums;

namespace FleetManagement.BLL.Models.Dtos.ReadDtos
{
    public class AppealDto
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public AppealType AppealType { get; set; }

        public DateTime? FirstDatePlanning { get; set; }

        public DateTime? SecondDatePlanning { get; set; }

        public AppealStatus Status { get; set; }

        public VehicleOverviewDto Vehicle { get; set; }

        public DriverOverviewDto Driver { get; set; }

        public string Message { get; set; }
    }
}
