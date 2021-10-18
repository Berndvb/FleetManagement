using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.BLL.Services;
using FleetManagement.Domain.Infrastructure.Pagination;
using FleetManagement.Framework.Constants;
using MediatR.Cqrs.Execution;
using MediatR.Cqrs.Queries;

namespace FleetManagement.BLL.Features.Read.DriverManagement.GetVehicleInfo
{
    public class GetVehiclesForDriverQueryHandler : QueryHandler<GetVehiclesForDriverQuery, GetVehiclesForDriverQueryResult>
    {
        private readonly IDriverService _driverService;

        public GetVehiclesForDriverQueryHandler(
            IDriverService driverService)
        {
            _driverService = driverService;
        }

        public async override Task<GetVehiclesForDriverQueryResult> Handle(
            GetVehiclesForDriverQuery request,
            CancellationToken cancellationToken)
        {
            var driverIdError = await _driverService.ValidateId(cancellationToken, request.DriverId);
            if (driverIdError != null)
                return BadRequest(driverIdError);

            var vehicles = await _driverService.GetVehiclesForDriver(cancellationToken, request.DriverId, request.PagingParameters);
            if (vehicles.Count == 0)
            {
                var warning = new ExecutionWarning("We couldn't find and retrieve any vehicle data.", Constants.WarningCodes.NoData);
                return SucceededWithNoData(warning);
            }

            var result = new GetVehiclesForDriverQueryResult(vehicles);
            if (request.PagingParameters != null)
                result.FillPagingInfo((PaginatedList<VehicleDetailsDto>)vehicles);

            return result;
        }
    }
}
