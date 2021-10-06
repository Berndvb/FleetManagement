using FleetManagement.WriteAPI.Features.DriverManagement.RemoveDriver;
using FluentValidation;

namespace FleetManagement.WriteAPI.Features.DriverManagement.RemoveDriverById
{
    public class RemoveDriverByIdCommandValidator : AbstractValidator<RemoveDriverByIdCommand>
    {
        public RemoveDriverByIdCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.DriverId)
                .Must(y => int.TryParse(y, out _))
                .Must(y => int.Parse(y) > 0);
        }
    }
}
