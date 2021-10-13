using FluentValidation;

namespace FleetManagement.BLL.Features.Read.DriverManagement.GetAllDriverOverviews
{
    public class GetAllDriverOverviewsQueryValidator : AbstractValidator<GetAllDriverOverviewsQuery>
    {
        public GetAllDriverOverviewsQueryValidator()
        {
            When(x => x.PagingParameters != null, () => {
                RuleFor(x => x.PagingParameters.PageSize).GreaterThan(0);
                RuleFor(x => x.PagingParameters.PageNumber).GreaterThan(0);
            });
        }
    }
}
