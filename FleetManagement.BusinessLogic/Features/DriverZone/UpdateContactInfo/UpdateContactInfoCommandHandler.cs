using FleetManager.EFCore.UOW;
using MediatR.Cqrs.Commands;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

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
            await UpdateContactinfo(request, cancellationToken);

            return new UpdateContactInfoCommandResult();
        }

        private async Task UpdateContactinfo(
            UpdateContactInfoCommand request,
            CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.Drivers.GetBy(
                cancellationToken,
                filter: x => x.Id.Equals(request.DriverId),
                including: x => x
                    .Include(y => y.Contactinfo)
                         .ThenInclude(y => y.Address));

            driver.Contactinfo.EmailAddress = request.EmailAddress;
            driver.Contactinfo.PhoneNumber = request.PhoneNumber;
            driver.Contactinfo.Address.Street = request.Street;
            driver.Contactinfo.Address.StreetNumber = request.StreetNumber;
            driver.Contactinfo.Address.City = request.City;
            driver.Contactinfo.Address.Postcode = request.Postcode;

            await _unitOfWork.Drivers.Update(driver, cancellationToken);

            _unitOfWork.Complete();
        }
    }
}
