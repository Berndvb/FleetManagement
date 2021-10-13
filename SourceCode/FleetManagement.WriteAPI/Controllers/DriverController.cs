using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Features.Write.DriverManagement.AddDriver;
using FleetManagement.BLL.Features.Write.DriverManagement.RemoveDrives;
using FleetManagement.BLL.Features.Write.DriverManagement.UpdateDriver;
using MediatR;
using MediatR.Cqrs;
using MediatR.Cqrs.Execution;
using Microsoft.AspNetCore.Mvc;

namespace FleetManagement.WriteAPI.Controllers
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

        [HttpPost()]
        public async Task<IActionResult> AddDriver(
           AddDriverCommand addDriverCommand,
           CancellationToken cancellationToken)
        {
            var addDriverCommandResult = await _mediator.Send(addDriverCommand, cancellationToken);

            return addDriverCommandResult.ToActionResult();
        }

        [HttpPost("remove-drivers")]
        public async Task<IActionResult> RemoveDriver(
           RemoveDrivesCommand removeDriverCommand,
           CancellationToken cancellationToken)
        {
            var removeDriverCommandResult = await _mediator.Send(removeDriverCommand, cancellationToken);

            return removeDriverCommandResult.ToActionResult();
        }

        [HttpDelete("{driverId}")]
        public async Task<IActionResult> RemoveDriverById(
          [FromModel] RemoveDrivesCommand removeDriverCommand,
          CancellationToken cancellationToken)
        {
            var removeDriverCommandResult = await _mediator.Send(removeDriverCommand, cancellationToken);

            return removeDriverCommandResult.ToActionResult();
        }

        [HttpPut("{driverId}")]
        public async Task<IActionResult> UpdateDriver(
           UpdateDriverCommand updateDriverCommand,
           CancellationToken cancellationToken)
        {
            var updateDriverCommandResult = await _mediator.Send(updateDriverCommand, cancellationToken);

            return updateDriverCommandResult.ToActionResult();
        }
    }
}
