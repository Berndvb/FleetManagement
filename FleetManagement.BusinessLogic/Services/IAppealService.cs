using FleetManagement.Framework.Models.Dtos.ShowDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Services
{
    public interface IAppealService
    {
        Task<List<AppealDto>> GetAllAppeals();
    }
}
