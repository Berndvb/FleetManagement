using FleetManagement.Framework.Paging;
using MediatR.Cqrs.Queries;

namespace FleetManagement.BLL.Features.Read.DriverManagement.GetRepairsPerCar
{
    public class GetRepairsPerCarQuery : IQuery<GetRepairsPerCarQueryResult>
    {
        public int DriverId { get; set; }

        public int VehicleId { get; set; }

        public PagingParameters PagingParameters { get; set; }
    }
}
