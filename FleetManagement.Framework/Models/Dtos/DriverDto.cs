using FleetManagement.Framework.Models.Dtos.ShowDtos;
using FleetManagement.Framework.Models.Enums;
using System.Collections.Generic;

namespace FleetManagement.Framework.Models.Dtos
{
    public class DriverDto
    {
        public int Id { get; set; }

        public IdentityPersonDto Identity { get; set; }

        public ContactInfoDto Contactinfo { get; set; }

        public DriversLicenseTypes DriversLicenseType { get; set; }

        public bool InService { get; set; }

        public List<FuelCardDriverDto> FuelCards { get; set; }

        public List<DriverVehicleDto> Vehicles { get; set; }

        public List<AppealDto> Appeals { get; set; }
    }
}
