using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Features.Write.FuelCardManagement.UpdateFuelCard;
using MediatR;
using MediatR.Cqrs;
using MediatR.Cqrs.Execution;
using Microsoft.AspNetCore.Mvc;

namespace FleetManagement.WriteAPI.Controllers
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

        [HttpPut("{fuelCardId}")]
        public async Task<IActionResult> UpdateFuelCard(
            [FromModel]UpdateFuelCardCommand updateFuelCardCommand,
            CancellationToken cancellationToken)
        {
            var updateFuelCardCommandResult = await _mediator.Send(updateFuelCardCommand, cancellationToken);

            return updateFuelCardCommandResult.ToActionResult();
        }
    }
}
