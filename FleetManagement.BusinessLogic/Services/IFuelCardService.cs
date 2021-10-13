using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.Framework.Paging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Services
{
    public interface IFuelCardService
    {
        void UpdateFuelCard(CancellationToken cancellationToken, FuelCardDto fuelCardDto);
        Task<List<FuelCardDto>> GetAllFuelCards(CancellationToken cancellationToken, PagingParameters pagingParameter = null);
    }
}
