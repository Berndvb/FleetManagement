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

        /// <summary>
        /// As a driver there is the possibility to update a restricted amount of the driver-info.
        /// </summary>
        /// <param name="updateDriverCommand"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("driver/{DriverId}")]
        public async Task<IActionResult> UpdateContactInfo(
         UpdateContactInfoCommand updateDriverCommand, 
         CancellationToken cancellationToken)
        {
            var updateDriverCommandResult = await _mediator.Send(updateDriverCommand, cancellationToken);

            return updateDriverCommandResult.ToActionResult();
        }


        /// <summary>
        /// As a driver there is the possibility to update a restricted amount of the fuelcard-info.
        /// </summary>
        /// <param name="updateFuelCardCommand"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("fuelCard/{fuelCardId}")]
        public async Task<IActionResult> UpdateFuelCard(
            UpdateFuelCardCommand updateFuelCardCommand,
            int fuelCardId,
            CancellationToken cancellationToken)
        {
            var updateFuelCardCommandResult = await _mediator.Send(updateFuelCardCommand, cancellationToken);

            return updateFuelCardCommandResult.ToActionResult();
        }


        /// <summary>
        /// As a driver there is the possibility to update a restricted amount of the appeal-info.
        /// </summary>
        /// <param name="updateAppealCommand"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("appeal/{appealId}")]
        public async Task<IActionResult> UpdateAppeal(
            UpdateAppealCommand updateAppealCommand,
            int appealId,
            CancellationToken cancellationToken)
        {
            var updateAppealCommandResult = await _mediator.Send(updateAppealCommand, cancellationToken);

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
