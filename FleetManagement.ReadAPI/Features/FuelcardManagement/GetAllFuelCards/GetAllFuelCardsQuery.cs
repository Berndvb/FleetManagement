using FleetManagement.Framework.Paging;
using MediatR.Cqrs.Queries;

namespace FleetManagement.ReadAPI.Features.FuelcardManagement.GetAllFuelCards
{
    public class GetAllFuelCardsQuery : IQuery<GetAllFuelCardsQueryResult>
    {
        public PagingParameters PagingParameters { get; set; }
    }
}
