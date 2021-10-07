using FluentValidation;
using FleetManagement.Framework.Helpers;

namespace FleetManagement.WriteAPI.Features.DriverManagement.AddDriver
{
    public class AddDriverCommandValidator : AbstractValidator<AddDriverCommand>
    {
        public AddDriverCommandValidator()
        {
            RuleFor(x => x.Driver.Id).Must(y => y > 0);

            RuleFor(x => x.Driver.DriversLicenseType).IsInEnum();

            RuleFor(x => x.Driver.Contactinfo).NotNull();
            RuleFor(x => x.Driver.Contactinfo.EmailAddress).NotNull();
            RuleFor(x => x.Driver.Contactinfo.EmailAddress).Must(y => y.IsValidEmail());

            RuleFor(x => x.Driver.Contactinfo.Address).NotNull();
            RuleFor(x => x.Driver.Contactinfo.Address.City).NotNull();
            RuleFor(x => x.Driver.Contactinfo.Address.Postcode).NotNull();
            RuleFor(x => x.Driver.Contactinfo.Address.Street).NotNull();
            RuleFor(x => x.Driver.Contactinfo.Address.StreetNumber).NotNull();

            RuleFor(x => x.Driver.Identity.DateOfBirth).NotNull();
            RuleFor(x => x.Driver.Identity.FirstName).NotNull();
            RuleFor(x => x.Driver.Identity.Name).NotNull();
            RuleFor(x => x.Driver.Identity.NationalInsuranceNumber).NotNull();

        }
    }
}
