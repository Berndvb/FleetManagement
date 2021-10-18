using FluentValidation;

namespace FleetManagement.BLL.Features.DriverZone.GetDriverOverviews
{
    public class GetDriverOverviewsQueryValidator : AbstractValidator<GetDriverOverviewsQuery>
    {
        public GetDriverOverviewsQueryValidator()
        {
            When(x => x.PagingParameters != null, () => {
                RuleFor(x => x.PagingParameters.PageSize).GreaterThan(0);
                RuleFor(x => x.PagingParameters.PageNumber).GreaterThan(0);
            });
        }
    }
}
