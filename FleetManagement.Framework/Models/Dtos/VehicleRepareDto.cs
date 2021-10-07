using FleetManagement.Framework.Models.Enums;
using System;
using System.Collections.Generic;

namespace FleetManagement.Framework.Models.Dtos
{

    public class VehicleRepareDto
    {
        public int Id { get; set; }

        public ReparationStatus ReparationStatus { get; set; }

        public DateTime IncidentDate { get; set; }

        public DateTime? InvoiceDate { get; set; }

        public GarageDto Garage { get; set; }

        public List<FileDto> Documents { get; set; }

        public VehicleRepareDto(
            int id,
            ReparationStatus reparationStatus,
            DateTime incidentDate,
            DateTime? billingDate,
            GarageDto garage,
            List<FileDto> documents)
        {
            Id = id;
            ReparationStatus = reparationStatus;
            IncidentDate = incidentDate;
            InvoiceDate = billingDate;
            Garage = garage;
            Documents = documents;
        }

        public VehicleRepareDto()
        {
        }
    }
}
