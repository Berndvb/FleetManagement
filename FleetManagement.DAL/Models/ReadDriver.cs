using FleetManagement.Framework.Models.Enums;
using System.Collections.Generic;

namespace FleetManagement.Domain.Models
{
    public class ReadDriver
    {
        public string Id { get; set; }

        public IdentityPerson Identity { get; set; }

        public ContactInfo Contactinfo { get; set; }

        public EDriversLicenseType DriversLicenseType { get; set; }

        public bool InService { get; set; }

        public List<FuelCardDriver> Fuelcards { get; set; }

        public List<DriverVehicle> Vehicles { get; set; }

        public List<ReadAppeal> Appeals { get; set; }
    }
}
