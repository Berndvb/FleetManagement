using System.ComponentModel.DataAnnotations;

namespace FleetManagement.BLL.Models.Dtos.ReadDtos
{
    public class ContactInfoDto
    {
        public int Id { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public AddressDto Address { get; set; }

        public ContactInfoDto(
            int id,
            string emailAddress,
            string phoneNumber,
            AddressDto address)
        {
            Id = id;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public ContactInfoDto()
        {
        }
    }
}
