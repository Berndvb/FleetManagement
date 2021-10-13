using FleetManagement.Framework.Models.Enums;

namespace FleetManagement.BLL.Models.Dtos.WriteDtos
{
    public class AddIdentityVehicleDto
    {
        public FuelType FuelType { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string LicensePlates { get; set; }
    }
}
