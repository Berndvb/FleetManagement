using FleetManagement.Domain.Interfaces;
using FleetManagement.Framework.Models.Enums;
using System.Collections.Generic;

namespace FleetManagement.Domain.Models
{
    public class Driver : IBaseClass
    {
        public int Id { get; set; } 

        public IdentityPerson Identity { get; set; }

        public ContactInfo Contactinfo { get; set; }

        public DriversLicenseTypes DriversLicenseType { get; set; }

        public bool InService { get; set; }

        public List<FuelCardDriver> Fuelcards { get; set; }

        public List<DriverVehicle> Vehicles { get; set; }

        public List<Appeal> Appeals { get; set; }
    }
}
