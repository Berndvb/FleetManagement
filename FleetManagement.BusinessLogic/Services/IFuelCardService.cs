using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.BLL.Models.Dtos.WriteDtos;
using FleetManagement.Framework.Paging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Services
{
    public interface IFuelCardService
    {
        Task UpdateFuelCard(CancellationToken cancellationToken, FuelCardDto fuelCardDto, int fuelCardId);
        Task<List<FuelCardDto>> GetAllFuelCards(CancellationToken cancellationToken, PagingParameters pagingParameter = null);
        Task AddFuelCard(CancellationToken cancellationToken, AddFuelCardDto fuelCardDto);
    }
}
