using FleetManagement.Framework.Paging;
using MediatR.Cqrs.Queries;

namespace FleetManagement.BLL.Features.DriverZone.GetVehiclesForDriver
{
    public class GetVehiclesForDriverQuery : IQuery<GetVehiclesForDriverQueryResult>
    {
        public int DriverId { get; set; }

        public PagingParameters PagingParameters { get; set; }
    }
}
