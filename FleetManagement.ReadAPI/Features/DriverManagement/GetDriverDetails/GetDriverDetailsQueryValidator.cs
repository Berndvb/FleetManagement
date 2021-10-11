using FluentValidation;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetDriverDetails
{
    public class GetDriverDetailsQueryValidator : AbstractValidator<GetDriverDetailsQuery>
    {
        public GetDriverDetailsQueryValidator()
        {
            RuleFor(x => x.DriverId).GreaterThan(0);
        }
    }
}
