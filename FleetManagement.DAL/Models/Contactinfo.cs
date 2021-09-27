namespace FleetManagement.Domain.Models
{
    public class ContactInfo
    {
        public string Id { get; set; }

        public string EmailAdres { get; set; }

        public string GsmNumber { get; set; }

        public string TelephoneNumber { get; set; }

        public Address Address { get; set; }
    }
}
