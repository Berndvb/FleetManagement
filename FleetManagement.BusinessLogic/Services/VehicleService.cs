using AutoMapper;
using FleetManagement.BLL.Mapper.MapperSercice;
using FleetManagement.BLL.Services.Models;
using FleetManagement.Domain.Interfaces.Repositories;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Paging;
using MediatR.Cqrs.Execution;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.BLL.Models.Dtos.WriteDtos;

namespace FleetManagement.BLL.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMapperService _mapperService;

        private readonly IGeneralService _generalService;

        public VehicleService(
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            IMapperService mapperService,
            IGeneralService generalService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mapperService = mapperService;
            _generalService = generalService;
        }

        public async Task<List<VehicleDetailsDto>> GetAllVehicles(CancellationToken cancellationToken, PagingParameters pagingParameter)
        {
            var vehicles = await _unitOfWork.Vehicles.GetListBy(
                cancellationToken,
                pagingParameter,
                including: x => x
                 .Include(y => y.Identity)
                 .Include(y => y.Maintenances)
                 .Include(y => y.Reparations)
                 .Include(y => y.Drivers)
                 .Include(y => y.Appeals));

            var vehicleDtos = _mapper.Map<List<VehicleDetailsDto>>(vehicles);
            if (pagingParameter != null)
                return _mapperService.GetPaginatedData(vehicleDtos, vehicles);

            return vehicleDtos;
        }

        public async Task UpdateVehicle(CancellationToken cancellationToken, VehicleDetailsDto vehicleDto)
        {
            var vehicle = _mapper.Map<Vehicle>(vehicleDto);

            await _unitOfWork.Vehicles.Update(cancellationToken, vehicle);

            _unitOfWork.Complete();
        }

        public async Task AddVehicle(CancellationToken cancellationToken, AddVehicleDetailsDto addVehicleDto)
        {
            var vehicle = _mapper.Map<Vehicle>(addVehicleDto);

            await _unitOfWork.Vehicles.Insert(cancellationToken, vehicle);

            _unitOfWork.Complete();
        }

        public async Task<InputValidationCodes> ValidateId(CancellationToken cancellationToken, int id)
        {
            var ids = await _unitOfWork.Vehicles.GetIds(cancellationToken, id);

            return ids.Count switch
            {
                0 => InputValidationCodes.IdNotFound,
                > 1 => InputValidationCodes.IdNotUnique,
                _ => InputValidationCodes.OK,
            };
        }

        public async Task<ExecutionError> CheckforIdError(CancellationToken cancellationToken, int id)
        {
            var idValidationCode = await ValidateId(cancellationToken, id);
            if (idValidationCode != InputValidationCodes.OK)
                return _generalService.ProcessIdError(idValidationCode, nameof(id));

            return null;
        }
    }
}
