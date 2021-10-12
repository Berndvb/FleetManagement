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
            var fuelCards = await _fuelCardService.GetAllFuelCards(request.PagingParameters);
            if (fuelCards.Count == 0)
            {
                var warning = new ExecutionWarning("We couldn't find and retrieve any fuelcard data.", Constants.WarningCodes.NoData);
                return SuccesWithNoData(warning);
            }

            return new GetAllFuelCardsQueryResult(fuelCards);
        }
    }
}
