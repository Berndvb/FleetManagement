using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BLL.Models.Dtos.WriteDtos;
using FleetManager.EFCore.UOW;
using MediatR.Cqrs.Commands;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement.BLL.Features.DriverZone.UpdateContactInfo
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
            await UpdateContactinfo(
                request.Driver, 
                request.DriverId, 
                cancellationToken);

            return new UpdateContactInfoCommandResult();
        }

        public async Task UpdateContactinfo(
            AddDriverDetailsDto driverDto, 
            int driverId,
            CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.Drivers.GetBy(
                cancellationToken,
                filter: x => x.Id.Equals(driverId),
                including: x => x
                    .Include(y => y.Contactinfo)
                        .ThenInclude(z => z.Address));

            driver.ChangeContactInfoForDriver(
                driverDto.Contactinfo.EmailAddress,
                driverDto.Contactinfo.PhoneNumber,
                driverDto.Contactinfo.Address.Street,
                driverDto.Contactinfo.Address.StreetNumber,
                driverDto.Contactinfo.Address.City,
                driverDto.Contactinfo.Address.Postcode);

            await _unitOfWork.Drivers.Update(driver, cancellationToken);

            _unitOfWork.Complete();
        }
    }
}
