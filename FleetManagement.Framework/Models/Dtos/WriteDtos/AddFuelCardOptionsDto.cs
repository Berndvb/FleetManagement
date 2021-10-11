using FleetManagement.Framework.Models.Enums;
using System.Collections.Generic;

namespace FleetManagement.Framework.Models.Dtos.WriteDtos
{
    public class AddFuelCardOptionsDto
    {
        public FuelType Fueltype { get; set; }

        public List<string> ExtraServices { get; set; }
    }
}
