using FleetManagement.BLL.Features.Write.VehicleManagement.AddVehicle;
using FleetManagement.BLL.Features.Write.VehicleManagement.UpdateVehicle;
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
    public class VehicleController : Controller
    {
        private readonly IMediator _mediator;

        public VehicleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateVehicle(
            UpdateVehicleCommand updateVehicleCommand,
            CancellationToken cancellationToken)
        {
            var updateVehicleCommandResult = await _mediator.Send(updateVehicleCommand, cancellationToken);

            return updateVehicleCommandResult.ToActionResult();
        }

        [HttpPost()]
        public async Task<IActionResult> AddVehicle(
           AddVehicleCommand addVehicleCommand,
           CancellationToken cancellationToken)
        {
            var addVehicleCommandResult = await _mediator.Send(addVehicleCommand, cancellationToken);

            return addVehicleCommandResult.ToActionResult();
        }
    }
}
