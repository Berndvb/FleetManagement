using FluentValidation;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetDriverDetails
{
    public class GetDriverDetailsQueryValidator : AbstractValidator<GetDriverDetailsQuery>
    {
        public GetDriverDetailsQueryValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.DriverId)
                .Must(y => int.TryParse(y, out _))
                .Must(y => int.Parse(y) > 0);
        }
    }
}
