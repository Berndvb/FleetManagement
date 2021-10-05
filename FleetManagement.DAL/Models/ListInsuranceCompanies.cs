using FleetManagement.Domain.Interfaces.Models;
namespace FleetManagement.Domain.Models
{
    public class ListInsuranceCompanies : IBaseClass
    {
        public int Id { get; set; }

        public string InsuranceCompanies { get; set; }
    }
}
