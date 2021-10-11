using FleetManagement.ReadAPI.Features.VehicleManagement.GetAllVehicles;
using MediatR;
using MediatR.Cqrs;
using MediatR.Cqrs.Execution;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Features.VehicleManagement
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : Controller
    {
        private readonly IMediator _mediator;

        public VehicleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all-vehicles")]
        public async Task<IActionResult> GetAllVehicles(
          [FromModel] GetAllVehiclesQuery getAllVehiclesQuery,
          CancellationToken cancellationToken)
        {
            var getAllVehiclesQueryResult = await _mediator.Send(getAllVehiclesQuery, cancellationToken);

            return getAllVehiclesQueryResult.ToActionResult();
        }
    }
}
