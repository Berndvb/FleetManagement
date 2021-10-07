using FleetManagement.WriteAPI.Features.VehicleManagement.UpdateDriverVehicle;
using FleetManagement.WriteAPI.Features.VehicleManagement.UpdateVehicle;
using MediatR;
using MediatR.Cqrs;
using MediatR.Cqrs.Execution;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.WriteAPI.Features.VehicleManagement
{
    [ApiController]
    [Route("writeapi/[controller]")]
    public class VehicleController : Controller
    {
        private readonly IMediator _mediator;

        public VehicleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("update-drivervehicle")]
        public async Task<IActionResult> UpdateDriverVehicle(
           [FromModel] UpdateDriverVehicleCommand updateDriverVehicleCommand,
           CancellationToken cancellationToken)
        {
            var updateDriverVehicleCommandResult = await _mediator.Send(updateDriverVehicleCommand, cancellationToken);

            return updateDriverVehicleCommandResult.ToActionResult();
        }

        [HttpPost("update-driver")]
        public async Task<IActionResult> UpdateFuelCardDriver(
            [FromModel] UpdateVehicleCommand updateVehicleCommand,
            CancellationToken cancellationToken)
        {
            var updateVehicleCommandResult = await _mediator.Send(updateVehicleCommand, cancellationToken);

            return updateVehicleCommandResult.ToActionResult();
        }
    }
}
