using FleetManagement.Framework.Helpers;
using FluentValidation;

namespace FleetManagement.BLL.Features.Write.FuelCardManagement.UpdateFuelCard
{
    public class UpdateFuelCardCommandValidator : AbstractValidator<UpdateFuelCardCommand>
    {
        public UpdateFuelCardCommandValidator()
        {
            RuleFor(x => x.FuelCard.Id).Must(y => y > 0);

            RuleFor(x => x.FuelCard.AuthenticationType).IsInEnum();

            RuleFor(x => x.FuelCard.ExpirationDate)
                .NotNull()
                .Must(y => y.IsAfterAllphiStartdate());

            RuleFor(x => x.FuelCard.CardNumber).NotNull();
        }
    }
}
