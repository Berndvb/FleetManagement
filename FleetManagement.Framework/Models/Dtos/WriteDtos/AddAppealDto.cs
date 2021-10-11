using FleetManagement.Framework.Models.Enums;
using System;

namespace FleetManagement.Framework.Models.Dtos.WriteDtos
{
    public class AddAppealDto
    {
        public DateTime CreationDate { get; set; }

        public AppealType AppealType { get; set; }

        public DateTime? FirstDatePlanning { get; set; }

        public DateTime? SecondDatePlanning { get; set; }

        public AppealStatus Status { get; set; }

        public AddVehicleDetailsDto Vehicle { get; set; }

        public AddDriverDetailsDto Driver { get; set; }

        public string Message { get; set; }
    }
}
