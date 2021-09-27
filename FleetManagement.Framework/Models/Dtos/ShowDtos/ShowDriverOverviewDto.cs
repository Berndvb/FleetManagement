﻿using FleetManagement.Framework.Models.Enums;

namespace FleetManagement.Framework.Models.Dtos
{
    public class ShowDriverOverviewDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public EDriversLicenseType DriversLicenseType { get; set; }

        public bool InService { get; set; }

        public ShowDriverOverviewDto(
            int id,
            string name,
            EDriversLicenseType driversLicenseType,
            bool inService)
        {
            Id = id;
            Name = name;
            DriversLicenseType = driversLicenseType;
            InService = inService;
        }
    }
}