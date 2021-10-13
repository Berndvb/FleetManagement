namespace FleetManagement.BLL.Models.Dtos.ReadDtos
{
    public class DriverOverviewDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public string DriversLicenseType { get; set; }

        public bool InService { get; set; }

        public DriverOverviewDto(
            int id,
            string name,
            string driversLicenseType,
            bool inService)
        {
            Id = id;
            Name = name;
            DriversLicenseType = driversLicenseType;
            InService = inService;
        }

        public DriverOverviewDto()
        {
        }
    }
}
