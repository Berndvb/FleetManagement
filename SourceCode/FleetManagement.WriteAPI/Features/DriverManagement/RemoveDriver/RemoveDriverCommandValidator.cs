using FleetManagement.Framework.Models.Enums;
using FleetManagement.WriteAPI.Features.DriverManagement.RemoveDriver;
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
