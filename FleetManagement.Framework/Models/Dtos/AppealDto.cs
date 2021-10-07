using FleetManagement.Framework.Models.Enums;
using System;

namespace FleetManagement.Framework.Models.Dtos.ShowDtos
{
    public class AppealDto
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public AppealsType AppealType { get; set; }

        public DateTime? FirstDatePlanning { get; set; }

        public DateTime? SecondDatePlanning { get; set; }

        public AppealStatus Status { get; set; }

        public VehicleDetailsDto Vehicle { get; set; }

        public DriverDetailsDto Driver { get; set; }

        public string Message { get; set; }

        public AppealDto(
            int id,
            DateTime creationDate,
            AppealsType appealType,
            DateTime firstDatePlanning,
            DateTime? secondDatePlanning,
            AppealStatus status,
            VehicleDetailsDto vehicle,
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
