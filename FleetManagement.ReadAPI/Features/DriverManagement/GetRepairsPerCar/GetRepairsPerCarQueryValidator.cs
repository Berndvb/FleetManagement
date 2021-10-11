using FleetManagement.ReadAPI.Features.DriverManagement.GetReparationsPerCar;
using FluentValidation;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetRepairsPerCar
{
    public class GetRepairsPerCarQueryValidator : AbstractValidator<GetRepairsPerCarQuery>
    {
        public GetRepairsPerCarQueryValidator()
        {
            RuleFor(x => x.DriverId).GreaterThan(0);

            RuleFor(x => x.VehicleId).GreaterThan(0);

            RuleFor(x => x.PagingParameters.PageSize).GreaterThan(0);

            RuleFor(x => x.PagingParameters.PageNumber).GreaterThan(0);
        }
    }
}
