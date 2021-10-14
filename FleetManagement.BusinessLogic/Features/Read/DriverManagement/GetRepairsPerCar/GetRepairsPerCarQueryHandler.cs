using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.BLL.Services;
using FleetManagement.Domain.Infrastructure.Pagination;
using FleetManagement.Framework.Constants;
using MediatR.Cqrs.Execution;
using MediatR.Cqrs.Queries;

namespace FleetManagement.BLL.Features.Read.DriverManagement.GetRepairsPerCar
{
    public class GetRepairsPerCarQueryHandler : QueryHandler<GetRepairsPerCarQuery, GetRepairsPerCarQueryResult>
    {
        private readonly IDriverService _driverService;
        private readonly IVehicleService _vehicleService;

        public GetRepairsPerCarQueryHandler(
            IDriverService driverService,
            IVehicleService vehicleService)
        {
            _driverService = driverService;
            _vehicleService = vehicleService;
        }

        public async override Task<GetRepairsPerCarQueryResult> Handle(
            GetRepairsPerCarQuery request,
            CancellationToken cancellationToken)
        {
            var driverIdError = await _driverService.ValidateId(cancellationToken, request.DriverId);
            if (driverIdError != null)
                return BadRequest(driverIdError);

            var vehicleIdError = await _vehicleService.CheckforIdError(cancellationToken, request.VehicleId);
            if (vehicleIdError != null)
                return BadRequest(vehicleIdError);

            var vehicleRepairs = await _driverService.GetRepairsForDriverPerCar(cancellationToken, request.DriverId, request.VehicleId, request.PagingParameters);
            if (vehicleRepairs.Count == 0)
            {
                var warning = new ExecutionWarning("We couldn't find and retrieve any repair data.", Constants.WarningCodes.NoData);
                return SucceededWithNoData(warning);
            }

            var result = new GetRepairsPerCarQueryResult(vehicleRepairs);
            if (request.PagingParameters != null)
                result.FillPagingInfo((PaginatedList<RepareDto>)vehicleRepairs);

            return result;
        }
    }
}
