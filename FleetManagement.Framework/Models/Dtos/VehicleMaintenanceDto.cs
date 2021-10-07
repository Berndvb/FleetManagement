using System;
using System.Collections.Generic;

namespace FleetManagement.Framework.Models.Dtos
{
    public class VehicleMaintenanceDto
    {
        public int Id { get; set; }

        public DateTime InvoiceDate { get; set; }

        public GarageDto Garage { get; set; }

        public List<FileDto> Documents { get; set; }

        public VehicleMaintenanceDto(
            int id,
            DateTime invoiceDate,
            GarageDto garage,
            List<FileDto> documents)
        {
            Id = id;
            InvoiceDate = invoiceDate;
            Garage = garage;
            Documents = documents;
        }
    }
}
