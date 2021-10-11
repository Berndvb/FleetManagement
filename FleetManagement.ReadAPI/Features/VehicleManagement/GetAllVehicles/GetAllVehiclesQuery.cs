using FleetManagement.Framework.Paging;
using MediatR.Cqrs.Queries;

namespace FleetManagement.ReadAPI.Features.VehicleManagement.GetAllVehicles
{
    public class GetAllVehiclesQuery : IQuery<GetAllVehiclesQueryResult>
    {
        public PagingParameters PagingParameters { get; set; }
    }
}
