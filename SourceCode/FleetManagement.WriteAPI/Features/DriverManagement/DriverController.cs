using FleetManagement.WriteAPI.Features.DriverManagement.AddDriver;
using MediatR;
using MediatR.Cqrs;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using MediatR.Cqrs.Execution;
using FleetManagement.WriteAPI.Features.DriverManagement.RemoveDriver;
using FleetManagement.WriteAPI.Features.DriverManagement.UpdateDriver;

namespace FleetManagement.WriteAPI.Features.DriverManagement
{
    [ApiController]
    [Route("writeapi/[controller]")]
    public class DriverController : Controller
    {
        private readonly IMediator _mediator;

        public DriverController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddDriver(
           AddDriverCommand addDriverCommand,
           CancellationToken cancellationToken)
        {
            var addDriverCommandResult = await _mediator.Send(addDriverCommand, cancellationToken);

            return addDriverCommandResult.ToActionResult();
        }

        [HttpPost("remove-driver")]
        public async Task<IActionResult> RemoveDriver(
           RemoveDriverCommand removeDriverCommand,
           CancellationToken cancellationToken)
        {
            var removeDriverCommandResult = await _mediator.Send(removeDriverCommand, cancellationToken);

            return removeDriverCommandResult.ToActionResult();
        }

        [HttpDelete("remove-driver/{driverId}")]
        public async Task<IActionResult> RemoveDriverById(
          [FromModel] RemoveDriverCommand removeDriverCommand,
          CancellationToken cancellationToken)
        {
            var removeDriverCommandResult = await _mediator.Send(removeDriverCommand, cancellationToken);

            return removeDriverCommandResult.ToActionResult();
        }

        [HttpPost("update-driver")]
        public async Task<IActionResult> UpdateDriver(
           UpdateDriverCommand updateDriverCommand,
           CancellationToken cancellationToken)
        {
            var updateDriverCommandResult = await _mediator.Send(updateDriverCommand, cancellationToken);

            return updateDriverCommandResult.ToActionResult();
        }
    }
}
