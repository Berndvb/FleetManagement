using FleetManagement.Framework.Helpers;
using FleetManagement.Framework.Models.Enums;
using FluentValidation;
using System;

namespace FleetManagement.BLL.Features.Write.FuelCardManagement.AddFuelCard
{
    public class AddFuelCardCommandValidator : AbstractValidator<AddFuelCardCommand>
    {
        public AddFuelCardCommandValidator()
        {
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
