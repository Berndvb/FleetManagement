using FleetManagement.Domain.Interfaces.Models;
using FleetManagement.Framework.Models.Enums;
using System.Collections.Generic;

namespace FleetManagement.Domain.Models
{
    public class Driver : IBaseClass
    {
        public int Id { get; set; }

        public IdentityPerson Identity { get; set; }

        public ContactInfo Contactinfo { get; set; }

        public DriversLicenseType DriversLicenseType { get; set; }

        public bool InService { get; set; }

        public List<FuelCardDriver> FuelCards { get; set; }

        public List<DriverVehicle> Vehicles { get; set; }

        public List<Appeal> Appeals { get; set; }
    }
}
