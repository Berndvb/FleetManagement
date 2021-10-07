using FleetManagement.Framework.Models.Dtos.ShowDtos;
using System;
using System.Collections.Generic;

namespace FleetManagement.Framework.Models.Dtos
{
    public abstract class AdministrationDto
    {
        public int Id { get; set; }

        public VehicleDetailsDto Vehicle { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? InvoiceDate { get; set; }

        public float Price { get; set; }

        public GarageDto Garage { get; set; }

        public List<FileDto> Documents { get; set; }

        public DriverDetailsDto Driver { get; set; }
    }
}
