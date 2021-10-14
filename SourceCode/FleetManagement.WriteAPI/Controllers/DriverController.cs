using FleetManagement.BLL.Features.Write.DriverManagement.AddDriver;
using FleetManagement.BLL.Features.Write.DriverManagement.RemoveDriverById;
using FleetManagement.BLL.Features.Write.DriverManagement.UpdateDriver;
using MediatR;
using MediatR.Cqrs;
using MediatR.Cqrs.Execution;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

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

        [HttpDelete("{driverId}")]
        public async Task<IActionResult> RemoveDriverById(
         [FromModel] RemoveDriverByIdCommand removeDriverByIdCommand,
         CancellationToken cancellationToken)
        {
            var removeDriverByIdCommandResult = await _mediator.Send(removeDriverByIdCommand, cancellationToken);

            return removeDriverByIdCommandResult.ToActionResult();
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateDriver(
         UpdateDriverCommand updateDriverCommand,
         CancellationToken cancellationToken)
        {
            var updateDriverCommandResult = await _mediator.Send(updateDriverCommand, cancellationToken);

            return updateDriverCommandResult.ToActionResult();
        }
    }
}
