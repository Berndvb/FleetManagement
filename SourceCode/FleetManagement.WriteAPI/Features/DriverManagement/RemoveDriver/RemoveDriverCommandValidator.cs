using FluentValidation;

namespace FleetManagement.WriteAPI.Features.DriverManagement.RemoveDriver
{
    public class RemoveDriverCommandValidator : AbstractValidator<RemoveDriverCommand>
    {
        public RemoveDriverCommandValidator()
        {
            RuleFor(x => x.Driver.Id)
                .Must(y => y > 0);
        }
    }
}
