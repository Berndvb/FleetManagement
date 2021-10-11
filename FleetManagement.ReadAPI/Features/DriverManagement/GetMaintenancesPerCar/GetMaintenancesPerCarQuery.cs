using FleetManagement.Framework.Paging;
using MediatR.Cqrs.Queries;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetMaintenancesPerCar
{
    public class GetMaintenancesPerCarQuery : IQuery<GetMaintenancesPerCarQueryResult>
    {
        public int DriverId { get; set; }

        public int VehicleId { get; set; }

        public PagingParameters PagingParameters { get; set; }
    }
}
