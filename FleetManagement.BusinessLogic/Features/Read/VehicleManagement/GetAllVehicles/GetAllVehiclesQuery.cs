using FleetManagement.Framework.Paging;
using MediatR.Cqrs.Queries;

namespace FleetManagement.BLL.Features.Read.VehicleManagement.GetAllVehicles
{
    public class GetAllVehiclesQuery : IQuery<GetAllVehiclesQueryResult>
    {
        public PagingParameters PagingParameters { get; set; }
    }
}
