namespace FleetManagement.BLL.Models.Dtos.ReadDtos
{
    public class GarageDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ContactInfoDto ContactInfo { get; set; }

        public string CompanyNumber { get; set; }

        public string BankaccountNumber { get; set; }

        public GarageDto(
            int id,
            string name,
            ContactInfoDto contactInfo,
            string companyNumber,
            string bankaccountNumber)
        {
            Id = id;
            Name = name;
            ContactInfo = contactInfo;
            CompanyNumber = companyNumber;
            BankaccountNumber = bankaccountNumber;
        }
    }
}

