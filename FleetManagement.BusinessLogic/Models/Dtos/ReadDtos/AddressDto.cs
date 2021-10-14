namespace FleetManagement.BLL.Models.Dtos.ReadDtos
{
    public class AddressDto
    {
        public int Id { get; set; }

        public string Street { get; set; }

        public string StreetNumber { get; set; }

        public string City { get; set; }

        public string Postcode { get; set; }
    }
}
