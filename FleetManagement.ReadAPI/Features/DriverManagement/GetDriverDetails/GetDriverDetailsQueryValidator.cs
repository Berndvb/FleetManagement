using FluentValidation;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetDriverDetails
{
    public class GetDriverDetailsQueryValidator : AbstractValidator<GetDriverDetailsQuery>
    {
        public GetDriverDetailsQueryValidator()
        {
        }
    }
}
