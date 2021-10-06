using FleetManagement.Framework.Helpers;
using FleetManagement.Framework.Models.Enums;
using System.Collections.Generic;

namespace FleetManagement.Framework.Models.Dtos
{
    public class FuelCardOptionsDto
    {
        public int Id { get; set; }

        public FuelType Fueltype { get; set; }

        public List<string> ExtraServices { get; set; }

        public FuelCardOptionsDto(
            int id,
            FuelType fuelType,
            string extraServices)
        {
            Id = id;
            Fueltype = fuelType;
            ExtraServices = extraServices.SplitToText();
        }
        public FuelCardOptionsDto()
        {
        }
    }
}
