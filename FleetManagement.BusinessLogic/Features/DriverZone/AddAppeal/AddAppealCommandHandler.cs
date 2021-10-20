using FleetManagement.Domain.Models;
using FleetManager.EFCore.UOW;
using MediatR.Cqrs.Commands;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FleetManagement.Framework.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement.BLL.Features.DriverZone.AddAppeal
{
    public class AddAppealCommandHandler : CommandHandler<AddAppealCommand, AddAppealCommandResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddAppealCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<AddAppealCommandResult> Handle(
            AddAppealCommand request,
            CancellationToken cancellationToken)
        {
            await AddAppeal(request, cancellationToken);

            return new AddAppealCommandResult();
        }

        public async Task AddAppeal(AddAppealCommand request, CancellationToken cancellationToken)
        {
            var vehicle = await _unitOfWork.Vehicles.GetBy(
                cancellationToken,
                filter: x => x.Id.Equals(request.VehicleId),
                including: x => x.Include(y => y.Identity));

            var driver = await _unitOfWork.Drivers.GetBy(
                cancellationToken,
                filter: x => x.Id.Equals(request.DriverId),
                including: x => x.Include(y => y.Identity));

            var message = BuildAppealMessage(request, driver.Identity.Name, driver.Identity.FirstName);

            var appeal = new Appeal(
                request.CreationDate,
                request.AppealType,
                request.Status,
                vehicle,
                driver,
                request.FirstDatePlanning,
                request.SecondDatePlanning,
                message);

            await _unitOfWork.Appeals.Insert(appeal, cancellationToken);

            _unitOfWork.Complete();
        }

        public string BuildAppealMessage(AddAppealCommand request, string name, string firstname)
        {
            var description = @$"Appeal from {firstname + name} regarding: '{request.AppealType}'.<br />
                <br />            
                Timestamp: {request.CreationDate}<br />
                Info:<br />
                - Message: {request.Message}<br />";

            var messageBuilder = new StringBuilder().Append(description);

            if (request.AppealType != AppealType.Reparation) 
                return messageBuilder.ToString();

            messageBuilder.Append($"- IncidentDate: {request.IncidentDate.ToString()}<br />");
            messageBuilder.Append($"- Damage description: {request.DamageDescription}<br />");
            messageBuilder.Append($"- Vehicle location: {request.VehicleLocation}<br />");
            return messageBuilder.ToString();
        }
    }
}
