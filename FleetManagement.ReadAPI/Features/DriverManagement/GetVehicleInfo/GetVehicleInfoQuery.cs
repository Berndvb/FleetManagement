using MediatR.Cqrs.Queries;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetVehicleDetails
{
    public class GetVehicleInfoQuery : IQuery<GetVehicleInfoQueryResult>
    {
        public string DriverId { get; set; }
    }
}
