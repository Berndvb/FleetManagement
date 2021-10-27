using FleetManagement.Framework.Paging;
using MediatR.Cqrs.Queries;

namespace FleetManagement.BLL.Features.AdministrativeZone.FuelCardManagement.GetFuelCards
{
    public class GetFuelCardsQuery : IQuery<GetFuelCardsQueryResult>
    {
        public PagingParameters PagingParameters { get; set; }
    }
}
