namespace FleetManagement.Domain.Models
{
    public class ContactInfo : IBaseClass
    {
        public int Id { get; internal set; }

        public string EmailAddress { get; internal set; }

        public string PhoneNumber { get; internal set; }

        public Address Address { get; internal set; }
    }
}
