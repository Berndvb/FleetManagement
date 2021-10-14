namespace FleetManagement.BLL.Models.Dtos.ReadDtos
{
    public class DriverDetailsDto
    {
        public int Id { get; set; }

        public IdentityPersonDto Identity { get; set; }

        public ContactInfoDto Contactinfo { get; set; }

        public string DriversLicenseType { get; set; }

        public bool InService { get; set; }
    }
}
