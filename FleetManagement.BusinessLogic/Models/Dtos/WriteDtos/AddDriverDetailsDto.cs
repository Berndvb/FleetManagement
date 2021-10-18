
using FleetManagement.Framework.Models.Enums;

namespace FleetManagement.BLL.Models.Dtos.WriteDtos
{
    public class AddDriverDetailsDto
    {
        public AddIdentityPersonDto Identity { get; set; }

        public AddContactInfoDto Contactinfo { get; set; }

        public DriversLicenseType DriversLicenseType { get; set; }

        public bool InService { get; set; }
    }
}
