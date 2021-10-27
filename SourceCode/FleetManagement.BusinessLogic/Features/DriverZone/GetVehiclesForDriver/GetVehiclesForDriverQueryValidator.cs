using FluentValidation;

namespace FleetManagement.BLL.Features.DriverZone.GetVehiclesForDriver
{
    public class GetVehiclesForDriverQueryValidator : AbstractValidator<GetVehiclesForDriverQuery>
    {
        public GetVehiclesForDriverQueryValidator()
        {
            RuleFor(x => x.DriverId).GreaterThan(0);

            When(x => x.PagingParameters != null, () => {
                RuleFor(x => x.PagingParameters.PageSize).GreaterThan(0);
                RuleFor(x => x.PagingParameters.PageNumber).GreaterThan(0);
            });

        }
    }
}
