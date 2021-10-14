using FleetManagement.Framework.Paging;
using MediatR.Cqrs.Queries;

namespace FleetManagement.BLL.Features.Read.VehicleManagement.GetAllVehicles
{
    public class GetVehiclesQuery : IQuery<GetVehiclesQueryResult>
    {
        public PagingParameters PagingParameters { get; set; }
    }
}
