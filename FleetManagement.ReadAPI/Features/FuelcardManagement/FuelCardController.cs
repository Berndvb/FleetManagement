using FleetManagement.ReadAPI.Features.FuelcardManagement.GetAllFuelCards;
using MediatR;
using MediatR.Cqrs;
using MediatR.Cqrs.Execution;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Features.FuelcardManagement
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuelCardController : Controller
    {
        private readonly IMediator _mediator;

        public FuelCardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all-fuelcards")]
        public async Task<IActionResult> GetAllFuelCards(
         [FromModel] GetAllFuelCardsQuery getAllFuelCardsQuery,
         CancellationToken cancellationToken)
        {
            var getAllFuelCardsQueryResult = await _mediator.Send(getAllFuelCardsQuery, cancellationToken);

            return getAllFuelCardsQueryResult.ToActionResult();
        }
    }
}
