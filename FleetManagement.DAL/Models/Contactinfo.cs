using FleetManagement.Domain.Interfaces.Models;

namespace FleetManagement.Domain.Models
{
    public class ContactInfo : IBaseClass
    {
        public int Id { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public Address Address { get; set; }
    }
}
