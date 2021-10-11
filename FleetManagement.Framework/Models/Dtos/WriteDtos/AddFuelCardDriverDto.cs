using FleetManagement.Framework.Models.Dtos.ReadDtos;
using FleetManagement.Framework.Models.Dtos.WriteDtos;
using System;

namespace FleetManagement.Framework.Models.WriteDtos
{
    public class AddFuelCardDriverDto
    {

        public bool Active { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ClosureDate { get; set; }

        public AddFuelCardDto FuelCard { get; set; }

        public AddDriverDetailsDto Driver { get; set; }

    }
}
