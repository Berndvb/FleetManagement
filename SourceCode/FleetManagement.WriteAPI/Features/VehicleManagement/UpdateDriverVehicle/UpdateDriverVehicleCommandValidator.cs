using FleetManagement.Framework.Helpers;
using FluentValidation;

namespace FleetManagement.WriteAPI.Features.VehicleManagement.UpdateDriverVehicle
{
    public class UpdateDriverVehicleCommandValidator : AbstractValidator<UpdateDriverVehicleCommand>
    {
        public UpdateDriverVehicleCommandValidator()
        {
            RuleFor(x => x.DriverVehicle.Id)
                .Must(y => y > 0);

            RuleFor(x => x.DriverVehicle.CreationDate)
                .NotNull()
                .GreaterThan(Helpers.AllphiStartdate());

            When(x => x.DriverVehicle.ClosureDate != null, () =>
            {
                RuleFor(x => x.DriverVehicle.ClosureDate)
                .GreaterThan(Helpers.AllphiStartdate())
                .GreaterThan(y => y.DriverVehicle.CreationDate);
            });
        }
    }
}
