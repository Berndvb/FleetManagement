using FleetManagement.Framework.Models.Enums;
using System.Collections.Generic;

namespace FleetManagement.Domain.Models
{
    public class ReadDriver
    {
        public int Id { get; set; } // guid

        public IdentityPerson Identity { get; set; }

        public ContactInfo Contactinfo { get; set; }

        public EDriversLicenseType DriversLicenseType { get; set; } // No prefixes + flags

        public bool InService { get; set; }

        public List<FuelCardDriver> Fuelcards { get; set; }

        public List<DriverVehicle> Vehicles { get; set; }

        public List<ReadAppeal> Appeals { get; set; }
    }
}
