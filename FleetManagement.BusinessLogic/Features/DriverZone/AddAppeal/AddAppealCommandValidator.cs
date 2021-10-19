using System;
using FleetManagement.Framework.Helpers;
using FleetManagement.Framework.Models.Enums;
using FluentValidation;

namespace FleetManagement.BLL.Features.DriverZone.AddAppeal
{
    public class AddAppealCommandValidator : AbstractValidator<AddAppealCommand>
    {
        public AddAppealCommandValidator()
        {
            RuleFor(x => x.CreationDate)
               .NotNull()
               .GreaterThan(Helpers.AllphiStartdate());

            When(x => x.FirstDatePlanning != null, () => {
                RuleFor(x => x.FirstDatePlanning)
                    .GreaterThan(Helpers.AllphiStartdate());
            });

            When(x => x.FirstDatePlanning != null, () => {
                RuleFor(x => x.SecondDatePlanning)
                   .NotEqual(x => x.FirstDatePlanning)
                   .GreaterThan(Helpers.AllphiStartdate());
            });

            When(x => x.AppealType == AppealType.Reparation, () =>
            {
                RuleFor(x => x.DamageDescription).NotEmpty();
                RuleFor(x => x.VehicleLocation).NotEmpty();
                RuleFor(x => x.IncidentDate)
                    .NotNull()
                    .GreaterThan(Helpers.AllphiStartdate());
            });

            RuleFor(x => x.AppealType).Must(y => Enum.IsDefined(typeof(AppealType), y));

            RuleFor(x => x.Status).Must(y => Enum.IsDefined(typeof(AppealStatus), y));

            RuleFor(x => x.Message).Must(y => y != null || y.Length < 200); // will it ever be sent as null or rather just string.empty?

            RuleFor(x => x.DriverId).GreaterThan(0);
            RuleFor(x => x.VehicleId).GreaterThan(0);
        }
    }
}
