using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.Framework.Models.Enums;
using System.Collections.Generic;

namespace FleetManagement.BLL.Models.Dtos.WriteDtos
{
    public class UpdateDriverVehicle
    {
        public int Id { get; set; }

        public IdentityPersonDto Identity { get; set; }

        public ContactInfoDto Contactinfo { get; set; }

        public DriversLicenseType DriversLicenseType { get; set; }

        public bool InService { get; set; }

        public List<FuelCardDriverDto> FuelCards { get; set; }

        public List<DriverVehicleDto> DriverVehicles { get; set; }

        public List<AppealDto> Appeals { get; set; }
    }
}
