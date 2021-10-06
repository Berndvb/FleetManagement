using FleetManagement.Framework.Models.Enums;
using FluentValidation;

namespace FleetManagement.WriteAPI.Features.DriverManagement.UpdateDriver
{
    public class UpdateDriverCommandValidator : AbstractValidator<UpdateDriverCommand>
    {
        public UpdateDriverCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.DriverId)
                .Must(y => int.TryParse(y, out _))
                .Must(y => int.Parse(y) > 0);

            RuleFor(x => x.Driver.DriversLicenseType)
                .Must(y => (y & DriversLicenseTypes.All) == DriversLicenseTypes.All);
        }
    }
}
