﻿using FleetManagement.Framework.Models.Enums;
using System;

namespace FleetManagement.Framework.Models.Dtos
{

    public class VehicleReparationDto
    {
        public int Id { get; set; }

        public ReparationStatus ReparationStatus { get; set; }

        public DateTime IncidentDate { get; set; }

        public DateTime? InvoiceDate { get; set; }

        public VehicleReparationDto(
            int id,
            ReparationStatus reparationStatus,
            DateTime incidentDate,
            DateTime? billingDate)
        {
            Id = id;
            ReparationStatus = reparationStatus;
            IncidentDate = incidentDate;
            InvoiceDate = billingDate;
        }

        public VehicleReparationDto()
        {
        }
    }
}
