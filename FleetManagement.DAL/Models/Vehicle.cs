using System.Collections.Generic;

namespace FleetManagement.Domain.Models
{
    public class Vehicle : IBaseClass
    {
        public int Id { get; private set; }

        public IdentityVehicle Identity { get; private set; }

        public string Mileage { get; private set; }

        public List<Maintenance> Maintenances { get; private set; }

        public List<Repare> Reparations { get; private set; }

        public List<DriverVehicle> DriverVehicles { get; private set; }

        public List<Appeal> Appeals { get; private set; }
    }
}
