using MediatR.Cqrs.Queries;

namespace FleetManagement.ReadAPI.Features.Driver.GetDriverDetails
{
    public class GetDriverDetailsQuery : IQuery<GetDriverDetailsQueryResult>
    {
        public int DriverId { get; set; }
    }
}
