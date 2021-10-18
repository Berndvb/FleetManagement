using FleetManagement.Framework.Models.Enums;
using System.Collections.Generic;

namespace FleetManagement.Domain.Models
{
    public class Driver : IBaseClass
    {
        public int Id { get; private set; }

        public IdentityPerson Identity { get; private set; }

        public ContactInfo Contactinfo { get; private set; }

        public DriversLicenseType DriversLicenseType { get; private set; }

        public bool InService { get; private set; }

        public List<FuelCardDriver> FuelCards { get; private set; }

        public List<DriverVehicle> DriverVehicles { get; private set; }

        public List<Appeal> Appeals { get; private set; }

        public void ChangeContactInfoForDriver(
            string emailAddress,
            string phoneNumber,
            string street,
            string streetNumber,
            string city,
            string postcode)
        {
            Contactinfo.EmailAddress = emailAddress;
            Contactinfo.PhoneNumber = phoneNumber;
            Contactinfo.Address.Street = street;
            Contactinfo.Address.StreetNumber = streetNumber;
            Contactinfo.Address.City = city;
            Contactinfo.Address.Postcode = postcode;
        }
    }
}
