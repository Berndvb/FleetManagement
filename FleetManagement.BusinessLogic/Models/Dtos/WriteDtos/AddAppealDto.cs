using System;
using FleetManagement.Domain.Models;
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

        public Vehicle Vehicle { get; set; }

        public Driver Driver { get; set; }

        public Repare Repare { get; set; }

        public Maintenance Maintenance { get; set; }

        public string Message { get; set; }
    }
}
