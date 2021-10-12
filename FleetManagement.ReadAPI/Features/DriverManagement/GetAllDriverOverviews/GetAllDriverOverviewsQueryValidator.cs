using FluentValidation;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetAllDriverOverviews
{
    public class GetAllDriverOverviewsQueryValidator : AbstractValidator<GetAllDriverOverviewsQuery>
    {
        public GetAllDriverOverviewsQueryValidator()
        {
            RuleFor(x => x.PagingParameters.PageSize).GreaterThan(0);

            RuleFor(x => x.PagingParameters.PageNumber).GreaterThan(0);
        }
    }
}
