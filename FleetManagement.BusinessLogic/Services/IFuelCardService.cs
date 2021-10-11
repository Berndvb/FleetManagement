using FleetManagement.Framework.Models.Dtos;
using FleetManagement.Framework.Models.Dtos.ReadDtos;
using FleetManagement.Framework.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Services
{
    public interface IFuelCardService
    {
        void UpdateFuelCard(FuelCardDto fuelCardDto);
        Task<List<FuelCardDto>> GetAllFuelCards(PagingParameters pagingParameter = null);
    }
}
