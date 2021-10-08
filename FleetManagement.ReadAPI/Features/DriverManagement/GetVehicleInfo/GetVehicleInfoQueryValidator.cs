using FluentValidation;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetVehicleDetails
{
    public class GetVehicleInfoQueryValidator : AbstractValidator<GetVehicleInfoQuery>
    {
        public GetVehicleInfoQueryValidator()
        {
            RuleFor(x => x.DriverId)
                .Must(y => int.TryParse(y, out _))
                .Must(y => int.Parse(y) > 0);
        }
    }
}
