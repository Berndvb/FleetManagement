﻿using System;
using FleetManagement.Framework.Helpers;
using FleetManagement.Framework.Models.Enums;
using FluentValidation;

namespace FleetManagement.BLL.Features.DriverZone.UpdateFuelCard
{
    public class UpdateFuelCardCommandValidator : AbstractValidator<UpdateFuelCardCommand>
    {
        public UpdateFuelCardCommandValidator()
        {
            RuleFor(x => x.FuelCard.Id).Must(y => y > 0);

            RuleFor(x => x.FuelCard.ExpirationDate)
               .NotNull()
               .GreaterThan(Helpers.AllphiStartdate());

            RuleFor(x => x.FuelCard.FuelCardOptions).NotNull();

            RuleFor(x => x.FuelCard.Pincode)
                .Must(y => y.Length.Equals(4))
                .Must(y => int.TryParse(y, out _));

            RuleFor(x => x.FuelCard.CardNumber)
                .Must(y => y.Length.Equals(8))
                .Must(y => int.TryParse(y, out _));

            RuleFor(x => x.FuelCard.AuthenticationType).Must(y => Enum.IsDefined(typeof(AuthenticationType), y));

            RuleFor(x => x.FuelCard.FuelCardOptions.Fueltype).Must(y => Enum.IsDefined(typeof(FuelType), y));
        }
    }
}