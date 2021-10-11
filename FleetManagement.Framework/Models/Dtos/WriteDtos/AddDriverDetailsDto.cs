using FleetManagement.Framework.Models.WriteDtos;
using System.Collections.Generic;

namespace FleetManagement.Framework.Models.Dtos.WriteDtos
{
    public class AddDriverDetailsDto
    {
        public AddIdentityPersonDto Identity { get; set; }

        public AddContactInfoDto Contactinfo { get; set; }

        public string DriversLicenseType { get; set; }

        public bool InService { get; set; }

        public List<AddFuelCardDriverDto> FuelCards { get; set; }

        public List<AddDriverVehicleDto> Vehicles { get; set; }

        public List<AddAppealDto> Appeals { get; set; }
    }
}
