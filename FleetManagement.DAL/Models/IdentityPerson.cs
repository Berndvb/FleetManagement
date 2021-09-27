using System;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Domain.Models
{
    public class IdentityPerson
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public string NationalInsurancenumber { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
