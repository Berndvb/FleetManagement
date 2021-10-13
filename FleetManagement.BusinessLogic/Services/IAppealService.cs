using FleetManagement.Framework.Models.Enums;
using FleetManagement.Framework.Paging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Models.Dtos.ReadDtos;

namespace FleetManagement.BLL.Services
{
    public interface IAppealService
    {
        Task<List<AppealDto>> GetAllAppeals(CancellationToken cancellationToken, PagingParameters pagingParameter = null, AppealStatus appealstatus = 0);
    }
}
