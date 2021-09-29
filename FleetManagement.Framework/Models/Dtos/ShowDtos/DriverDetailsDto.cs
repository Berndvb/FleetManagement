using FleetManagement.Framework.Models.Enums;
using System;

namespace FleetManagement.Framework.Models.Dtos.ShowDtos
{
    public class DriverDetailsDto
    {
        public int Id { get; set; }

        public IdentityPersonDto Identity { get; set; }

        public ContactInfoDto Contactinfo { get; set; }

        public DriversLicenseTypes DriversLicenseType { get; set; }

        public bool InService { get; set; }

        public DriverDetailsDto(
            int id,
            IdentityPersonDto identity,
            ContactInfoDto contactInfo,
            DriversLicenseTypes driversLicenseType,
            bool inService)
        {
            Id = id;
            Identity = identity;
            Contactinfo = contactInfo;
            DriversLicenseType = driversLicenseType;
            InService = inService;
        }

        public class ContactInfoDto
        {
            public int Id { get; set; }

            public string EmailAddress { get; set; }

            public string CellPhoneNumber { get; set; }

            public string TelephoneNumber { get; set; }

            public AddressDto Address { get; set; }

            public ContactInfoDto(
                int id,
                string emailAddress,
                string cellPhoneNumber,
                string telephoneNumber,
                AddressDto address)
            {
                Id = id;
                EmailAddress = emailAddress;
                CellPhoneNumber = cellPhoneNumber;
                TelephoneNumber = telephoneNumber;
                Address = address;
            }

            public class AddressDto
            {
                public int Id { get; set; }

                public string Street { get; set; }

                public string City { get; set; }

                public string Postcode { get; set; }

                public AddressDto(
                    int id,
                    string street,
                    string city,
                    string postcode)
                {
                    Id = id;
                    Street = street;
                    City = city;
                    Postcode = postcode;
                }
            }
        }

        public class IdentityPersonDto
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string FirstName { get; set; }

            public string NationalInsuranceNumber { get; set; }

            public DateTime DateOfBirth { get; set; }

            public IdentityPersonDto(
                int id,
                string name,
                string firstName,
                string nationalInsuranceNumber,
                DateTime dateOfBirth)
            {
                Id = id;
                Name = name;
                FirstName = firstName;
                NationalInsuranceNumber = nationalInsuranceNumber;
                DateOfBirth = dateOfBirth;
            }
        }

       

    }
}
