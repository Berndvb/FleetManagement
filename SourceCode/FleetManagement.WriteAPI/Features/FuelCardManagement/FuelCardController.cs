using FleetManagement.WriteAPI.Features.FuelCardManagement.UpdateFuelCard;
using FleetManagement.WriteAPI.Features.FuelCardManagement.UpdateFuelCardDriver;
using MediatR;
using MediatR.Cqrs;
using MediatR.Cqrs.Execution;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.WriteAPI.Features.FuelCardManagement
{
    [ApiController]
    [Route("writeapi/[controller]")]
    public class FuelCardController : Controller
    {
        private readonly IMediator _mediator;

        public FuelCardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("update-fuelcard/{fuelCardId}")]
        public async Task<IActionResult> UpdateFuelCard(
            [FromModel]UpdateFuelCardCommand updateFuelCardCommand,
            CancellationToken cancellationToken)
        {
            var updateFuelCardCommandResult = await _mediator.Send(updateFuelCardCommand, cancellationToken);

            return updateFuelCardCommandResult.ToActionResult();
        }

        [HttpPut("update-fuelcarddriver/{fuelCardDriverId}")]
        public async Task<IActionResult> UpdateFuelCardDriver(
             [FromModel] UpdateFuelCardDriverCommand updateFuelCardDriverCommand,
             CancellationToken cancellationToken)
        {
            var updateFuelCardDriverCommandResult = await _mediator.Send(updateFuelCardDriverCommand, cancellationToken);

            return updateFuelCardDriverCommandResult.ToActionResult();
        }
    }
}
