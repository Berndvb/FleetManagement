using FleetManagement.Framework.Models.Dtos;
using FleetManagement.Framework.Models.Dtos.ReadDtos;
using FleetManagement.Framework.Models.WriteDtos;
using System.Threading;

namespace FleetManagement.BLL.Services
{
    public interface IFuelCardDriverService
    {
        void UpdateFuelCardDriver(CancellationToken cancellationToken, FuelCardDriverDto fuelCardDriverDto);
        void AddFuelCardDriver(CancellationToken cancellationToken, AddFuelCardDriverDto fuelCardDriverDto);
    }
}
