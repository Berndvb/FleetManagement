using FleetManagement.Framework.Models.Enums;
using System;

namespace FleetManagement.Framework.Models.Dtos.ShowDtos
{
    public class AppealDto
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public AppealType AppealType { get; set; }

        public DateTime? FirstDatePlanning { get; set; }

        public DateTime? SecondDatePlanning { get; set; }

        public AppealStatu Status { get; set; }

        public VehicleOverviewDto Vehicle { get; set; }

        public DriverDetailsDto Driver { get; set; }

        public string Message { get; set; }

        public AppealDto(
            int id,
            DateTime creationDate,
            AppealType appealType,
            DateTime firstDatePlanning,
            DateTime? secondDatePlanning,
            AppealStatu status,
            VehicleOverviewDto vehicle,
            string message)
        {
            Id = id;
            CreationDate = creationDate;
            AppealType = appealType;
            FirstDatePlanning = firstDatePlanning;
            SecondDatePlanning = secondDatePlanning;
            Status = status;
            Vehicle = vehicle;
            Message = message;
        }

        public AppealDto()
        {
        }
    }
}
