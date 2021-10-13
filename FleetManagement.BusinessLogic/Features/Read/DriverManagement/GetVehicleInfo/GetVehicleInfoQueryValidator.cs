using FluentValidation;

namespace FleetManagement.BLL.Features.Read.DriverManagement.GetVehicleInfo
{
    public class GetVehicleInfoQueryValidator : AbstractValidator<GetVehicleInfoQuery>
    {
        public GetVehicleInfoQueryValidator()
        {
            RuleFor(x => x.DriverId).GreaterThan(0);

            When(x => x.PagingParameters != null, () => {
                RuleFor(x => x.PagingParameters.PageSize).GreaterThan(0);
                RuleFor(x => x.PagingParameters.PageNumber).GreaterThan(0);
            });
        }
    }
}
