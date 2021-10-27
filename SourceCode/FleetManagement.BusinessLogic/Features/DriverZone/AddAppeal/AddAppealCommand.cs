using FleetManagement.Framework.Models.Enums;
using MediatR.Cqrs.Commands;
using System;

namespace FleetManagement.BLL.Features.DriverZone.AddAppeal
{
    public class AddAppealCommand : ICommand<AddAppealCommandResult>
    {
        public DateTime CreationDate { get; set; }

        public AppealType AppealType { get; set; }

        public DateTime? FirstDatePlanning { get; set; }

        public DateTime? SecondDatePlanning { get; set; }

        public AppealStatus Status { get; set; }

        public int VehicleId { get; set; }

        public int DriverId { get; set; }

        public DateTime? IncidentDate { get; set; }

        public string DamageDescription { get; set; }

        public string VehicleLocation { get; set; }

        public string Message { get; set; }
    }
}
