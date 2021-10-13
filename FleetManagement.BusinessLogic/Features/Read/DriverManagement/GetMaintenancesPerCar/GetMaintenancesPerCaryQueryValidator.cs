using FluentValidation;

namespace FleetManagement.BLL.Features.Read.DriverManagement.GetMaintenancesPerCar
{
    public class GetMaintenancesPerCaryQueryValidator : AbstractValidator<GetMaintenancesPerCarQuery>
    {
        public GetMaintenancesPerCaryQueryValidator()
        {
            RuleFor(x => x.DriverId).GreaterThan(0);

            RuleFor(x => x.VehicleId).GreaterThan(0);

            When(x => x.PagingParameters != null, () => {
                RuleFor(x => x.PagingParameters.PageSize).GreaterThan(0);
                RuleFor(x => x.PagingParameters.PageNumber).GreaterThan(0);
            });
        }
    }
}
