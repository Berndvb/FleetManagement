using FleetManagement.Framework.Models.Enums;
using System;

namespace FleetManagement.Framework.Models.Dtos.ShowDtos
{
    public class ShowDriverDetails
    {
        public int Id { get; set; }

        public IdentityPersonDto Identity { get; set; }

        public ContactInfoDto Contactinfo { get; set; }

        public DriversLicenseType DriversLicenseType { get; set; }

        public bool InService { get; set; }

        public ShowDriverDetails(
            int id,
            IdentityPersonDto identity,
            ContactInfoDto contactInfo,
            DriversLicenseType driversLicenseType,
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

            public string EmailAdres { get; set; }

            public string GsmNummer { get; set; }

            public string Telefoonnummer { get; set; }

            public AddressDto Address { get; set; }

            public ContactInfoDto(
                int id,
                string emailAdres,
                string gsmNummer,
                string telefoonnummer,
                AddressDto address)
            {
                Id = id;
                EmailAdres = emailAdres;
                GsmNummer = gsmNummer;
                Telefoonnummer = telefoonnummer;
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
