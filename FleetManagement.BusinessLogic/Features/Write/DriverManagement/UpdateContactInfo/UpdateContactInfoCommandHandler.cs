using FleetManagement.BLL.Models.Dtos.WriteDtos;
using FleetManagement.Domain.Interfaces.Repositories;
using MediatR.Cqrs.Commands;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Features.Write.DriverManagement.UpdateDriver
{
    public class UpdateContactInfoCommandHandler : CommandHandler<UpdateContactInfoCommand, UpdateContactInfoCommandResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateContactInfoCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<UpdateContactInfoCommandResult> Handle(
            UpdateContactInfoCommand request,
            CancellationToken cancellationToken)
        {
            await UpdateContactinfo(cancellationToken, request.Driver, request.DriverId);

            return new UpdateContactInfoCommandResult();
        }

        public async Task UpdateContactinfo(CancellationToken cancellationToken, AddDriverDetailsDto driverDto, int driverId)
        {
            var driver = await _unitOfWork.Drivers.GetBy(
                cancellationToken,
                filter: x => x.Id.Equals(driverId),
                including: x => x
                    .Include(y => y.Contactinfo)
                        .ThenInclude(z => z.Address));

            driver.Contactinfo.EmailAddress = driverDto.Contactinfo.EmailAddress;
            driver.Contactinfo.PhoneNumber = driverDto.Contactinfo.PhoneNumber;
            driver.Contactinfo.Address.Street = driverDto.Contactinfo.Address.Street;
            driver.Contactinfo.Address.StreetNumber = driverDto.Contactinfo.Address.StreetNumber;
            driver.Contactinfo.Address.City = driverDto.Contactinfo.Address.City;
            driver.Contactinfo.Address.Postcode = driverDto.Contactinfo.Address.Postcode;

            await _unitOfWork.Drivers.Update(cancellationToken, driver);

            _unitOfWork.Complete();
        }
    }
}
