using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Features.Read.FuelcardManagement.GetAllFuelCards;
using FleetManagement.BLL.Features.Write.FuelCardManagement.AddFuelCard;
using MediatR;
using MediatR.Cqrs;
using MediatR.Cqrs.Execution;
using Microsoft.AspNetCore.Mvc;

namespace FleetManagement.ReadAPI.Controllers
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

        [HttpGet()]
        public async Task<IActionResult> GetAllFuelCards(
         [FromModel] GetFuelCardsQuery getAllFuelCardsQuery,
         CancellationToken cancellationToken)
        {
            var getAllFuelCardsQueryResult = await _mediator.Send(getAllFuelCardsQuery, cancellationToken);

            return getAllFuelCardsQueryResult.ToActionResult();
        }
    }
}
