using FleetManagement.Framework.Helpers;
using FluentValidation;

namespace FleetManagement.WriteAPI.Features.FuelCardManagement.UpdateFuelCard
{
    public class UpdateFuelCardCommandValidator : AbstractValidator<UpdateFuelCardCommand>
    {
        public UpdateFuelCardCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.FuelCardId)
                .Must(y => int.TryParse(y, out _))
                .Must(y => int.Parse(y) > 0);

            RuleFor(x => x.FuelCard.Id)
                .Must(y => y > 0);

            RuleFor(x => x.FuelCard.AuthenticationType)
                .Must(y => y > 0 && (int)y < 3);

            RuleFor(x => x.FuelCard.ExpirationDate)
                .NotNull()
                .Must(y => y.AfterAllphiStartdate());

            RuleFor(x => x.FuelCard.CardNumber)
                .NotNull();
        }
    }
}
