using AutoMapper;
using FleetManagement.BLL.Services.Models;
using FleetManagement.Domain.Interfaces.Repositories;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Models.Dtos;
using MediatR.Cqrs.Execution;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGeneralService _generalService;

        public VehicleService(
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            IGeneralService generalService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _generalService = generalService;
        }

        public async Task<List<VehicleDetailsDto>> GetAllVehicles()
        {
            var vehicles = await _unitOfWork.Vehicles.GetListBy(
                filter: null,
                x => x.Include(y => y.Identity),
                x => x.Include(y => y.Maintenances),
                x => x.Include(y => y.Reparations),
                x => x.Include(y => y.Drivers),
                x => x.Include(y => y.Appeals));

            var vehicleDtos = _mapper.Map<List<VehicleDetailsDto>>(vehicles);

            return vehicleDtos;
        }

        public void UpdateVehicle(VehicleDetailsDto vehicleDto)
        {
            var vehicle = _mapper.Map<Vehicle>(vehicleDto);

            _unitOfWork.Vehicles.Update(vehicle);

            _unitOfWork.Complete();
        }

        public async Task<IdValidationCodes> ValidateId(int id)
        {
            var ids = await _unitOfWork.Vehicles.GetIds(id);

            return ids.Count switch
            {
                0 => IdValidationCodes.IdNotFound,
                > 1 => IdValidationCodes.IdNotUnique,
                _ => IdValidationCodes.OK,
            };
        }

        public async Task<ExecutionError> CheckforIdError(string id)
        {
            var idParsed = int.Parse(id);

            var idValidationCode = await ValidateId(idParsed);
            if (idValidationCode != IdValidationCodes.OK)
                return _generalService.ProcessIdError(idValidationCode, nameof(id));

            return null;
        }
    }
}
