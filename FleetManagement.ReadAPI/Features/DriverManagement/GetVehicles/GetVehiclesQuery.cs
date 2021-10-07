using MediatR.Cqrs.Queries;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetVehicleDetails
{
    public class GetVehiclesQuery : IQuery<GetVehiclesQueryResult>
    {
        public string DriverId { get; set; }
    }
}
