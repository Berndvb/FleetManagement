using FleetManagement.BLL.Services;
using FleetManagement.Domain.Infrastructure.Pagination;
using FleetManagement.Framework.Constants;
using FleetManagement.Framework.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Execution;
using MediatR.Cqrs.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetAppealsPerCar
{
    public class GetAppealsPerCarQueryHandler : QueryHandler<GetAppealsPerCarQuery, GetAppealsPerCarQueryResult>
    {
        private readonly IDriverService _driverService;
        private readonly IVehicleService _vehicleService;

        public GetAppealsPerCarQueryHandler(
            IDriverService driverService,
            IVehicleService vehicleService)
        {
            _driverService = driverService;
            _vehicleService = vehicleService;
        }

        public async override Task<GetAppealsPerCarQueryResult> Handle(
            GetAppealsPerCarQuery request,
            CancellationToken cancellationToken)
        {
            var driverIdError = await _driverService.CheckforIdError(cancellationToken, request.DriverId);
            if (driverIdError != null)
                return BadRequest(driverIdError);

            var vehicleIdError = await _vehicleService.CheckforIdError(cancellationToken, request.VehicleId);
            if (vehicleIdError != null)
                return BadRequest(vehicleIdError);

            var vehicleAppeals = await _driverService.GetAppealsForDriverPerCar(cancellationToken, request.DriverId, request.VehicleId, request.PagingParameters);
            if (vehicleAppeals.Count == 0)
            {
                var warning = new ExecutionWarning("We couldn't find and retrieve any appeal data.", Constants.WarningCodes.NoData);
                return SucceededWithNoData(warning);
            }

            var result = new GetAppealsPerCarQueryResult(vehicleAppeals);
            if (request.PagingParameters != null)
                result.FillPagingInfo((PaginatedList<AppealDto>)vehicleAppeals);

            return result;
        }
    }
}
