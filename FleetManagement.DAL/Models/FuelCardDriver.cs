using System;

namespace FleetManagement.Domain.Models
{
    public class FuelCardDriver
    {
        public int Id { get; set; }

        public ReadFuelCard FuelCard { get; set; }

        public ReadDriver Driver { get; set; }

        public bool Active { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ClosureDate { get; set; }
    }
}
