using FluentValidation;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetVehicleDetails
{
    public class GetVehicleDetailsQueryValidator : AbstractValidator<GetVehicleDetailsQuery>
    {
        public GetVehicleDetailsQueryValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.DriverId)
                .Must(y => int.TryParse(y, out _))
                .Must(y => int.Parse(y) > 0);
        }
    }
}
