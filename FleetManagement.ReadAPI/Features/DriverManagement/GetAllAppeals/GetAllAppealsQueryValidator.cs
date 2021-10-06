using FleetManagement.ReadAPI.Features.DriverManagement.GetTotalAppeals;
using FluentValidation;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetAllAppeals
{
    public class GetAllAppealsQueryValidator : AbstractValidator<GetAllAppealsQuery>
    {
        public GetAllAppealsQueryValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.DriverId)
                .Must(y => int.TryParse(y, out _))
                .Must(y => int.Parse(y) > 0);
        }
    }
}
