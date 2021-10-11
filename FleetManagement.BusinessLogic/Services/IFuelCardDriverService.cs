using FleetManagement.Framework.Models.Dtos;
using FleetManagement.Framework.Models.Dtos.ReadDtos;
using FleetManagement.Framework.Models.WriteDtos;

namespace FleetManagement.BLL.Services
{
    public interface IFuelCardDriverService
    {
        void UpdateFuelCardDriver(FuelCardDriverDto fuelCardDriverDto);
        void AddFuelCardDriver(AddFuelCardDriverDto fuelCardDriverDto);
    }
}
