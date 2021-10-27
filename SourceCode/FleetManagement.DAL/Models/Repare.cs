using FleetManagement.Framework.Models.Enums;
using System;

namespace FleetManagement.Domain.Models
{
    public class Repare : Administration, IBaseClass
    {
        public DateTime IncidentDate { get; set; }

        public string DamageDescription { get; set; }

        public string InsuranceCompany { get; set; }

        public string ReferenceNumber { get; set; }

        public ReparationStatus ReparationStatus { get; set; }

    }
}
