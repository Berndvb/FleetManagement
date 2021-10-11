using FluentValidation;

namespace FleetManagement.ReadAPI.Features.AppealManagement.GetAllAppeals
{
    public class GetAllAppealsQueryValidator : AbstractValidator<GetAllAppealsQuery>
    {
        public GetAllAppealsQueryValidator()
        {
            RuleFor(x => x.AppealStatus).Must(y => y >= 0 && (int)y < 4);
        }
    }
}
