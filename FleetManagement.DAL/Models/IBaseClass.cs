using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Domain.Models
{
    public interface IBaseClass
    {
        [Key]
        int Id { get; }
    }
}
