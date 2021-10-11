using FleetManagement.Framework.Models.Enums;
using FleetManagement.Framework.Paging;
using MediatR.Cqrs.Queries;

namespace FleetManagement.ReadAPI.Features.AppealManagement.GetAllAppeals
{
    public class GetAllAppealsQuery : IQuery<GetAllAppealsQueryResult>
    {
        public PagingParameters PagingParameters { get; set; }

        public  string AppealStatus { get; set; }
    }
}
