using System.Collections.Generic;
using FleetManagement.Framework.Helpers;
using FleetManagement.Framework.Models.Enums;

namespace FleetManagement.BLL.Models.Dtos.ReadDtos
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
