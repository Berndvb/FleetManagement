using FluentValidation;

namespace FleetManagement.BLL.Features.Read.DriverManagement.GetDriverDetails
{
    public class GetDriverDetailsQueryValidator : AbstractValidator<GetDriverDetailsQuery>
    {
        public GetDriverDetailsQueryValidator()
        {
            RuleFor(x => x.DriverId).GreaterThan(0);
        }
    }
}
