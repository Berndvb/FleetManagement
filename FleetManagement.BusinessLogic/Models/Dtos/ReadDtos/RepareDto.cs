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

        public RepareDto(
            int id,
            ReparationStatus reparationStatus,
            DateTime incidentDate,
            DateTime? invoiceDate,
            GarageDto garage,
            List<FileDto> documents,
            string damageDescription,
            string insuranceCompany,
            string referenceNumber)
        {
            Id = id;
            ReparationStatus = reparationStatus;
            IncidentDate = incidentDate;
            InvoiceDate = invoiceDate;
            Garage = garage;
            Documents = documents;
            DamageDescription = damageDescription;
            InsuranceCompany = insuranceCompany;
            ReferenceNumber = referenceNumber;
        }

        public RepareDto()
        {
        }
    }
}
