using FleetManagement.BLL.Services;
using FleetManagement.Framework.Constants;
using MediatR.Cqrs.Execution;
using MediatR.Cqrs.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Features.VehicleManagement.GetAllVehicles
{
    public class GetAllVehiclesQueryHandler : QueryHandler<GetAllVehiclesQuery, GetAllVehiclesQueryResult>
    {
        private readonly IVehicleService _vehicleService;

        public GetAllVehiclesQueryHandler(
            IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public async override Task<GetAllVehiclesQueryResult> Handle(
            GetAllVehiclesQuery request,
            CancellationToken cancellationToken)
        {
            var vehicles = await _vehicleService.GetAllVehicles(request.PagingParameters);
            if (vehicles.Count == 0)
            {
                var warning = new ExecutionWarning("We couldn't find and retrieve any vehicle data.", Constants.WarningCodes.NoData);
                return SuccesWithNoData(warning);
            }

            return new GetAllVehiclesQueryResult(vehicles);
        }
    }
}
