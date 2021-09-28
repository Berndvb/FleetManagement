using FleetManagement.Domain.Interfaces;
using System;

namespace FleetManagement.Domain.Models
{
    public class FuelCardDriver : IBaseClass
    {
        public int Id { get; set; }

        public FuelCard FuelCard { get; set; }

        public Driver Driver { get; set; }

        public bool Active { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ClosureDate { get; set; }
    }
}
