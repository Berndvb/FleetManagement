using FleetManagement.Domain.Interfaces.Models;

namespace FleetManagement.Domain.Models
{
    public class Address : IBaseClass
    {
        public int Id { get; set; }

        public string Street { get; set; }

        public string StreetNumber { get; set; }

        public string City { get; set; }

        public string Postcode { get; set; }
    }
}
