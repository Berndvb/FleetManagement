using FleetManagement.BLL.Features.Write.FuelCardManagement.UpdateFuelCard;
using MediatR;
using MediatR.Cqrs.Execution;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

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

        [HttpPut()]
        public async Task<IActionResult> UpdateFuelCard(
         UpdateFuelCardCommand updateFuelCardCommand,
         CancellationToken cancellationToken)
        {
            var updateFuelCardCommandResult = await _mediator.Send(updateFuelCardCommand, cancellationToken);

            return updateFuelCardCommandResult.ToActionResult();
        }
    }
}
