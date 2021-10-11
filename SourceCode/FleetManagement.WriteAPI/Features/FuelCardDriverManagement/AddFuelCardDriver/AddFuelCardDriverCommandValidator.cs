using FleetManagement.Framework.Helpers;
using FluentValidation;

namespace FleetManagement.WriteAPI.Features.FuelCardDriverManagement.AddFuelCardDriverConnection
{
    public class AddFuelCardDriverCommandValidator : AbstractValidator<AddFuelCardDriverCommand>
    {
        public AddFuelCardDriverCommandValidator()
        {
            RuleFor(x => x.FuelCardDriver.Id).Must(y => y > 0);

            RuleFor(x => x.FuelCardDriver.CreationDate)
                .NotNull()
                .GreaterThan(Helpers.AllphiStartdate());

            When(x => x.FuelCardDriver.ClosureDate != null, () =>
            {
                RuleFor(x => x.FuelCardDriver.ClosureDate)
                .GreaterThan(Helpers.AllphiStartdate())
                .GreaterThan(y => y.FuelCardDriver.CreationDate);
            });

            RuleFor(x => x.FuelCardDriver.FuelCard).NotNull();

            RuleFor(x => x.FuelCardDriver.Driver).NotNull();
        }
    }
}
