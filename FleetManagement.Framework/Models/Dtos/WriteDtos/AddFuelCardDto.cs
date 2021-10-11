using FleetManagement.Framework.Models.Enums;
using FleetManagement.Framework.Models.WriteDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.Framework.Models.Dtos.WriteDtos
{
    public class AddFuelCardDto
    {
        public string CardNumber { get; set; }

        public DateTime ExpirationDate { get; set; }

        public AuthenticatieType AuthenticationType { get; set; }

        public AddFuelCardOptionsDto FuelCardOptions { get; set; }

        public List<AddFuelCardDriverDto> FuelCardDrivers { get; set; }

        public bool Blocked { get; set; }
    }
}
