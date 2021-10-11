using FleetManagement.Framework.Paging;
using MediatR.Cqrs.Queries;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetAppealsPerCar
{
    public class GetAppealsPerCarQuery : IQuery<GetAppealsPerCarQueryResult>
    {
        public int DriverId { get; set; }

        public int VehicleId { get; set; }

        public PagingParameters PagingParameters { get; set; }
    }
}
