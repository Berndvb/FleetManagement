using FleetManagement.Framework.Helpers;
using FleetManagement.Framework.Models.Enums;
using FluentValidation;
using System;

namespace FleetManagement.BLL.Features.Write.DriverManagement.AddDriver
{
    public class AddDriverCommandValidator : AbstractValidator<AddDriverCommand>
    {
        public AddDriverCommandValidator()
        {
            RuleFor(x => x.Driver.DriversLicenseType).Must(y => Enum.IsDefined(typeof(DriversLicenseType), y));

            RuleFor(x => x.Driver.Contactinfo).NotNull();

            RuleFor(x => x.Driver.Contactinfo.EmailAddress)
                .NotNull()
                .Must(y => y.IsValidEmail());

            RuleFor(x => x.Driver.Contactinfo.Address).NotNull();

            RuleFor(x => x.Driver.Contactinfo.Address.City).NotNull();

            RuleFor(x => x.Driver.Contactinfo.Address.Postcode).NotNull();

            RuleFor(x => x.Driver.Contactinfo.Address.Street).NotNull();

            RuleFor(x => x.Driver.Contactinfo.Address.StreetNumber).NotNull();

            RuleFor(x => x.Driver.Identity.DateOfBirth)
                .NotNull()
                .Must(y => y.IsValidDateOfBirth(18, 100));

            RuleFor(x => x.Driver.Identity.FirstName).NotNull();

            RuleFor(x => x.Driver.Identity.Name).NotNull();

            RuleFor(x => x.Driver.Identity.NationalInsuranceNumber)
                .NotNull()
                .Must(y => y.IsValidNationalInsuranceNumber())
                .WithMessage("Insurance number is invalid.");
        }
    }
}
