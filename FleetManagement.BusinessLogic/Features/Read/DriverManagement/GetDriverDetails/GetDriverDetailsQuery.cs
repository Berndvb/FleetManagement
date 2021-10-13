using MediatR.Cqrs.Queries;

namespace FleetManagement.BLL.Features.Read.DriverManagement.GetDriverDetails
{
    public class GetDriverDetailsQuery : IQuery<GetDriverDetailsQueryResult>
    {
        public int DriverId { get; set; }
    }
}
