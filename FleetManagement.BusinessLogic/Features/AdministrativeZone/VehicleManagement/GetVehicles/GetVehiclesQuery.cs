using FleetManagement.Framework.Paging;
using MediatR.Cqrs.Queries;

namespace FleetManagement.BLL.Features.AdministrativeZone.VehicleManagement.GetVehicles
{
    public class GetVehiclesQuery : IQuery<GetVehiclesQueryResult>
    {
        public PagingParameters PagingParameters { get; set; }
    }
}
