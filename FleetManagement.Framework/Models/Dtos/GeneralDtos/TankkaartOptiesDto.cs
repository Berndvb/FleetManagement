using FleetManagement.Framework.Helpers;
using FleetManagement.Framework.Models.Enums;
using System.Collections.Generic;

namespace FleetManagement.Framework.Models.Dtos.GeneralDtos
{
    public class TankkaartOptiesDto
    {
        public int Id { get; set; }

        public FuelTypes BrandstofType { get; set; }

        public List<string> ExtraServices { get; private set; }

        public TankkaartOptiesDto(
            int id, 
            FuelTypes brandstofType, 
            string extraServices)
        {
            Id = id;
            BrandstofType = brandstofType;
            ExtraServices = extraServices.SplitToText();
        }
    }
}
