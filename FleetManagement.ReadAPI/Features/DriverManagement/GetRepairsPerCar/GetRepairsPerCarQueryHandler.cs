using FleetManagement.BLL.Services;
using MediatR.Cqrs.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetReparationsPerCar
{
    public class GetRepairsPerCarQueryHandler : QueryHandler<GetRepairsPerCarQuery, GetRepairsPerCarQueryResult>
    {
        private readonly IDriverService _driverService;

        public GetRepairsPerCarQueryHandler(IDriverService driverService)
        {
            _driverService = driverService;
        }

        public async override Task<GetRepairsPerCarQueryResult> Handle(
            GetRepairsPerCarQuery request,
            CancellationToken cancellationToken)
        {
            var vehicleRepairs = await _driverService.GetRepairsForDriverPerCar(int.Parse(request.DriverId), int.Parse(request.VehicleId));

            return new GetRepairsPerCarQueryResult(vehicleRepairs);
        }
    }
}
