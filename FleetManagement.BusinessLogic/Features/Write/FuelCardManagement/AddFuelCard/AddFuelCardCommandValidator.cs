using FleetManagement.Framework.Helpers;
using FleetManagement.Framework.Models.Enums;
using FluentValidation;
using Microsoft.VisualBasic.FileIO;
using System;

namespace FleetManagement.BLL.Features.Write.FuelCardManagement.AddFuelCard
{
    public class AddFuelCardDriverCommandValidator : AbstractValidator<AddFuelCardCommand>
    {
        public AddFuelCardDriverCommandValidator()
        {
            RuleFor(x => x.FuelCard.ExpirationDate)
                .NotNull()
                .GreaterThan(Helpers.AllphiStartdate());

            RuleFor(x => x.FuelCard.FuelCardOptions).NotNull();

            RuleFor(x => x.FuelCard.Pincode)
                .Must(y => y.Length.Equals(4))
                .Must(y => int.TryParse(y, out _));

            RuleFor(x => x.FuelCard.AuthenticationType).Must(y => Enum.IsDefined(typeof(AuthenticationType), y));

            RuleFor(x => x.FuelCard.FuelCardOptions.Fueltype).Must(y => Enum.IsDefined(typeof(FieldType), y));

        }
    }
}
