using AutoMapper;
using FleetManagement.BLL.Models.Dtos.WriteDtos;
using FleetManagement.Domain.Interfaces.Repositories;
using FleetManagement.Domain.Models;
using MediatR.Cqrs.Commands;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Features.Write.DriverManagement.UpdateDriver
{
    public class UpdateDriverCommandHandler : CommandHandler<UpdateDriverCommand, UpdateDriverCommandResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDriverCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async override Task<UpdateDriverCommandResult> Handle(
            UpdateDriverCommand request,
            CancellationToken cancellationToken)
        {
            await UpdateDriver(cancellationToken, request.Driver, request.DriverId);

            return new UpdateDriverCommandResult();
        }

        public async Task UpdateDriver(CancellationToken cancellationToken, AddDriverDetailsDto driverDto, int driverId)
        {
            var driver = _mapper.Map<Driver>(driverDto);

            await _unitOfWork.Drivers.Update(
                cancellationToken,
                driver,
                driverId,
                including: x => x
                    .Include(y => y.Identity)
                    .Include(y => y.Contactinfo)
                        .ThenInclude(z => z.Address));

            _unitOfWork.Complete();
        }
    }
}
