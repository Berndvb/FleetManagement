using FleetManagement.BLL.Features.DriverZone.GetAppealsForDriver;
using FleetManagement.BLL.Features.DriverZone.GetFuelCardsForDriver;
using FleetManagement.BLL.Features.DriverZone.GetVehiclesForDriver;
using FleetManagement.BLL.Services;
using MediatR;
using MediatR.Cqrs;
using MediatR.Cqrs.Execution;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Controllers
{
    [ApiController]
    [Route("readapi/[controller]")]
    public class DriverZoneController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IDriverService _driverService;
        private readonly IGeneralService _generalService;

        public DriverZoneController(
            IMediator mediator, 
            IDriverService driverService,
            IGeneralService generalService)
        {
            _mediator = mediator;
            _driverService = driverService;
            _generalService = generalService;
        }

        //using service-pattern for this endpoint as practice (so no mediatR.Cqrs)
        [HttpGet("driver/{driverId}")]
        public async Task<IActionResult> GetDriverDetails(
         int driverId,
         CancellationToken cancellationToken)
        {
            var validationError = _generalService.IsValidId(driverId);
            if (validationError != null)
                return validationError;

            var driverDetails = await _driverService.GetDriverDetails(driverId, cancellationToken);

            return await _generalService.SingleReturnToActionResult(driverDetails);
        }

        [HttpGet("driver/{DriverId}/appeals")]
        public async Task<IActionResult> GetAppealsForDriver(
         [FromModel] GetAppealsForDriverQuery getAppealsQuery,
         CancellationToken cancellationToken)
        {
            var getAppealsQueryResult = await _mediator.Send(getAppealsQuery, cancellationToken);

            return getAppealsQueryResult.ToActionResult();
        }

        [HttpGet("driver/{DriverId}/fuelcards")]
        public async Task<IActionResult> GetFuelCardsForDriver(
         [FromModel] GetFuelCardsForDriverQuery getFuelCardsQuery,
         CancellationToken cancellationToken)
        {
            var getAllDriverOverviewsQueryResult = await _mediator.Send(getFuelCardsQuery, cancellationToken);

            return getAllDriverOverviewsQueryResult.ToActionResult();
        }

        [HttpGet("driver/{DriverId}/vehicles")]
        public async Task<IActionResult> GetVehiclesForDriver(
         [FromModel] GetVehiclesForDriverQuery getVehicleDetailsQuery,
         CancellationToken cancellationToken)
        {
            var getVehicleDetailsQueryResult = await _mediator.Send(getVehicleDetailsQuery, cancellationToken);

            return getVehicleDetailsQueryResult.ToActionResult();
        }
    }
}
