using System;
using FleetManagement.Framework.Helpers;
using FleetManagement.Framework.Models.Enums;
using FluentValidation;

namespace FleetManagement.BLL.Features.DriverZone.UpdateAppeal
{
    public class UpdateAppealCommandValidator : AbstractValidator<UpdateAppealCommand>
    {
        public UpdateAppealCommandValidator()
        {
            RuleFor(x => x.Appeal.CreationDate)
               .NotNull()
               .GreaterThan(Helpers.AllphiStartdate());

            When(x => x.Appeal.FirstDatePlanning != null, () => {
                RuleFor(x => x.Appeal.FirstDatePlanning)
                    .GreaterThan(Helpers.AllphiStartdate());
            });

            When(x => x.Appeal.FirstDatePlanning != null, () => {
                RuleFor(x => x.Appeal.SecondDatePlanning)
                   .NotEqual(x => x.Appeal.FirstDatePlanning)
                   .GreaterThan(Helpers.AllphiStartdate());
            });
            
            RuleFor(x => x.Appeal.AppealType).Must(y => Enum.IsDefined(typeof(AppealType), y));

            RuleFor(x => x.Appeal.Status).Must(y => Enum.IsDefined(typeof(AppealStatus), y));

            RuleFor(x => x.Appeal.Message).Must(y => y != null || y.Length < 200);

            RuleFor(x => x.Appeal.Driver).NotNull();
        }
    }
}
