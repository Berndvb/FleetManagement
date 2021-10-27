using MediatR.Cqrs.Execution;
using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using Microsoft.AspNetCore.Mvc;

namespace FleetManagement.BLL.Services
{
    public interface IDriverService
    {
        Task<IActionResult> GetValidDriverDetails(int driverId, CancellationToken cancellationToken);
        Task<ExecutionError> ValidateDriverId(int id, CancellationToken cancellationToken);
    }
}
