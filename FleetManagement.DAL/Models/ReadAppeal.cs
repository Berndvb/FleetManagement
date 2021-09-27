using FleetManagement.Framework.Models.Enums;
using System;

namespace FleetManagement.Domain.Models
{
    public class ReadAppeal
    {
        public string Id { get; set; }

        public DateTime CreationDate { get; set; }

        public EAppealType AppealType { get; set; }

        public DateTime? FirstDatePlanning { get; set; }

        public DateTime? SecondDatePlanning { get; set; }

        public EAppealStatus Status { get; set; }

        public ReadVehicle Vehicle { get; set; }

        public ReadDriver Driver { get; set; }

        public string Message { get; set; }
    }
}
