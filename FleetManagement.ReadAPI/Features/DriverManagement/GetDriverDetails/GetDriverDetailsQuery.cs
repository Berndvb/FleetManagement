using FleetManagement.Framework.Paging;
using MediatR.Cqrs.Queries;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetDriverDetails
{
    public class GetDriverDetailsQuery : IQuery<GetDriverDetailsQueryResult>
    {
        public int DriverId { get; set; }
    }
}
