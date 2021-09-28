using FleetManagement.Domain.Interfaces;

namespace FleetManagement.Domain.Models
{
    public class ContactInfo : IBaseClass
    {
        public int Id { get; set; }

        public string EmailAddress { get; set; }

        public string CellPhoneNumber { get; set; }

        public string TelephoneNumber { get; set; }

        public Address Address { get; set; }
    }
}
