using FleetManagement.Framework.Models.Enums;

namespace FleetManagement.Framework.Models.Dtos.ShowDtos
{
    public class DriverOverviewDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public DriversLicenseTypes DriversLicenseType { get; set; }

        public bool InService { get; set; }

        public DriverOverviewDto(
            int id,
            string name,
            DriversLicenseTypes driversLicenseType,
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
