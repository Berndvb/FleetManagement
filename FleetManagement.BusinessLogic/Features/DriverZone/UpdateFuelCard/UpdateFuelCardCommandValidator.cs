using System;
using FleetManagement.Framework.Helpers;
using FleetManagement.Framework.Models.Enums;
using FluentValidation;

namespace FleetManagement.BLL.Features.DriverZone.UpdateFuelCard
{
    public class UpdateFuelCardCommandValidator : AbstractValidator<UpdateFuelCardCommand>
    {
        public UpdateFuelCardCommandValidator()
        {
            RuleFor(x => x.Pincode)
                .Must(y => y.Length.Equals(4))
                .Must(y => int.TryParse(y, out _));

            RuleFor(x => x.AuthenticationType).Must(y => Enum.IsDefined(typeof(AuthenticationType), y));
        }
    }
}
