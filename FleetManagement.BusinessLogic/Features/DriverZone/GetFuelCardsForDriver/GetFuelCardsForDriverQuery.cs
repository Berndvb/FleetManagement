using FleetManagement.Framework.Paging;
using MediatR.Cqrs.Queries;

namespace FleetManagement.BLL.Features.DriverZone.GetFuelCardsForDriver
{
    public class GetFuelCardsForDriverQuery : IQuery<GetFuelCardsForDriverQueryResult>
    {
        public int DriverId { get; set; }

        public PagingParameters PagingParameters { get; set; }
    }
}
