using FleetManagement.Framework.Paging;
using MediatR.Cqrs.Queries;

namespace FleetManagement.BLL.Features.Read.AppealManagement.GetAllAppeals
{
    public class GetAllAppealsQuery : IQuery<GetAllAppealsQueryResult>
    {
        public PagingParameters PagingParameters { get; set; }

        public  string AppealStatus { get; set; }
    }
}
