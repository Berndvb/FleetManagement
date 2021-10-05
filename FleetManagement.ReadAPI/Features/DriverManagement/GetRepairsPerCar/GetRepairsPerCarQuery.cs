using MediatR.Cqrs.Queries;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetReparationsPerCar
{
    public class GetRepairsPerCarQuery : IQuery<GetRepairsPerCarQueryResult>
    {
        public string DriverId { get; set; }

        public string VehicleId { get; set; }
    }
}
