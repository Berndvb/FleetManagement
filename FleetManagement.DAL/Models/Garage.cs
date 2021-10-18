namespace FleetManagement.Domain.Models
{
    public class Garage : IBaseClass
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public ContactInfo ContactInfo { get; private set; }

        public string CompanyNumber { get; private set; }

        public string BankaccountNumber { get; private set; }
    }
}
