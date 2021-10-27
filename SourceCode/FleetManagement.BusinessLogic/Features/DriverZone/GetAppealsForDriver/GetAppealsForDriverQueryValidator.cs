using FluentValidation;

namespace FleetManagement.BLL.Features.DriverZone.GetAppealsForDriver
{
    public class GetAppealsForDriverQueryValidator : AbstractValidator<GetAppealsForDriverQuery>
    {
        public GetAppealsForDriverQueryValidator()
        {
            RuleFor(x => x.DriverId).GreaterThan(0);

            When(x => x.PagingParameters != null, () => {
                RuleFor(x => x.PagingParameters.PageSize).GreaterThan(0);
                RuleFor(x => x.PagingParameters.PageNumber).GreaterThan(0);
            });
        }
    }
}
