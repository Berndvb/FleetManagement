namespace FleetManagement.Domain.Models
{
    public class Address : IBaseClass
    {
        public int Id { get; internal set; }

        public string Street { get; internal set; }

        public string StreetNumber { get; internal set; }

        public string City { get; internal set; }

        public string Postcode { get; internal set; }
    }
}
