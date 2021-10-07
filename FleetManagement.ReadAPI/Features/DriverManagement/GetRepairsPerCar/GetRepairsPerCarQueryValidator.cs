using FleetManagement.ReadAPI.Features.DriverManagement.GetReparationsPerCar;
using FluentValidation;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetRepairsPerCar
{
    public class GetRepairsPerCarQueryValidator : AbstractValidator<GetRepairsPerCarQuery>
    {
        public GetRepairsPerCarQueryValidator()
        {
            RuleFor(x => x.DriverId)
                .Must(y => int.TryParse(y, out _))
                .Must(y => int.Parse(y) > 0);

            RuleFor(x => x.VehicleId)
                .Must(y => int.TryParse(y, out _))
                .Must(y => int.Parse(y) > 0);
        }
    }
}
