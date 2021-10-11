using FluentValidation;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetMaintenancesPerCar
{
    public class GetMaintenancesPerCaryQueryValidator : AbstractValidator<GetMaintenancesPerCarQuery>
    {
        public GetMaintenancesPerCaryQueryValidator()
        {
        }
    }
}
