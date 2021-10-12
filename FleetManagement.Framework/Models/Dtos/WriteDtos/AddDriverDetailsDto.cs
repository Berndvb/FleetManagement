using System.Collections.Generic;

namespace FleetManagement.Framework.Models.Dtos.WriteDtos
{
    public class AddDriverDetailsDto
    {
        public AddIdentityPersonDto Identity { get; set; }

        public AddContactInfoDto Contactinfo { get; set; }

        public string DriversLicenseType { get; set; }

        public bool InService { get; set; }

        public int FuelCardId { get; set; }

        public int VehicleId { get; set; }

        public List<int> AppealIds { get; set; }
    }
}
