using FleetManagement.Framework.Models.Enums;
using System.Collections.Generic;

namespace FleetManagement.BLL.Models.Dtos.ReadDtos
{
    public class FuelCardOptionsDto
    {
        public int Id { get; set; }

        public FuelType Fueltype { get; set; }

        public List<string> ExtraServices { get; set; }
    }
}
