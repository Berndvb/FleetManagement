using FleetManagement.Domain.Interfaces;
using FleetManagement.Domain.Models;
using FleetManagement.EFCore.Infrastructure;

namespace FleetManager.EFCore.Repositories
{
    public class OnderhoudsbeurtRepository : GenericRepository<ReadOnderhoudsbeurt>, IOnderhoudsbeurtRepository
    {
        public OnderhoudsbeurtRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
