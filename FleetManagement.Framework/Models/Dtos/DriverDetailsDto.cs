using FleetManagement.Framework.Models.Enums;

namespace FleetManagement.Framework.Models.Dtos.ShowDtos
{
    public class DriverDetailsDto
    {
        public int Id { get; set; }

        public IdentityPersonDto Identity { get; set; }

        public ContactInfoDto Contactinfo { get; set; }

        public DriversLicenseTypes DriversLicenseType { get; set; }

        public bool InService { get; set; }

        public DriverDetailsDto(
            int id,
            IdentityPersonDto identity,
            ContactInfoDto contactInfo,
            DriversLicenseTypes driversLicenseType,
            bool inService)
        {
            Id = id;
            Identity = identity;
            Contactinfo = contactInfo;
            DriversLicenseType = driversLicenseType;
            InService = inService;
        }

        public DriverDetailsDto()
        {
        }
    }
}
