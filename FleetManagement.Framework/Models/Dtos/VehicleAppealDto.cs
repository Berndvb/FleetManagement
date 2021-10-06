using FleetManagement.Framework.Models.Enums;
using System;

namespace FleetManagement.Framework.Models.Dtos
{
    public class VehicleAppealDto
    {
        public int Id { get; set; }

        public AppealType AppealType { get; set; }

        public DateTime? FirstDatePlanning { get; set; }

        public DateTime? SecondDatePlanning { get; set; }

        public AppealStatu Status { get; set; }

        public DateTime CreationDate { get; set; }

        public VehicleAppealDto(
            int id,
            AppealType appealType,
            DateTime? firstDatePlanning,
            DateTime? secondDatePlanning,
            AppealStatu status,
            DateTime creationDate)
        {
            Id = id;
            AppealType = appealType;
            FirstDatePlanning = firstDatePlanning;
            SecondDatePlanning = secondDatePlanning;
            Status = status;
            CreationDate = creationDate;
        }

        public VehicleAppealDto()
        {
        }
    }
}
