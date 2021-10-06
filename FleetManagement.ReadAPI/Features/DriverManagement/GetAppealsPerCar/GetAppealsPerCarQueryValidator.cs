using FluentValidation;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetAppealsPerCar
{
    public class GetAppealsPerCarQueryValidator : AbstractValidator<GetAppealsPerCarQuery>
    {
        public GetAppealsPerCarQueryValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.DriverId)
                .Must(y => int.TryParse(y, out _))
                .Must(y => int.Parse(y) > 0);

            RuleFor(x => x.VehicleId)
                .Must(y => int.TryParse(y, out _))
                .Must(y => int.Parse(y) > 0);
        }
    }
}
