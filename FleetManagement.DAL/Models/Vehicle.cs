using FleetManagement.Domain.Interfaces.Models;
using System.Collections.Generic;

namespace FleetManagement.Domain.Models
{
    public class Vehicle : IBaseClass
    {
        public int Id { get; set; }

        public IdentityVehicle Identity { get; set; }

        public string Mileage { get; set; }

        public List<Maintenance> Maintenances { get; set; }

        public List<Repare> Reparations { get; set; }

        public List<DriverVehicle> DriverVehicles { get; set; }

        public List<Appeal> Appeals { get; set; }
    }
}
