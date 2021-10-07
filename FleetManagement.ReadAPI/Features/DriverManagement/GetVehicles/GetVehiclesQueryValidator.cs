using FluentValidation;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetVehicleDetails
{
    public class GetVehiclesQueryValidator : AbstractValidator<GetVehiclesQuery>
    {
        public GetVehiclesQueryValidator()
        {
            RuleFor(x => x.DriverId)
                .Must(y => int.TryParse(y, out _))
                .Must(y => int.Parse(y) > 0);
        }
    }
}
