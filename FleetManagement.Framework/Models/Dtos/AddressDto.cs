namespace FleetManagement.Framework.Models.Dtos
{
    public class AddressDto
    {
        public int Id { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Postcode { get; set; }

        public AddressDto(
            int id,
            string street,
            string city,
            string postcode)
        {
            Id = id;
            Street = street;
            City = city;
            Postcode = postcode;
        }

        public AddressDto()
        {
        }
    }
}
