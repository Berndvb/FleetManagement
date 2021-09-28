using FleetManagement.Domain.Interfaces;
using FleetManagement.Framework.Models.Enums;
using System;

namespace FleetManagement.Domain.Models
{
    public class Appeal : IBaseClass
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public AppealType AppealType { get; set; }

        public DateTime? FirstDatePlanning { get; set; }

        public DateTime? SecondDatePlanning { get; set; }

        public AppealStatus Status { get; set; }

        public Vehicle Vehicle { get; set; }

        public Driver Driver { get; set; }

        public string Message { get; set; }
    }
}
