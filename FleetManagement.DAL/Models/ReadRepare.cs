using FleetManagement.Framework.Models.Enums;
using System;

namespace FleetManagement.Domain.Models
{
    public class ReadRepare : Administration
    {
        public DateTime IncidentDate { get; set; }

        public string DamageDescription { get; set; }

        public string InsuranceCompany { get; set; }

        public string ReferenceNumber { get; set; }

        public EReparationStatus ReparationStatus { get; set; }

    }
}
