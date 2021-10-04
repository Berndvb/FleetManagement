using FleetManagement.Framework.Models.Dtos.ShowDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Services
{
    public interface IAppealService
    {
        Task<List<AppealDto>> GetAppealsForDriver(int driverId);
    }
}
