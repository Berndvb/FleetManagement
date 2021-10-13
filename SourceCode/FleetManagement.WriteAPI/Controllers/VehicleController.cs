using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Features.Write.DriverVehicleManagement.UpdateDriverVehicle;
using FleetManagement.BLL.Features.Write.VehicleManagement.UpdateVehicle;
using MediatR;
using MediatR.Cqrs;
using MediatR.Cqrs.Execution;
using Microsoft.AspNetCore.Mvc;

namespace FleetManagement.WriteAPI.Controllers
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

        [HttpPut("driverVehicle/{driverVehicleId}")]
        public async Task<IActionResult> UpdateDriverVehicle(
           [FromModel] UpdateDriverVehicleCommand updateDriverVehicleCommand,
           CancellationToken cancellationToken)
        {
            var updateDriverVehicleCommandResult = await _mediator.Send(updateDriverVehicleCommand, cancellationToken);

            return updateDriverVehicleCommandResult.ToActionResult();
        }

        [HttpPut("{vehicleId}")]
        public async Task<IActionResult> UpdateVehicle(
            [FromModel] UpdateVehicleCommand updateVehicleCommand,
            CancellationToken cancellationToken)
        {
            var updateVehicleCommandResult = await _mediator.Send(updateVehicleCommand, cancellationToken);

            return updateVehicleCommandResult.ToActionResult();
        }
    }
}
