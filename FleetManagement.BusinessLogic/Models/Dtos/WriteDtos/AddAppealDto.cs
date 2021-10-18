using System;
using FleetManagement.Framework.Models.Enums;

namespace FleetManagement.BLL.Models.Dtos.WriteDtos
{
    public class AddAppealDto
    {
        public DateTime CreationDate { get; set; }

        public AppealType AppealType { get; set; }

        public DateTime? FirstDatePlanning { get; set; }

        public DateTime? SecondDatePlanning { get; set; }

        public AppealStatus Status { get; set; }

        public int VehicleId { get; set; }

        public int DriverId { get; set; }

        public string Message { get; set; }
    }
}
