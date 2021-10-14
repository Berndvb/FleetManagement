using System.ComponentModel.DataAnnotations;

namespace FleetManagement.BLL.Models.Dtos.WriteDtos
{
    public class AddContactInfoDto
    {

        [EmailAddress]
        public string EmailAddress { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public AddAddressDto Address { get; set; }
    }
}
