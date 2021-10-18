using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.BLL.Models.Dtos.WriteDtos;
using System.Threading;
using System.Threading.Tasks;
using MediatR.Cqrs.Execution;

namespace FleetManagement.BLL.Services
{
    public interface IFuelCardDriverService
    {
        Task UpdateFuelCardDriver(CancellationToken cancellationToken, FuelCardDriverDto fuelCardDriverDto, int fuelCardDriverId);
        Task AddFuelCardDriver(CancellationToken cancellationToken, AddFuelCardDriverDto fuelCardDriverDto);
        Task<ExecutionError> HasOtherActiveFuelCardDrivers(CancellationToken cancellationToken, int fuelCardId, int driverId);
    }
}
