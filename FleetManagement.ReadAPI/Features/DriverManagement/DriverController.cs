using FleetManagement.ReadAPI.Features.DriverManagement.GetActiveDriverOverviews;
using FleetManagement.ReadAPI.Features.DriverManagement.GetAllDriverOverviews;
using FleetManagement.ReadAPI.Features.DriverManagement.GetAppealsPerCar;
using FleetManagement.ReadAPI.Features.DriverManagement.GetDriverDetails;
using FleetManagement.ReadAPI.Features.DriverManagement.GetFuelCardDetails;
using FleetManagement.ReadAPI.Features.DriverManagement.GetMaintenancesPerCar;
using FleetManagement.ReadAPI.Features.DriverManagement.GetReparationsPerCar;
using FleetManagement.ReadAPI.Features.DriverManagement.GetTotalAppeals;
using FleetManagement.ReadAPI.Features.DriverManagement.GetVehicleDetails;
using MediatR;
using MediatR.Cqrs;
using MediatR.Cqrs.Execution;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Features.Driver
{
    [ApiController]
    [Route("readapi/[controller]")]
    public class DriverController : Controller
    {
        private readonly IMediator _mediator;

        public DriverController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("active-driveroverviews")]
        [ProducesResponseType(typeof(GetActiveDriverOverviewsQuery), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetActiveDriverOverviews(
            [FromModel] GetActiveDriverOverviewsQuery getActiveDriverOverviewsQuery,
            CancellationToken cancellationToken)
        {
            var GetActiveDriverOverviewsQueryResult = await _mediator.Send(getActiveDriverOverviewsQuery, cancellationToken);

            return GetActiveDriverOverviewsQueryResult.ToActionResult();
        }

        [HttpGet("all-driveroverviews/")]
        public async Task<IActionResult> GetAllDriverOverviews(
          [FromModel] GetAllDriverOverviewsQuery getAllDriverOverviewsQuery,
          CancellationToken cancellationToken)
        {
            var getAllDriverOverviewsQueryResult = await _mediator.Send(getAllDriverOverviewsQuery, cancellationToken);

            return getAllDriverOverviewsQueryResult.ToActionResult();
        }

        [HttpGet("appeals/{driverId}")]
        public async Task<IActionResult> GetAllAppeals(
         [FromModel] GetAllAppealsQuery getAllAppealsQuery,
         CancellationToken cancellationToken)
        {
            var getAllAppealsQueryResult = await _mediator.Send(getAllAppealsQuery, cancellationToken);

            return getAllAppealsQueryResult.ToActionResult();
        }

        [HttpGet("appeals-per-car/{driverId}/{vehicleId}")]
        public async Task<IActionResult> GetAppealsPerCar(
         [FromModel] GetAppealsPerCarQuery getAppealsPerCarQuery,
         CancellationToken cancellationToken)
        {
            var getAppealsPerCarQueryResult = await _mediator.Send(getAppealsPerCarQuery, cancellationToken);

            return getAppealsPerCarQueryResult.ToActionResult();
        }

        [HttpGet("driverdetails/{driverId}")]
        public async Task<IActionResult> GetDriverDetails(
         [FromModel] GetDriverDetailsQuery getDriverDetailsQuery,
         CancellationToken cancellationToken)
        {
            var getDriverDetailsQueryResult = await _mediator.Send(getDriverDetailsQuery, cancellationToken);

            return getDriverDetailsQueryResult.ToActionResult();
        }

        [HttpGet("fuelcards/{driverId}")]
        public async Task<IActionResult> GetFuelCards(
         [FromModel] GetFuelCardsQuery getFuelCardsQuery,
         CancellationToken cancellationToken)
        {
            var getAllDriverOverviewsQueryResult = await _mediator.Send(getFuelCardsQuery, cancellationToken);

            return getAllDriverOverviewsQueryResult.ToActionResult();
        }

        [HttpGet("maintenances-per-car/{driverId}/{vehicleId}")]
        public async Task<IActionResult> GetMaintenancesPerCar(
         [FromModel] GetMaintenancesPerCarQuery getMaintenancesPerCarQuery,
         CancellationToken cancellationToken)
        {
            var getMaintenancesPerCarQueryResult = await _mediator.Send(getMaintenancesPerCarQuery, cancellationToken);

            return getMaintenancesPerCarQueryResult.ToActionResult();
        }

        [HttpGet("repairs-per-car/{driverId}/{vehicleId}")]
        public async Task<IActionResult> GetRepairssPerCar(
         [FromModel] GetRepairsPerCarQuery getRepairsPerCarQuery,
         CancellationToken cancellationToken)
        {
            var getRepairsPerCarQueryResult = await _mediator.Send(getRepairsPerCarQuery, cancellationToken);

            return getRepairsPerCarQueryResult.ToActionResult();
        }

        [HttpGet("vehicledetails/{driverId}")]
        public async Task<IActionResult> GetVehicleDetails(
         [FromModel] GetVehicleDetailsQuery getVehicleDetailsQuery,
         CancellationToken cancellationToken)
        {
            var getVehicleDetailsQueryResult = await _mediator.Send(getVehicleDetailsQuery, cancellationToken);

            return getVehicleDetailsQueryResult.ToActionResult();
        }
    }
}
