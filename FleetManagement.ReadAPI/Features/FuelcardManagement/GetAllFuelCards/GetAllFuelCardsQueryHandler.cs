using FleetManagement.BLL.Services;
using FleetManagement.Framework.Constants;
using MediatR.Cqrs.Execution;
using MediatR.Cqrs.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Features.FuelcardManagement.GetAllFuelCards
{
    public class GetAllFuelCardsQueryHandler : QueryHandler<GetAllFuelCardsQuery, GetAllFuelCardsQueryResult>
    {
        private readonly IFuelCardService _fuelCardService;

        public GetAllFuelCardsQueryHandler(
            IFuelCardService fuelCardService)
        {
            _fuelCardService = fuelCardService;
        }

        public async override Task<GetAllFuelCardsQueryResult> Handle(
            GetAllFuelCardsQuery request,
            CancellationToken cancellationToken) 
        {
            var fuelCards = await _fuelCardService.GetAllFuelCards();
            if (fuelCards.Count == 0)
            {
                var dataError = new ExecutionError("We couldn't find and retrieve any fuelcard data.", Constants.ErrorCodes.DataNotFound);
                return NotFound(dataError);
            }

            return new GetAllFuelCardsQueryResult(fuelCards);
        }
    }
}
