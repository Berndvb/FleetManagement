using FleetManagement.Framework.Paging;
using MediatR.Cqrs.Queries;

namespace FleetManagement.BLL.Features.AdministrativeZone.AppealManagement.GetAppeals
{
    public class GetAppealsQuery : IQuery<GetAppealsQueryResult>
    {
        public PagingParameters PagingParameters { get; set; }

        public  string AppealStatus { get; set; }
    }
}
