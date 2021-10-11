using FleetManagement.Framework.Paging;
using MediatR.Cqrs.Queries;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetFuelCardDetails
{
    public class GetFuelCardsQuery : IQuery<GetFuelCardsQueryResult>
    {
        public string DriverId { get; set; }

        public PagingParameters PagingParameters { get; set; }
    }
}
