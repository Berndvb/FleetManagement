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

        public void UpdateVehicle(CancellationToken cancellationToken, VehicleDetailsDto vehicleDto)
        {
            var vehicle = _mapper.Map<Vehicle>(vehicleDto);

            _unitOfWork.Vehicles.Update(cancellationToken, vehicle);

            _unitOfWork.Complete();
        }

        public async Task<IdValidationCodes> ValidateId(CancellationToken cancellationToken, int id)
        {
            var ids = await _unitOfWork.Vehicles.GetIds(cancellationToken, id);

            return ids.Count switch
            {
                0 => IdValidationCodes.IdNotFound,
                > 1 => IdValidationCodes.IdNotUnique,
                _ => IdValidationCodes.OK,
            };
        }

        public async Task<ExecutionError> CheckforIdError(CancellationToken cancellationToken, int id)
        {
            var idValidationCode = await ValidateId(cancellationToken, id);
            if (idValidationCode != IdValidationCodes.OK)
                return _generalService.ProcessIdError(idValidationCode, nameof(id));

            return null;
        }
    }
}
