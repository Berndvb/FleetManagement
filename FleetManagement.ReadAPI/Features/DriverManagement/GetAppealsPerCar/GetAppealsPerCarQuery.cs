using MediatR.Cqrs.Queries;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetAppealsPerCar
{
    public class GetAppealsPerCarQuery : IQuery<GetAppealsPerCarQueryResult>
    {
        public string DriverId { get; set; }

        public string VehicleId { get; set; }
    }
}
