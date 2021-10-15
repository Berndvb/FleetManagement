
namespace FleetManagement.BLL.Models.Dtos.WriteDtos
{
    public class AddDriverDetailsDto
    {
        public AddIdentityPersonDto Identity { get; set; }

        public AddContactInfoDto Contactinfo { get; set; }

        public string DriversLicenseType { get; set; }

        public bool InService { get; set; }
    }
}
