using FleetManagement.Framework.Models.Enums;

namespace FleetManagement.BLL.Models.Dtos.ReadDtos
{
    public class DriverOverviewDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public DriversLicenseType DriversLicenseType { get; set; }

        public bool InService { get; set; }
    }
}
