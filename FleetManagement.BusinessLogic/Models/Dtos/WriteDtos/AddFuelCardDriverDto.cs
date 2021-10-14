using FleetManagement.Domain.Models;
using System;

namespace FleetManagement.BLL.Models.Dtos.WriteDtos
{
    public class AddFuelCardDriverDto
    {

        public bool Active { get; set; }

        public DateTime CreationDate { get; set; }

        public int FuelCardId { get; set; }

        public int DriverId { get; set; }
    }
}
