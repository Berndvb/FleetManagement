using System;

namespace FleetManagement.Domain.Models
{
    public class DriverVehicle
    {
        public string Id { get; set; }

        public ReadVehicle Vehicle { get; set; }

        public ReadDriver Driver { get; set; }

        public bool Active { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ClosureDate { get; set; }
    }
}
