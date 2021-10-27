using System;

namespace FleetManagement.Domain.Models
{
    public class IdentityPerson : IBaseClass
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public string NationalInsuranceNumber { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
