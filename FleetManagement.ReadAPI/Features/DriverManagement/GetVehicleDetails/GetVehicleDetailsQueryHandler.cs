using FleetManagement.BLL.Services;
using MediatR.Cqrs.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetVehicleDetails
{
    public class GetVehicleDetailsQueryHandler : QueryHandler<GetVehicleDetailsQuery, GetVehicleDetailsQueryResult>
    {
        private readonly IDriverService _driverService;

        public GetVehicleDetailsQueryHandler(IDriverService driverService)
        {
            _driverService = driverService;
        }

        public async override Task<GetVehicleDetailsQueryResult> Handle(
            GetVehicleDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var vehicleDetails = await _driverService.GetVehiclesForDriver(int.Parse(request.DriverId));

            return new GetVehicleDetailsQueryResult(vehicleDetails);
        }
    }
}
