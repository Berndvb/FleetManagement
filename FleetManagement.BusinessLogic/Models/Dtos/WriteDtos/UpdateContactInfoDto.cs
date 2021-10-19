using FleetManagement.BLL.Models.Dtos.ReadDtos;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.BLL.Models.Dtos.WriteDtos
{
    public class UpdateContactInfoDto
    {
        public int DriverId { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string Street { get; set; }

        public string StreetNumber { get; set; }

        public string City { get; set; }

        public string Postcode { get; set; }
    }
}
