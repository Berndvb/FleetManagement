using FleetManagement.Framework.Models.Enums;
using FluentValidation;

namespace FleetManagement.WriteAPI.Features.DriverManagement.UpdateDriver
{
    public class UpdateDriverCommandValidator : AbstractValidator<UpdateDriverCommand>
    {
        public UpdateDriverCommandValidator()
        {
            RuleFor(x => x.Driver.DriversLicenseType).IsInEnum();
        }
    }
}
