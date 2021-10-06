using FleetManagement.ReadAPI.Features.DriverManagement.GetFuelCardDetails;
using FluentValidation;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetFuelCards
{
    public class GetFuelCardsQueryValidator : AbstractValidator<GetFuelCardsQuery>
    {
        public GetFuelCardsQueryValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.DriverId)
                .Must(y => int.TryParse(y, out _))
                .Must(y => int.Parse(y) > 0);
        }
    }
}
