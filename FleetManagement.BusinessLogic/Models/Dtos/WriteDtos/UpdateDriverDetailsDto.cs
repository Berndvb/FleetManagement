using FleetManagement.BLL.Models.Dtos.ReadDtos;
using System.Collections.Generic;

namespace FleetManagement.BLL.Models.Dtos.WriteDtos
{
    public class UpdateDriverDetailsDto
    {
        public int Id { get; set; }

        public IdentityPersonDto Identity { get; set; }

        public ContactInfoDto Contactinfo { get; set; }

        public string DriversLicenseType { get; set; }

        public bool InService { get; set; }

        public int FuelCardId { get; set; }

        public int VehicleId { get; set; }

    }
}
