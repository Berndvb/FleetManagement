using FleetManagement.Framework.Models.Enums;

namespace FleetManagement.Framework.Models.Dtos
{
    public class VehicleIdentityDto
    {
        public int Id { get; set; }

        public FuelTypes FuelType { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public VehicleIdentityDto(
            int id,
            FuelTypes fuelType,
            string merk,
            string model)
        {
            Id = id;
            FuelType = fuelType;
            Brand = merk;
            Model = model;
        }

        public VehicleIdentityDto()
        {
        }
    }
}
