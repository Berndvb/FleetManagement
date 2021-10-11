using FleetManagement.Framework.Paging;
using MediatR.Cqrs.Queries;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetMaintenancesPerCar
{
    public class GetMaintenancesPerCarQuery : IQuery<GetMaintenancesPerCarQueryResult>
    {
        public string DriverId { get; set; }

        public string VehicleId { get; set; }

        public PagingParameters PagingParameters { get; set; }
    }
}
