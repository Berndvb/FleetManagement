using MediatR.Cqrs.Execution;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Services
{
    public interface IDriverService
    {
        Task<ExecutionError> ValidateId(CancellationToken cancellationToken, int id);
    }
}
