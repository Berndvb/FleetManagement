using MediatR.Cqrs.Queries;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetVehicleDetails
{
    public class GetVehicleDetailsQuery : IQuery<GetVehicleDetailsQueryResult>
    {
        public string DriverId { get; set; }
    }
}
