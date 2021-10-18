using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Domain.Interfaces.Models
{
    public interface IBaseClass
    {
        [Key]
        int Id { get; }
    }
}
