using FluentValidation;

namespace FleetManagement.BLL.Features.Read.FuelcardManagement.GetAllFuelCards
{
    public class GetAllFuelCardsQueryValidator : AbstractValidator<GetAllFuelCardsQuery>
    {
        public GetAllFuelCardsQueryValidator()
        {
            When(x => x.PagingParameters != null, () => {
                RuleFor(x => x.PagingParameters.PageSize).GreaterThan(0);
                RuleFor(x => x.PagingParameters.PageNumber).GreaterThan(0);
            });
        }
    }
}
