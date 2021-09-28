using FleetManagement.Domain.Interfaces;

namespace FleetManagement.Domain.Models
{
    public class Garage : IBaseClass
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ContactInfo ContactInfo { get; set; }

        public string CompanyNumber { get; set; }

        public string BankaccountNumber { get; set; }
    }
}
