using System;

namespace FleetManagement.Framework.Models.Dtos.WriteDtos
{
    public class AddIdentityPersonDto
    {
        public string Name { get; set; }

        public string FirstName { get; set; }

        public string NationalInsuranceNumber { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
