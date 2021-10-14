using FluentValidation;

namespace FleetManagement.BLL.Features.Read.VehicleManagement.GetAllVehicles
{
    public class GetVehiclesQueryValidator : AbstractValidator<GetVehiclesQuery>
    {
        public GetVehiclesQueryValidator()
        {
            When(x => x.PagingParameters != null, () => {
                RuleFor(x => x.PagingParameters.PageSize).GreaterThan(0);
                RuleFor(x => x.PagingParameters.PageNumber).GreaterThan(0);
            });
        }
    }
}
