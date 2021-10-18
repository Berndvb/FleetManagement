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

        [HttpPut("{DriverId}/update-contactinfo")]
        public async Task<IActionResult> UpdateContactInfo(
         UpdateContactInfoCommand updateDriverCommand, 
         CancellationToken cancellationToken)
        {
            var updateDriverCommandResult = await _mediator.Send(updateDriverCommand, cancellationToken);

            return updateDriverCommandResult.ToActionResult();
        }
    }
}
