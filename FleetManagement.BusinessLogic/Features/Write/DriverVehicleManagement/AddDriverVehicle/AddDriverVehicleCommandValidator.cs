using FleetManagement.Framework.Helpers;
using FluentValidation;

namespace FleetManagement.BLL.Features.Write.DriverVehicleManagement.AddDriverVehicle
{
    public class AddDriverVehicleCommandValidator : AbstractValidator<AddDriverVehicleCommand>
    {
        public AddDriverVehicleCommandValidator()
        {
            RuleFor(x => x.DriverVehicle.CreationDate)
                .NotNull()
                .GreaterThan(Helpers.AllphiStartdate());

            When(x => x.DriverVehicle.ClosureDate != null, () =>
            {
                RuleFor(x => x.DriverVehicle.ClosureDate)
                .GreaterThan(Helpers.AllphiStartdate())
                .GreaterThan(y => y.DriverVehicle.CreationDate);
            });

            RuleFor(x => x.DriverVehicle.Vehicle).NotNull();

            RuleFor(x => x.DriverVehicle.Driver).NotNull();
        }
    }
}
