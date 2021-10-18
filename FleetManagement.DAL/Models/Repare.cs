using FleetManagement.Framework.Models.Enums;
using System;

namespace FleetManagement.Domain.Models
{
    public class Repare : Administration, IBaseClass
    {
        public DateTime IncidentDate { get; private set; }

        public string DamageDescription { get; private set; }

        public string InsuranceCompany { get; private set; }

        public string ReferenceNumber { get; private set; }

        public ReparationStatus ReparationStatus { get; private set; }

    }
}
