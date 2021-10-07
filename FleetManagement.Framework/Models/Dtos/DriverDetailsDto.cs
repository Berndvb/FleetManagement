﻿using FleetManagement.Framework.Models.Enums;
using System.Collections.Generic;

namespace FleetManagement.Framework.Models.Dtos.ShowDtos
{
    public class DriverDetailsDto
    {
        public int Id { get; set; }

        public IdentityPersonDto Identity { get; set; }

        public ContactInfoDto Contactinfo { get; set; }

        public DriversLicenseTypes DriversLicenseType { get; set; }

        public bool InService { get; set; }

        public List<FuelCardDriverDto> FuelCards { get; set; }

        public List<DriverVehicleDto> Vehicles { get; set; }

        public List<AppealDto> Appeals { get; set; }

        public DriverDetailsDto(
            int id,
            IdentityPersonDto identity,
            ContactInfoDto contactInfo,
            DriversLicenseTypes driversLicenseType,
            bool inService,
            List<FuelCardDriverDto> fuelCards,
            List<DriverVehicleDto> vehicles,
            List<AppealDto> appeals)
        {
            Id = id;
            Identity = identity;
            Contactinfo = contactInfo;
            DriversLicenseType = driversLicenseType;
            InService = inService;
            FuelCards = fuelCards;
            Vehicles = vehicles;
            Appeals = appeals;
        }

        public DriverDetailsDto()
        {
        }
    }
}
