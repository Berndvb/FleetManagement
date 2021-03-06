using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Features.Read.AppealManagement.GetAllAppeals;
using MediatR;
using MediatR.Cqrs;
using MediatR.Cqrs.Execution;
using Microsoft.AspNetCore.Mvc;

namespace FleetManagement.ReadAPI.Controllers
{
    [ApiController]
    [Route("readapi/[controller]")]
    public class AppealController : Controller
    {
        private readonly IMediator _mediator;

        public AppealController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all-appeals")]
        public async Task<IActionResult> GetAllAppeals(
          [FromModel] GetAllAppealsQuery getAllAppealsQuery,
          CancellationToken cancellationToken)
        {
            var getAllAppealsQueryResult = await _mediator.Send(getAllAppealsQuery, cancellationToken);

            return getAllAppealsQueryResult.ToActionResult();
        }
    }
}
