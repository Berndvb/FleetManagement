using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Features.Read.DriverManagement.GetAllDriverOverviews;
using FleetManagement.BLL.Features.Read.DriverManagement.GetAppeals;
using FleetManagement.BLL.Features.Read.DriverManagement.GetAppealsPerCar;
using FleetManagement.BLL.Features.Read.DriverManagement.GetDriverDetails;
using FleetManagement.BLL.Features.Read.DriverManagement.GetFuelCards;
using FleetManagement.BLL.Features.Read.DriverManagement.GetMaintenancesPerCar;
using FleetManagement.BLL.Features.Read.DriverManagement.GetRepairsPerCar;
using FleetManagement.BLL.Features.Read.DriverManagement.GetVehicleInfo;
using MediatR;
using MediatR.Cqrs;
using MediatR.Cqrs.Execution;
using Microsoft.AspNetCore.Mvc;

namespace FleetManagement.ReadAPI.Controllers
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

        [HttpGet("driveroverviews")]
        public async Task<IActionResult> GetAllDriverOverviews(
          [FromModel] GetAllDriverOverviewsQuery getAllDriverOverviewsQuery,
          CancellationToken cancellationToken)
        {
            var getAllDriverOverviewsQueryResult = await _mediator.Send(getAllDriverOverviewsQuery, cancellationToken);

            return getAllDriverOverviewsQueryResult.ToActionResult();
        }

        [HttpGet("{driverId}/appeals")]
        public async Task<IActionResult> GetAppeals(
         [FromModel] GetAppealsQuery getAppealsQuery,
         CancellationToken cancellationToken)
        {
            var getAppealsQueryResult = await _mediator.Send(getAppealsQuery, cancellationToken);

            return getAppealsQueryResult.ToActionResult();
        }

        [HttpGet("{driverId}/appeals-per-car/{vehicleId}")]
        public async Task<IActionResult> GetAppealsPerCar(
         [FromModel] GetAppealsPerCarQuery getAppealsPerCarQuery,
         CancellationToken cancellationToken)
        {
            var getAppealsPerCarQueryResult = await _mediator.Send(getAppealsPerCarQuery, cancellationToken);

            return getAppealsPerCarQueryResult.ToActionResult();
        }

        [HttpGet("{driverId}/driverdetails")]
        public async Task<IActionResult> GetDriverDetails(
         [FromModel] GetDriverDetailsQuery getDriverDetailsQuery,
         CancellationToken cancellationToken)
        {
            var getDriverDetailsQueryResult = await _mediator.Send(getDriverDetailsQuery, cancellationToken);

            return getDriverDetailsQueryResult.ToActionResult();
        }

        [HttpGet("{driverId}/fuelcards")]
        public async Task<IActionResult> GetFuelCards(
         [FromModel] GetFuelCardsQuery getFuelCardsQuery,
         CancellationToken cancellationToken)
        {
            var getAllDriverOverviewsQueryResult = await _mediator.Send(getFuelCardsQuery, cancellationToken);

            return getAllDriverOverviewsQueryResult.ToActionResult();
        }

        [HttpGet("{driverId}/maintenances-per-car/{vehicleId}")]
        public async Task<IActionResult> GetMaintenancesPerCar(
         [FromModel] GetMaintenancesPerCarQuery getMaintenancesPerCarQuery,
         CancellationToken cancellationToken)
        {
            var getMaintenancesPerCarQueryResult = await _mediator.Send(getMaintenancesPerCarQuery, cancellationToken);

            return getMaintenancesPerCarQueryResult.ToActionResult();
        }

        [HttpGet("{driverId}/repairs-per-car/{vehicleId}")]
        public async Task<IActionResult> GetRepairsPerCar(
         [FromModel] GetRepairsPerCarQuery getRepairsPerCarQuery,
         CancellationToken cancellationToken)
        {
            var getRepairsPerCarQueryResult = await _mediator.Send(getRepairsPerCarQuery, cancellationToken);

            return getRepairsPerCarQueryResult.ToActionResult();
        }

        [HttpGet("{driverId}/vehicledetails")]
        public async Task<IActionResult> GetVehicleDetails(
         [FromModel] GetVehicleInfoQuery getVehicleDetailsQuery,
         CancellationToken cancellationToken)
        {
            var getVehicleDetailsQueryResult = await _mediator.Send(getVehicleDetailsQuery, cancellationToken);

            return getVehicleDetailsQueryResult.ToActionResult();
        }
    }
}
