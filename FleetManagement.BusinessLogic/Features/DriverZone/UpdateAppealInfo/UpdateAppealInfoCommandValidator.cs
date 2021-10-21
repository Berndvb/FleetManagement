using FleetManagement.Framework.Helpers;
using FleetManagement.Framework.Models.Enums;
using FluentValidation;
using System;

namespace FleetManagement.BLL.Features.DriverZone.UpdateAppeal
{
    public class UpdateAppealInfoCommandValidator : AbstractValidator<UpdateAppealInfoCommand>
    {
        public UpdateAppealInfoCommandValidator()
        {
            RuleFor(x => x.AppealType).Must(y => Enum.IsDefined(typeof(AppealType), y));

            When(x => x.FirstDatePlanning != null, () => {
                RuleFor(x => x.FirstDatePlanning)
                    .GreaterThan(Helpers.AllphiStartdate());
            });

            When(x => x.FirstDatePlanning != null, () => {
                RuleFor(x => x.SecondDatePlanning)
                    .NotEqual(x => x.FirstDatePlanning)
                    .GreaterThan(Helpers.AllphiStartdate());
            });

            RuleFor(x => x.Message).Must(y => y != null || y.Length < 200);
        }
    }
}
