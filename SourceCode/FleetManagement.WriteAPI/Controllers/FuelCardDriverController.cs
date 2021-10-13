using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Features.Write.FuelCardDriverManagement.UpdateFuelCardDriver;
using MediatR;
using MediatR.Cqrs;
using MediatR.Cqrs.Execution;
using Microsoft.AspNetCore.Mvc;

namespace FleetManagement.WriteAPI.Controllers
{
    [ApiController]
    [Route("writeapi/[controller]")]
    public class FuelCardDriverController : Controller
    {
        private readonly IMediator _mediator;

        public FuelCardDriverController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("fuelCardDriver/{fuelCardDriverId}")]
        public async Task<IActionResult> UpdateFuelCardDriver(
             [FromModel] UpdateFuelCardDriverCommand updateFuelCardDriverCommand,
             CancellationToken cancellationToken)
        {
            var updateFuelCardDriverCommandResult = await _mediator.Send(updateFuelCardDriverCommand, cancellationToken);

            return updateFuelCardDriverCommandResult.ToActionResult();
        }
    }
}
