using FleetManagement.Framework.Models.Enums;
using System;

namespace FleetManagement.Domain.Models
{
    public class Appeal : IBaseClass
    {
        public int Id { get; private set; }

        public DateTime CreationDate { get; private set; }

        public AppealType AppealType { get; private set; }

        public DateTime? FirstDatePlanning { get; private set; }

        public DateTime? SecondDatePlanning { get; private set; }

        public AppealStatus Status { get; private set; }

        public Vehicle Vehicle { get; private set; }

        public Driver Driver { get; private set; }

        public int? RepareId { get; private set; }

        public Repare Repare { get; private set; }

        public int? MaintenanceId { get; private set; }

        public Maintenance Maintenance { get; private set; }

        public string Message { get; private set; }

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

        public void ChangeAppealInfoForDriver(
            AppealType appealType,
            DateTime? firstDatePlanning,
            DateTime? secondDatePlanning,
            string message)
        {
            AppealType = appealType;
            FirstDatePlanning = firstDatePlanning;
            SecondDatePlanning = secondDatePlanning;
            Message = message;
        }
    }
}
