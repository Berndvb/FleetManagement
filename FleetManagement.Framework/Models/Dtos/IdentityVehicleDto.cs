using FleetManagement.Framework.Models.Enums;
using System.Collections.Generic;

namespace FleetManagement.Framework.Models.Dtos
{
    public class IdentityVehicleDto
    {
        public int Id { get; set; }

        public FuelTypes FuelType { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public List<string> LicensePlates { get; set; }

        public IdentityVehicleDto(
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

        public IdentityVehicleDto()
        {
        }
    }
}
