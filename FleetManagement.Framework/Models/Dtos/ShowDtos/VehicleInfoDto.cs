using FleetManagement.Framework.Helpers;
using FleetManagement.Framework.Models.Enums;
using System;
using System.Collections.Generic;

namespace FleetManagement.Framework.Models.Dtos.ShowDtos
{
    public class VehicleInfoDto
    {
        public DriverVehicleDto DriverVehicle { get; set; }

        public VehicleDto Vehicle { get; set; }

        public VehicleInfoDto(
            DriverVehicleDto driverVehicle,
            VehicleDto vehicle)
        {
            DriverVehicle = driverVehicle;
            Vehicle = vehicle;
        }

        public class DriverVehicleDto
        {
            public int Id { get; set; }

            public bool Active { get; set; }

            public DateTime CreationDate { get; set; }

            public DateTime? ClosureDate { get; set; }

            public DriverVehicleDto(
                int id,
                bool active,
                DateTime creationDate,
                DateTime? closureDate)
            {
                Id = id;
                Active = active;
                CreationDate = creationDate;
                ClosureDate = closureDate;
            }
        }

        public class VehicleDto
        {
            public int Id { get; set; }

            public VehicleIdentityDto Identity { get; set; }

            public List<int> Mileage { get; set; }

            public List<VehicleMaintenanceDto> Maintenance { get; set; }

            public List<VehicleReparationDto> Reparations { get; set; }

            public List<VehicleAppealDto> Appeals { get; set; }

            public VehicleDto(
                int id,
                VehicleIdentityDto identity,
                string mileage,
                List<VehicleMaintenanceDto> maintenance,
                List<VehicleReparationDto> reparations,
                List<VehicleAppealDto> appeals)
            {
                Id = id;
                Identity = identity;
                Mileage = mileage.SplitToNumbers();
                Maintenance = maintenance;
                Reparations = reparations;
                Appeals = appeals;
            }

        }

        public class VehicleIdentityDto
        {
            public int Id { get; set; }

            public FuelTypes FuelType { get; set; }

            public string Brand { get; set; }

            public string Model { get; set; }

            public VehicleIdentityDto(
                int id,
                FuelTypes fuelType,
                string merk,
                string model)
            {
                Id = id;
                FuelType = fuelType;
                Brand = merk;
                Model = model;
            }
        }

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
        }

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

        public class VehicleAppealDto
        {
            public int Id { get; set; }

            public AppealTypes AppealType { get; set; }

            public AppealStatus Status { get; set; }

            public DateTime CreationDate { get; set; }

            public VehicleAppealDto(
                int id,
                AppealTypes appealType,
                AppealStatus status,
                DateTime creationDate)
            {
                Id = id;
                AppealType = appealType;
                Status = status;
                CreationDate = creationDate;
            }
        }
    }
}

