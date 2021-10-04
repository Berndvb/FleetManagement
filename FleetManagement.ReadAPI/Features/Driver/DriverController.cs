using FleetManagement.ReadAPI.Features.Driver.GetAllDriverOverviews;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR.Cqs.Execution;
using MediatR.Cqs;

namespace FleetManagement.ReadAPI.Features.Driver
{
    [ApiController]
    public class DriverController : Controller
    {
        private readonly IMediator _mediator;

        public DriverController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("driver-overviews")]
        [ProducesResponseType(typeof(GetAllDriverOverviewsQueryResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetAllDriverOverviews(
            [FromModel] GetAllDriverOverviewsQuery getAllDriverOverviewsQuery,
            CancellationToken cancellationToken)
        {
            var getAllDriverOverviewsQueryResult = await _mediator.Send(getAllDriverOverviewsQuery, cancellationToken);

            return getAllDriverOverviewsQueryResult.ToActionResult();
        }
    }
}
