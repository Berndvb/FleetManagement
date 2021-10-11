using FleetManagement.Framework.Models.Dtos.ReadDtos;
using FleetManagement.Framework.Models.Enums;

namespace FleetManagement.Framework.Models.Dtos.WriteDtos
{
    public class AddDriverDto
    {
        public IdentityPersonDto Identity { get; set; }

        public ContactInfoDto Contactinfo { get; set; }

        public DriversLicenseTypes DriversLicenseType { get; set; }

        public bool InService { get; set; }

        public AddDriverDto(
            IdentityPersonDto identity,
            ContactInfoDto contactInfo,
            DriversLicenseTypes driversLicenseType,
            bool inService)
        {
            Identity = identity;
            Contactinfo = contactInfo;
            DriversLicenseType = driversLicenseType;
            InService = inService;
        }

        public AddDriverDto()
        {
        }
    }
}
