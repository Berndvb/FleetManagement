using FleetManagement.ReadAPI.Features.Driver.GetAllDriverOverviews;
using MediatR;
using MediatR.Cqrs;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Features.Driver
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverController : Controller
    {
        private readonly IMediator _mediator;

        public DriverController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// => overal? 
        /// </summary>
        /// <param name="getAllDriverOverviewsQuery"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("driver-overviews")]
        [ProducesResponseType(typeof(GetAllDriverOverviewsQueryResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)] //overbodig
        public async Task<ActionResult<GetAllDriverOverviewsQueryResult>> GetAllDriverOverviews(
            [FromModel] GetAllDriverOverviewsQuery getAllDriverOverviewsQuery,
            CancellationToken cancellationToken)
        {
            //var getAllDriverOverviewsQueryResult = await _mediator.Send(getAllDriverOverviewsQuery, cancellationToken);

            //return getAllDriverOverviewsQueryResult.ToActionResult(); //mag weg 
            return Ok();
        }
    }
}
