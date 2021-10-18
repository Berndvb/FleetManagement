using FleetManagement.BLL.Features.Write.AppealManagement.AddAppeal;
using MediatR;
using MediatR.Cqrs.Execution;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.WriteAPI.Controllers
{
    [ApiController]
    [Route("writeapi/[controller]")]
    public class AppealController : Controller
    {
        private readonly IMediator _mediator;

        public AppealController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> AddAppeal(
          AddAppealCommand addAppealCommand,
          CancellationToken cancellationToken)
        {
            var addAppealCommandResult = await _mediator.Send(addAppealCommand, cancellationToken);

            return addAppealCommandResult.ToActionResult();
        }

        //public async Task<IActionResult> UpdateAppeal(
        // UpdateAppealCommand updateAppealCommand,
        // CancellationToken cancellationToken)
        //{
        //    var updateAppealCommandResult = await _mediator.Send(updateAppealCommand, cancellationToken);

        //    return UpdateAppealCommand.ToActionResult();
        //}
    }
}
