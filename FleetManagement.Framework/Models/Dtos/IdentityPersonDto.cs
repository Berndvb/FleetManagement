using System;

namespace FleetManagement.Framework.Models.Dtos
{
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

        public IdentityPersonDto()
        {
        }
    }
}
