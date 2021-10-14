using System;
using System.Collections.Generic;
using FleetManagement.Framework.Models.Enums;

namespace FleetManagement.BLL.Models.Dtos.ReadDtos
{

    public class RepareDto : AdministrationDto
    {
        public ReparationStatus ReparationStatus { get; set; }

        public DateTime IncidentDate { get; set; }

        public string DamageDescription { get; set; }

        public string InsuranceCompany { get; set; }

        public string ReferenceNumber { get; set; }
    }
}
