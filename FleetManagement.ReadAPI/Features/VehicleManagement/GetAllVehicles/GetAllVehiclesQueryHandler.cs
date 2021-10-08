using FleetManagement.BLL.Services;
using FleetManagement.Framework.Constants;
using MediatR.Cqrs.Execution;
using MediatR.Cqrs.Queries;
using System.Linq;
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

        public async override Task<GetAllVehiclesQueryHandler> Handle(
            GetAllVehiclesQuery request,
            CancellationToken cancellationToken)
        {
            var vehicles = await _vehicleService.GetAllVehicles();
            if (vehicles.Count == 0)
            {
                var dataError = new ExecutionError("We couldn't find and retrieve any vehicle data.", Constants.ErrorCodes.DataNotFound);
                return NotFound(dataError);
            }

            return new GetAllVehiclesQueryResult(vehicles);
        }
    }
}
