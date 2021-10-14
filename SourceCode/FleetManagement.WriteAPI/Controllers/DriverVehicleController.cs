using FleetManagement.BLL.Features.Write.DriverVehicleManagement.AddDriverVehicle;
using FleetManagement.BLL.Features.Write.DriverVehicleManagement.UpdateDriverVehicle;
using MediatR;
using MediatR.Cqrs.Execution;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.WriteAPI.Controllers
{
    [ApiController]
    [Route("writeapi/[controller]")]
    public class DriverVehicleController : Controller
    {
        private readonly IMediator _mediator;

        public DriverVehicleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost()]
        public async Task<IActionResult> AddDriverVehicle(
           AddDriverVehicleCommand addDriverVehicleCommand,
           CancellationToken cancellationToken)
        {
            var addDriverVehicleCommandResult = await _mediator.Send(addDriverVehicleCommand, cancellationToken);

            return addDriverVehicleCommandResult.ToActionResult();
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateDriverVehicle(
           UpdateDriverVehicleCommand updateDriverVehicleCommand,
           CancellationToken cancellationToken)
        {
            var updateDriverVehicleCommandResult = await _mediator.Send(updateDriverVehicleCommand, cancellationToken);

            return updateDriverVehicleCommandResult.ToActionResult();
        }
    }
}
