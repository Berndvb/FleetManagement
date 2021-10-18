using System;

namespace FleetManagement.Domain.Models
{
    public class IdentityPerson : IBaseClass
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string FirstName { get; private set; }

        public string NationalInsuranceNumber { get; private set; }

        public DateTime DateOfBirth { get; private set; }
    }
}
