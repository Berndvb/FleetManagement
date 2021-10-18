using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.BLL.Services;
using FleetManagement.Domain.Infrastructure.Pagination;
using FleetManagement.Framework.Constants;
using MediatR.Cqrs.Execution;
using MediatR.Cqrs.Queries;

namespace FleetManagement.BLL.Features.Read.FuelcardManagement.GetAllFuelCards
{
    public class GetFuelCardsQueryHandler : QueryHandler<GetFuelCardsQuery, GetFuelCardsQueryResult>
    {
        private readonly IFuelCardService _fuelCardService;

        public GetFuelCardsQueryHandler(
            IFuelCardService fuelCardService)
        {
            _fuelCardService = fuelCardService;
        }

        public async override Task<GetFuelCardsQueryResult> Handle(
            GetFuelCardsQuery request,
            CancellationToken cancellationToken) 
        {
            var fuelCards = await _fuelCardService.GetAllFuelCards(cancellationToken, request.PagingParameters);
            if (fuelCards.Count == 0)
            {
                var warning = new ExecutionWarning("We couldn't find and retrieve any fuelcard data.", Constants.WarningCodes.NoData);
                return SucceededWithNoData(warning);
            }

            var result = new GetFuelCardsQueryResult(fuelCards);
            if (request.PagingParameters != null)
                result.FillPagingInfo((PaginatedList<FuelCardDto>)fuelCards);

            return result;
        }
    }
}
