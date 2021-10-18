using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.BLL.Services;
using FleetManagement.Domain.Infrastructure.Pagination;
using FleetManagement.Framework.Constants;
using MediatR.Cqrs.Execution;
using MediatR.Cqrs.Queries;

namespace FleetManagement.BLL.Features.Read.VehicleManagement.GetAllVehicles
{
    public class GetVehiclesQueryHandler : QueryHandler<GetVehiclesQuery, GetVehiclesQueryResult>
    {
        private readonly IVehicleService _vehicleService;

        public GetVehiclesQueryHandler(
            IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public async override Task<GetVehiclesQueryResult> Handle(
            GetVehiclesQuery request,
            CancellationToken cancellationToken)
        {
            var vehicles = await _vehicleService.GetAllVehicles(cancellationToken, request.PagingParameters);
            if (vehicles.Count == 0)
            {
                var warning = new ExecutionWarning("We couldn't find and retrieve any vehicle data.", Constants.WarningCodes.NoData);
                return SucceededWithNoData(warning);
            }

            var result = new GetVehiclesQueryResult(vehicles);
            if (request.PagingParameters != null)
                result.FillPagingInfo((PaginatedList<VehicleDetailsDto>)vehicles);

            return result;
        }
    }
}
