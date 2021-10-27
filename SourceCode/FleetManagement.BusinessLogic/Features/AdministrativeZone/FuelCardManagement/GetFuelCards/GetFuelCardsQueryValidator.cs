using FluentValidation;

namespace FleetManagement.BLL.Features.AdministrativeZone.FuelCardManagement.GetFuelCards
{
    public class GetFuelCardsQueryValidator : AbstractValidator<GetFuelCardsQuery>
    {
        public GetFuelCardsQueryValidator()
        {
            When(x => x.PagingParameters != null, () => {
                RuleFor(x => x.PagingParameters.PageSize).GreaterThan(0);
                RuleFor(x => x.PagingParameters.PageNumber).GreaterThan(0);
            });
        }
    }
}
