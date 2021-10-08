using MediatR.Cqrs.Queries;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetTotalAppeals
{
    public class GetAppealsQuery : IQuery<GetAppealsQueryResult>
    {
        public string DriverId { get; set; }
    }
}
