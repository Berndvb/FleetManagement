using FluentValidation;

namespace FleetManagement.WriteAPI.Features.VehicleManagement.UpdateVehicle
{
    public class UpdateVehicleCommandValidator : AbstractValidator<UpdateVehicleCommand>
    {
        public UpdateVehicleCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Vehicle.Id)
                .Must(y => y > 0);

            RuleFor(x => x.Vehicle.Identity)
                .NotNull();

            RuleFor(x => x.Vehicle.Mileage)
                .NotNull();
        }
    }
}
