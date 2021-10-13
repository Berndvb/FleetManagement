using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.BLL.Services;
using FleetManagement.Domain.Infrastructure.Pagination;
using FleetManagement.Framework.Constants;
using MediatR.Cqrs.Execution;
using MediatR.Cqrs.Queries;

namespace FleetManagement.BLL.Features.Read.DriverManagement.GetMaintenancesPerCar
{
    public class GetMaintenancesPerCarQueryHandler : QueryHandler<GetMaintenancesPerCarQuery, GetMaintenancesPerCarQueryResult>
    {
        private readonly IDriverService _driverService;
        private readonly IVehicleService _vehicleService;

        public GetMaintenancesPerCarQueryHandler(
            IDriverService driverService,
            IVehicleService vehicleService)
        {
            _driverService = driverService;
            _vehicleService = vehicleService;
        }

        public async override Task<GetMaintenancesPerCarQueryResult> Handle(
            GetMaintenancesPerCarQuery request,
            CancellationToken cancellationToken)
        {
            var driverIdError = await _driverService.CheckforIdError(cancellationToken, request.DriverId);
            if (driverIdError != null)
                return BadRequest(driverIdError);

            var vehicleIdError = await _vehicleService.CheckforIdError(cancellationToken, request.VehicleId);
            if (vehicleIdError != null)
                return BadRequest(vehicleIdError);

            var vehicleMaintenances = await _driverService.GetMaintenancesForDriverPerCar(cancellationToken, request.DriverId, request.VehicleId, request.PagingParameters);
            if (vehicleMaintenances.Count == 0)
            {
                var warning = new ExecutionWarning("We couldn't find and retrieve any maintenance data.", Constants.WarningCodes.NoData);
                return SucceededWithNoData(warning);
            }

            var result = new GetMaintenancesPerCarQueryResult(vehicleMaintenances);
            if (request.PagingParameters != null)
                result.FillPagingInfo((PaginatedList<MaintenanceDto>)vehicleMaintenances);

            return result;
        }
    }
}
