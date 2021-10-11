using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Framework.Models.Dtos.ReadDtos
{
    public class ContactInfoDto
    {
        public int Id { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        public string CellPhoneNumber { get; set; }

        public string TelephoneNumber { get; set; }

        public AddressDto Address { get; set; }

        public ContactInfoDto(
            int id,
            string emailAddress,
            string cellPhoneNumber,
            string telephoneNumber,
            AddressDto address)
        {
            Id = id;
            EmailAddress = emailAddress;
            CellPhoneNumber = cellPhoneNumber;
            TelephoneNumber = telephoneNumber;
            Address = address;
        }

        public ContactInfoDto()
        {
        }
    }
}
