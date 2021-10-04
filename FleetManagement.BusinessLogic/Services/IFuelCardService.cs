using FleetManagement.Framework.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Services
{
    public interface IFuelCardService
    {
        Task<List<FuelCardDto>> GetFuelCardDetailsForDriver(int driverId);
        void UpdateFuelCard(FuelCardDto fuelCardDto);
    }
}
