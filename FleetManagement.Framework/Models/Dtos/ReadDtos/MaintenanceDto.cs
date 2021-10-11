using System;
using System.Collections.Generic;

namespace FleetManagement.Framework.Models.Dtos.ReadDtos
{
    public class MaintenanceDto : AdministrationDto
    {

        public MaintenanceDto(
            int id,
            VehicleDetailsDto vehicle,
            DateTime creationDate,
            DateTime invoiceDate,
            float price,
            GarageDto garage,
            List<FileDto> documents,
            DriverDetailsDto driver)
        {
            Id = id;
            Vehicle = vehicle;
            CreationDate = creationDate;
            InvoiceDate = invoiceDate;
            Price = price;
            Garage = garage;
            Documents = documents;
            Driver = driver;
        }
    }
}
