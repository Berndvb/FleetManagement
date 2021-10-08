using FleetManagement.Framework.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Services
{
    public interface IFuelCardService
    {
        void UpdateFuelCard(FuelCardDto fuelCardDto);
        Task<List<FuelCardDto>> GetAllFuelCards();
    }
}
