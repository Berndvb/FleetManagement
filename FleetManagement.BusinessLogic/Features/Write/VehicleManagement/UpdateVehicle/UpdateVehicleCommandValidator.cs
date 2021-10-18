using FluentValidation;

namespace FleetManagement.BLL.Features.Write.VehicleManagement.UpdateVehicle
{
    public class UpdateVehicleCommandValidator : AbstractValidator<UpdateVehicleCommand>
    {
        public UpdateVehicleCommandValidator()
        {
            RuleFor(x => x.Vehicle.Id).Must(y => y > 0);

            RuleFor(x => x.Vehicle.Identity).NotNull();

            RuleFor(x => x.Vehicle.Mileage).NotNull();
        }
    }
}
