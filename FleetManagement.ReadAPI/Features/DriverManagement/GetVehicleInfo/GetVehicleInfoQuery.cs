using FleetManagement.Framework.Paging;
using MediatR.Cqrs.Queries;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetVehicleDetails
{
    public class GetVehicleInfoQuery : IQuery<GetVehicleInfoQueryResult>
    {
        public int DriverId { get; set; }

        public PagingParameters PagingParameters { get; set; }
    }
}
