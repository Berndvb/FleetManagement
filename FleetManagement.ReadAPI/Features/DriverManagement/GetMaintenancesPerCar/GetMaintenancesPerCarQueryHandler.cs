using FleetManagement.BLL.Services;
using MediatR.Cqrs.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetMaintenancesPerCar
{
    public class GetMaintenancesPerCarQueryHandler : QueryHandler<GetMaintenancesPerCarQuery, GetMaintenancesPerCarQueryResult>
    {
        private readonly IDriverService _driverService;

        public GetMaintenancesPerCarQueryHandler(IDriverService driverService)
        {
            _driverService = driverService;
        }

        public async override Task<GetMaintenancesPerCarQueryResult> Handle(
            GetMaintenancesPerCarQuery request,
            CancellationToken cancellationToken)
        {
            var vehicleMaintenances = await _driverService.GetMaintenancesForDriverPerCar(int.Parse(request.DriverId), int.Parse(request.VehicleId));

            return new GetMaintenancesPerCarQueryResult(vehicleMaintenances);
        }
    }
}
