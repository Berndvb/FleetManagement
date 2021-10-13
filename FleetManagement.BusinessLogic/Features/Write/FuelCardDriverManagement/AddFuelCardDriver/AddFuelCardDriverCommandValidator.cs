using FleetManagement.Framework.Helpers;
using FluentValidation;

namespace FleetManagement.BLL.Features.Write.FuelCardDriverManagement.AddFuelCardDriver
{
    public class AddFuelCardDriverCommandValidator : AbstractValidator<AddFuelCardDriverCommand>
    {
        public AddFuelCardDriverCommandValidator()
        {
            RuleFor(x => x.FuelCardDriver.CreationDate)
                .NotNull()
                .GreaterThan(Helpers.AllphiStartdate());

            RuleFor(x => x.FuelCardDriver.FuelCardId).GreaterThan(0);

            RuleFor(x => x.FuelCardDriver.DriverId).GreaterThan(0);
        }
    }
}
