using FleetManagement.Framework.Paging;
using MediatR.Cqrs.Queries;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetReparationsPerCar
{
    public class GetRepairsPerCarQuery : IQuery<GetRepairsPerCarQueryResult>
    {
        public int DriverId { get; set; }

        public int VehicleId { get; set; }

        public PagingParameters PagingParameters { get; set; }
    }
}
