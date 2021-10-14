using System;

namespace FleetManagement.BLL.Models.Dtos.ReadDtos
{
    public class IdentityPersonDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public string NationalInsuranceNumber { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
