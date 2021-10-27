using FluentValidation;

namespace FleetManagement.BLL.Features.DriverZone.GetFuelCardsForDriver
{
    public class GetFuelCardsForDriverQueryValidator : AbstractValidator<GetFuelCardsForDriverQuery>
    {
        public GetFuelCardsForDriverQueryValidator()
        {
            RuleFor(x => x.DriverId).GreaterThan(0);

            When(x => x.PagingParameters != null, () => {
                RuleFor(x => x.PagingParameters.PageSize).GreaterThan(0);
                RuleFor(x => x.PagingParameters.PageNumber).GreaterThan(0);
            });
        }
    }
}
