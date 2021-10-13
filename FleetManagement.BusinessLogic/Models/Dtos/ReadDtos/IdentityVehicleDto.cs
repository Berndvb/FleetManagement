using System.Collections.Generic;
using FleetManagement.Framework.Models.Enums;

namespace FleetManagement.BLL.Models.Dtos.ReadDtos
{
    public class IdentityVehicleDto
    {
        public int Id { get; set; }

        public FuelType FuelType { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public List<string> LicensePlates { get; set; }

        public IdentityVehicleDto(
            int id,
            FuelType fuelType,
            string merk,
            string model,
            List<string> licensePlates)
        {
            Id = id;
            FuelType = fuelType;
            Brand = merk;
            Model = model;
            LicensePlates = licensePlates;
        }

        public IdentityVehicleDto()
        {
        }
    }
}
