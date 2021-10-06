using FleetManagement.Framework.Models.Enums;
using FluentValidation;

namespace FleetManagement.WriteAPI.Features.DriverManagement.AddDriver
{
    public class AddDriverCommandValidator : AbstractValidator<AddDriverCommand>
    {
        public AddDriverCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Driver.Id)
                .Must(y => y > 0);

            RuleFor(x => x.Driver.DriversLicenseType)
                .Must(y => (y & DriversLicenseTypes.All) == DriversLicenseTypes.All);
        }
    }
}
