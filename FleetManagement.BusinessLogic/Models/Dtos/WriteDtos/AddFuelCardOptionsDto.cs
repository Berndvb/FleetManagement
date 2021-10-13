using System.Collections.Generic;
using FleetManagement.Framework.Models.Enums;

namespace FleetManagement.BLL.Models.Dtos.WriteDtos
{
    public class AddFuelCardOptionsDto
    {
        public FuelType Fueltype { get; set; }

        public List<string> ExtraServices { get; set; }
    }
}
