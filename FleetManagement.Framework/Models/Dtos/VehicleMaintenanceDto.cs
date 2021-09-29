using System;

namespace FleetManagement.Framework.Models.Dtos
{
    public class VehicleMaintenanceDto
    {
        public int Id { get; set; }

        public DateTime InvoiceDate { get; set; }

        public VehicleMaintenanceDto(
            int id,
            DateTime invoiceDate)
        {
            Id = id;
            InvoiceDate = invoiceDate;
        }
    }
}
