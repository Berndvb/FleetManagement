using FleetManagement.BLL.Features.Write.DriverManagement.UpdateDriver;
using MediatR;
using MediatR.Cqrs.Execution;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.WriteAPI.Controllers
{
    [ApiController]
    [Route("writeapi/[controller]")] 
    public class DriverController : Controller
    {
        private readonly IMediator _mediator;

        public DriverController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("{DriverId}")]
        public async Task<IActionResult> UpdateDriver(
         UpdateDriverCommand updateDriverCommand, 
         CancellationToken cancellationToken)
        {
            var updateDriverCommandResult = await _mediator.Send(updateDriverCommand, cancellationToken);

            return updateDriverCommandResult.ToActionResult();
        }
    }
}
