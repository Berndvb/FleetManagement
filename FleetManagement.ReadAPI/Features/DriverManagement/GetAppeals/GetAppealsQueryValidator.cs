using FleetManagement.ReadAPI.Features.DriverManagement.GetTotalAppeals;
using FluentValidation;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetAllAppeals
{
    public class GetAppealsQueryValidator : AbstractValidator<GetAppealsQuery>
    {
        public GetAppealsQueryValidator()
        {
            RuleFor(x => x.DriverId)
                .Must(y => int.TryParse(y, out _))
                .Must(y => int.Parse(y) > 0);
        }
    }
}
