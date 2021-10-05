using FleetManagement.BLL.Services;
using MediatR.Cqrs.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetAppealsPerCar
{
    public class GetAppealsPerCarQueryHandler : QueryHandler<GetAppealsPerCarQuery, GetAppealsPerCarQueryResult>
    {
        private readonly IDriverService _driverService;

        public GetAppealsPerCarQueryHandler(
            IDriverService driverService)
        {
            _driverService = driverService;
        }

        public async override Task<GetAppealsPerCarQueryResult> Handle(
            GetAppealsPerCarQuery request,
            CancellationToken cancellationToken)
        {

            var vehicleAppeals = await _driverService.GetAppealsForDriverPerCar(int.Parse(request.DriverId), int.Parse(request.VehicleId));

            return new GetAppealsPerCarQueryResult(vehicleAppeals);
        }
    }
}
