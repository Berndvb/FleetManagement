using MediatR;
using MediatR.Cqrs.Execution;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Features.DriverZone.AddAppeal;
using FleetManagement.BLL.Features.DriverZone.UpdateAppeal;
using FleetManagement.BLL.Features.DriverZone.UpdateContactInfo;
using FleetManagement.BLL.Features.DriverZone.UpdateFuelCard;

namespace FleetManagement.WriteAPI.Controllers
{
    [ApiController]
    [Route("writeapi/[controller]")] 
    public class DriverZoneController : Controller
    {
        private readonly IMediator _mediator;

        public DriverZoneController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("driver/{driverId}")]
        public async Task<IActionResult> UpdateContactInfo(
         UpdateContactInfoCommand updateContactInfoCommand, 
         int driverId,
         CancellationToken cancellationToken)
        {
            var updateContactInfoCommandResult = await _mediator.Send(updateContactInfoCommand.WithId(driverId), cancellationToken);

            return updateContactInfoCommandResult.ToActionResult();
        }

        [HttpPut("fuelCard/{fuelCardId}")]
        public async Task<IActionResult> UpdateFuelCard(
            UpdateFuelCardCommand updateFuelCardCommand,
            int fuelCardId,
            CancellationToken cancellationToken)
        {
            var updateFuelCardCommandResult = await _mediator.Send(updateFuelCardCommand.WithId(fuelCardId), cancellationToken);

            return updateFuelCardCommandResult.ToActionResult();
        }

        [HttpPut("appeal/{appealId}")]
        public async Task<IActionResult> UpdateAppealInfo(
            UpdateAppealInfoCommand updateAppealCommand,
            int appealId,
            CancellationToken cancellationToken)
        {
            var updateAppealCommandResult = await _mediator.Send(updateAppealCommand.WithId(appealId), cancellationToken);

            return updateAppealCommandResult.ToActionResult();
        }

        [HttpPost("appeal")]
        public async Task<IActionResult> AddAppeal(
            AddAppealCommand addAppealCommand,
            CancellationToken cancellationToken)
        {
            var addAppealCommandResult = await _mediator.Send(addAppealCommand, cancellationToken);

            return addAppealCommandResult.ToActionResult();
        }
    }
}
