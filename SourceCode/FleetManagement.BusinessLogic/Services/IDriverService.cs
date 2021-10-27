using MediatR.Cqrs.Execution;
using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Models.Dtos.ReadDtos;

namespace FleetManagement.BLL.Services
{
    public interface IDriverService
    {
        Task<DriverDetailsDto> GetDriverDetails(int driverId, CancellationToken cancellationToken);
        Task<ExecutionError> ValidateId(int id, CancellationToken cancellationToken);
    }
}
