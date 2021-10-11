using FleetManagement.ReadAPI.Features.DriverManagement.GetFuelCardDetails;
using FluentValidation;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetFuelCards
{
    public class GetFuelCardsQueryValidator : AbstractValidator<GetFuelCardsQuery>
    {
        public GetFuelCardsQueryValidator()
        {
            RuleFor(x => x.DriverId).GreaterThan(0);

            RuleFor(x => x.PagingParameters.PageSize).GreaterThan(0);

            RuleFor(x => x.PagingParameters.PageNumber).GreaterThan(0);
        }
    }
}
