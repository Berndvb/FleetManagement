using FleetManagement.ReadAPI.Features.DriverManagement.GetReparationsPerCar;
using FluentValidation;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetRepairsPerCar
{
    public class GetRepairsPerCarQueryValidator : AbstractValidator<GetRepairsPerCarQuery>
    {
        public GetRepairsPerCarQueryValidator()
        {
        }
    }
}
