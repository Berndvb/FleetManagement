using FleetManagement.Framework.Models.Enums;
using System;

namespace FleetManagement.Domain.Models
{
    public class Appeal : IBaseClass
    {
        public int Id { get;  set; }

        public DateTime CreationDate { get; set; }

        public AppealType AppealType { get; set; }

        public DateTime? FirstDatePlanning { get; set; }

        public DateTime? SecondDatePlanning { get; set; }

        public AppealStatus Status { get; set; }

        public Vehicle Vehicle { get; set; }

        public Driver Driver { get; set; }

        public int? RepareId { get; set; }

        public Repare Repare { get; set; }

        public int? MaintenanceId { get; set; }

        public Maintenance Maintenance { get; set; }

        public string Message { get; set; }

        public Appeal(
            DateTime creationDate,
            AppealType appealType,
            AppealStatus status,
            Vehicle vehicle,
            Driver driver,
            Repare repare = null,
            Maintenance maintenance = null,
            DateTime? firstDatePlanning = null,
            DateTime? secondDatePlanning = null,
            string message = null)
        {
            CreationDate = creationDate;
            AppealType = appealType;
            Vehicle = vehicle;
            Driver = driver;
            Repare = repare;
            Maintenance = maintenance;
            FirstDatePlanning = firstDatePlanning;
            SecondDatePlanning = secondDatePlanning;
            Message = message;
                
        }

        private Appeal()
        {
        }
    }
}
