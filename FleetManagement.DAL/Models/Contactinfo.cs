namespace FleetManagement.Domain.Models
{
    public class ContactInfo
    {
        public int Id { get; set; }

        public string EmailAddress { get; set; }

        public string CellPhoneNumber { get; set; }

        public string TelephoneNumber { get; set; }

        public Address Address { get; set; }
    }
}
