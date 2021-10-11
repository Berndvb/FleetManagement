using FluentValidation;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetVehicleDetails
{
    public class GetVehicleInfoQueryValidator : AbstractValidator<GetVehicleInfoQuery>
    {
        public GetVehicleInfoQueryValidator()
        {
            RuleFor(x => x.DriverId).GreaterThan(0);

            RuleFor(x => x.PagingParameters.PageSize).GreaterThan(0);

            RuleFor(x => x.PagingParameters.PageNumber).GreaterThan(0);
        }
    }
}
