using MediatR;
using MediatR.Cqrs;
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

        [HttpGet("all-driveroverviews/")]
        public async Task<IActionResult> GetAllDriverOverviews(
           [FromModel] GetAllDriverOverviewsQuery getAllDriverOverviewsQuery,
           CancellationToken cancellationToken)
        {
            var getAllDriverOverviewsQueryResult = await _mediator.Send(getAllDriverOverviewsQuery, cancellationToken);

            return getAllDriverOverviewsQueryResult.ToActionResult();
        }
    }
}
