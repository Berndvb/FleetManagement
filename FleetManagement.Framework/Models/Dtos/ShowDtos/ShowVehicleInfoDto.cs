using FleetManagement.Framework.Helpers;
using FleetManagement.Framework.Models.Enums;
using System;
using System.Collections.Generic;

namespace FleetManagement.Framework.Models.Dtos
{
    public class ShowVehicleInfoDto
    {
        public DriverVehicleDto DriverVehicle { get; set; }

        public VehicleDto Vehicle { get; set; }

        public ShowVehicleInfoDto(
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

                public EFuelType FuelType { get; set; }

                public string Brand { get; set; }

                public string Model { get; set; }

                public VehicleIdentityDto(
                    string id,
                    EFuelType fuelType,
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

                public EReparationStatus ReparationStatus { get; set; }

                public DateTime IncidentDate { get; set; }

                public DateTime? InvoiceDate { get; set; }

                public VehicleReparationDto(
                    string id,
                    EReparationStatus reparationStatus,
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

                public EAppealType AppealType { get; set; }

                public EAppealStatus Status { get; set; }

                public DateTime CreationDate { get; set; }

                public VehicleAppealDto(
                    int id,
                    EAppealType appealType,
                    EAppealStatus status,
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

