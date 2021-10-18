using MediatR.Cqrs.Queries;

namespace FleetManagement.BLL.Features.DriverZone.GetDriverDetails
{
    public class GetDriverDetailsQuery : IQuery<GetDriverDetailsQueryResult>
    {
        public int DriverId { get; set; }
    }
}
