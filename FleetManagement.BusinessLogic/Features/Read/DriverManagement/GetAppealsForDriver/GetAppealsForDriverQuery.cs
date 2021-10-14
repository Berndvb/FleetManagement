using FleetManagement.Framework.Paging;
using MediatR.Cqrs.Queries;

namespace FleetManagement.BLL.Features.Read.DriverManagement.GetAppeals
{
    public class GetAppealsForDriverQuery : IQuery<GetAppealsForDriverQueryResult>
    {
        public int DriverId { get; set; }

        public PagingParameters PagingParameters { get; set; }
    }
}
