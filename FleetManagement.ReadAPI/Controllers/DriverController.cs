﻿using FleetManagement.BLL.Features.Read.DriverManagement.GetAllDriverOverviews;
using FleetManagement.BLL.Features.Read.DriverManagement.GetAppeals;
using FleetManagement.BLL.Features.Read.DriverManagement.GetDriverDetails;
using FleetManagement.BLL.Features.Read.DriverManagement.GetFuelCards;
using FleetManagement.BLL.Features.Read.DriverManagement.GetVehicleInfo;
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
    public class DriverController : Controller
    {
        private readonly IMediator _mediator;

        public DriverController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllDriverOverviews(
          [FromModel] GetAllDriverOverviewsQuery getAllDriverOverviewsQuery,
          CancellationToken cancellationToken)
        {
            var getAllDriverOverviewsQueryResult = await _mediator.Send(getAllDriverOverviewsQuery, cancellationToken);

            return getAllDriverOverviewsQueryResult.ToActionResult();
        }

        [HttpGet("{driverId}/appeals")]
        public async Task<IActionResult> GetAppeals(
         [FromModel] GetAppealsForDriverQuery getAppealsQuery,
         CancellationToken cancellationToken)
        {
            var getAppealsQueryResult = await _mediator.Send(getAppealsQuery, cancellationToken);

            return getAppealsQueryResult.ToActionResult();
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
         [FromModel] GetFuelCardsForDriverQuery getFuelCardsQuery,
         CancellationToken cancellationToken)
        {
            var getAllDriverOverviewsQueryResult = await _mediator.Send(getFuelCardsQuery, cancellationToken);

            return getAllDriverOverviewsQueryResult.ToActionResult();
        }

        [HttpGet("{driverId}/vehicledetails")]
        public async Task<IActionResult> GetVehicleDetails(
         [FromModel] GetVehiclesForDriverQuery getVehicleDetailsQuery,
         CancellationToken cancellationToken)
        {
            var getVehicleDetailsQueryResult = await _mediator.Send(getVehicleDetailsQuery, cancellationToken);

            return getVehicleDetailsQueryResult.ToActionResult();
        }
    }
}
