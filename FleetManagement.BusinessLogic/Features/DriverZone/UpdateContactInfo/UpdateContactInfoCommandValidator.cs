using System;
using FleetManagement.Framework.Helpers;
using FleetManagement.Framework.Models.Enums;
using FluentValidation;

namespace FleetManagement.BLL.Features.DriverZone.UpdateContactInfo
{
    public class UpdateContactInfoCommandValidator : AbstractValidator<UpdateContactInfoCommand>
    {
        public UpdateContactInfoCommandValidator()
        {
            RuleFor(x => x.EmailAddress)
                .NotNull()
                .Must(y => y.IsValidEmail());

            RuleFor(x => x.City).NotNull();

            RuleFor(x => x.Postcode)
                .NotNull()
                .Must(y => y.IsValidPostcodeNL() || y.IsValidPostcodeB());

            RuleFor(x => x.Street).NotNull();

            RuleFor(x => x.StreetNumber).NotNull();

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .Must(y => int.TryParse(y, out _));

            RuleFor(x => x.DriverId).GreaterThan(0);
        }
    }
}
