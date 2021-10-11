using FluentValidation;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetVehicleDetails
{
    public class GetVehicleInfoQueryValidator : AbstractValidator<GetVehicleInfoQuery>
    {
        public GetVehicleInfoQueryValidator()
        {
        }
    }
}
