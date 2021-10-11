using FleetManagement.ReadAPI.Features.DriverManagement.GetTotalAppeals;
using FluentValidation;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetAllAppeals
{
    public class GetAppealsQueryValidator : AbstractValidator<GetAppealsQuery>
    {
        public GetAppealsQueryValidator()
        {
            RuleFor(x => x.DriverId).GreaterThan(0);

            RuleFor(x => x.PagingParameters.PageSize).GreaterThan(0);

            RuleFor(x => x.PagingParameters.PageNumber).GreaterThan(0);
        }
    }
}
