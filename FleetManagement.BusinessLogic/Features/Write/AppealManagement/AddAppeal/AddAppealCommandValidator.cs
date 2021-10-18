using FleetManagement.Framework.Helpers;
using FleetManagement.Framework.Models.Enums;
using FluentValidation;
using System;

namespace FleetManagement.BLL.Features.Write.FuelCardManagement.AddFuelCard
{
    public class AddAppealCommandValidator : AbstractValidator<AddAppealCommand>
    {
        public AddAppealCommandValidator()
        {
            RuleFor(x => x.Appeal.DriverId).Must(y => y > 0);

            RuleFor(x => x.Appeal.VehicleId).Must(y => y > 0);

            RuleFor(x => x.Appeal.CreationDate)
               .NotNull()
               .GreaterThan(Helpers.AllphiStartdate());

            RuleFor(x => x.Appeal.FirstDatePlanning)
               .GreaterThan(Helpers.AllphiStartdate());

            RuleFor(x => x.Appeal.SecondDatePlanning)
               .NotEqual(x => x.Appeal.FirstDatePlanning)
               .GreaterThan(Helpers.AllphiStartdate());

            RuleFor(x => x.Appeal.AppealType).Must(y => Enum.IsDefined(typeof(AppealType), y));

            RuleFor(x => x.Appeal.Status).Must(y => Enum.IsDefined(typeof(AppealStatus), y));

            RuleFor(x => x.Appeal.Message).Must(y => y != null || y.Length < 200);
        }
    }
}
