using MediatR.Cqrs.Queries;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetTotalAppeals
{
    public class GetAllAppealsQuery : IQuery<GetAllAppealsQueryResult>
    {
        public string DriverId { get; set; }
    }
}
