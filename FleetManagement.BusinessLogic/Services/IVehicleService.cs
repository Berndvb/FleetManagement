using FleetManagement.BLL.Services.Models;
using FleetManagement.Framework.Models.Dtos;
using MediatR.Cqrs.Execution;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Services
{
    public interface IVehicleService
    {
        void UpdateVehicle(VehicleDto vehicleDto);
        void UpdateVehicle(VehicleDetailsDto vehicleDetailsDto);
        Task<IdValidationCodes> ValidateId(int id);
        Task<ExecutionError> CheckforIdError(string id);
    }
}
