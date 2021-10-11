using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Framework.Models.Dtos.WriteDtos
{
    public class AddContactInfoDto
    {

        [EmailAddress]
        public string EmailAddress { get; set; }

        public string CellPhoneNumber { get; set; }

        public string TelephoneNumber { get; set; }

        public AddAddressDto Address { get; set; }
    }
}
