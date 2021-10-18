﻿using System;
using FleetManagement.Framework.Helpers;
using FleetManagement.Framework.Models.Enums;
using FluentValidation;

namespace FleetManagement.BLL.Features.DriverZone.UpdateContactInfo
{
    public class UpdateContactInfoCommandValidator : AbstractValidator<UpdateContactInfoCommand>
    {
        public UpdateContactInfoCommandValidator()
        {
            RuleFor(x => x.Driver.DriversLicenseType).Must(y => Enum.IsDefined(typeof(DriversLicenseType), y));

            RuleFor(x => x.Driver.Contactinfo).NotNull();

            RuleFor(x => x.Driver.Contactinfo.EmailAddress)
                .NotNull()
                .Must(y => y.IsValidEmail());

            RuleFor(x => x.Driver.Contactinfo.Address).NotNull();

            RuleFor(x => x.Driver.Contactinfo.Address.City).NotNull();

            RuleFor(x => x.Driver.Contactinfo.Address.Postcode)
                .NotNull()
                .Must(y => y.IsValidPostcodeNL() || y.IsValidPostcodeB());

            RuleFor(x => x.Driver.Contactinfo.Address.Street).NotNull();

            RuleFor(x => x.Driver.Contactinfo.Address.StreetNumber).NotNull();

            RuleFor(x => x.Driver.Identity.DateOfBirth)
                .NotNull()
                .Must(y => y.IsValidDateOfBirth(18, 100));

            RuleFor(x => x.Driver.Identity.FirstName).NotNull();

            RuleFor(x => x.Driver.Identity.Name).NotNull();

            RuleFor(x => x.Driver.Identity.NationalInsuranceNumber)
                .NotNull()
                .Must(y => y.IsValidNationalInsuranceNumber());
        }
    }
}