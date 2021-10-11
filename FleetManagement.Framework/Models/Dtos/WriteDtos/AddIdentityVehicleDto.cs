using FleetManagement.Framework.Models.Enums;
using System.Collections.Generic;

namespace FleetManagement.Framework.Models.Dtos.WriteDtos
{
    public class AddIdentityVehicleDto
    {
        public FuelType FuelType { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string LicensePlates { get; set; }
    }
}
