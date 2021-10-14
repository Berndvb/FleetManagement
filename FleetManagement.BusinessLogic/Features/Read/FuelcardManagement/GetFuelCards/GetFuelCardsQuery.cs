using FleetManagement.Framework.Paging;
using MediatR.Cqrs.Queries;

namespace FleetManagement.BLL.Features.Read.FuelcardManagement.GetAllFuelCards
{
    public class GetFuelCardsQuery : IQuery<GetFuelCardsQueryResult>
    {
        public PagingParameters PagingParameters { get; set; }
    }
}
