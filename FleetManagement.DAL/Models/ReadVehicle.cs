using System.Collections.Generic;

namespace FleetManagement.Domain.Models
{
    public class ReadVehicle
    {
        public string Id { get; set; }

        public IdentityVehicle Identiity { get; set; }

        public string Mileage { get; set; }

        public List<ReadMaintenance> Maintenances { get; set; }

        public List<ReadRepare> Reparations { get; set; }

        public List<DriverVehicle> Drivers { get; set; }

        public List<ReadAppeal> Appeals { get; set; }
    }
}
