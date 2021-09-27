using FleetManagement.Framework.Helpers;
using FleetManagement.Framework.Models.Enums;
using System.Collections.Generic;

namespace FleetManagement.Framework.Models.Dtos
{
    public class TankkaartOptiesDto
    {
        public string Id { get; set; }

        public EFuelType BrandstofType { get; set; }

        public List<string> ExtraServices { get; private set; }

        public TankkaartOptiesDto(string id, EFuelType brandstofType, string extraServices)
        {
            Id = id;
            BrandstofType = brandstofType;
            ExtraServices = extraServices.SplitToText();
        }
    }
}
