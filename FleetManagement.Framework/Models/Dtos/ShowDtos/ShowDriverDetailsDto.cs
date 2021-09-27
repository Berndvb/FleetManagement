using FleetManagement.Framework.Models.Enums;
using System;

namespace FleetManagement.Framework.Models.Dtos.ShowDtos
{
    public class ShowDriverDetails
    {
        public int Id { get; set; }

        public IdentityPersonDto Identity { get; set; }

        public ContactInfoDto Contactinfo { get; set; }

        public EDriversLicenseType DriversLicenseType { get; set; }

        public bool InService { get; set; }

        public ShowDriverDetails()
        {

        }

        public class ContactInfoDto
        {
            public string Id { get; set; }

            public string EmailAdres { get; set; }

            public string GsmNummer { get; set; }

            public string Telefoonnummer { get; set; }

            public AddressDto Adres { get; set; }

            public ContactInfoDto(
                string id,
                string emailAdres,
                string gsmNummer,
                string telefoonnummer,
                AddressDto adres)
            {
                Id = id;
                EmailAdres = emailAdres;
                GsmNummer = gsmNummer;
                Telefoonnummer = telefoonnummer;
                Adres = adres;
            }
        }

        public class IdentityPersonDto
        {
            public string Id { get; set; }

            public string Name { get; set; }

            public string FirstName { get; set; }

            public string NationalInsurancenumber { get; set; }

            public DateTime DateOfBirth { get; set; }

            public IdentityPersonDto(
                string id,
                string name,
                string firstName,
                string nationalInsuranceNumber,
                DateTime geboortedatum)
            {
                Id = id;
                Name = name;
                FirstName = firstName;
                NationalInsurancenumber = nationalInsuranceNumber;
                DateOfBirth = geboortedatum;
            }
        }

       

    }
}
