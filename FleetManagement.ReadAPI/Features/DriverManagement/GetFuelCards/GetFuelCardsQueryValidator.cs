using FleetManagement.ReadAPI.Features.DriverManagement.GetFuelCardDetails;
using FluentValidation;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetFuelCards
{
    public class GetFuelCardsQueryValidator : AbstractValidator<GetFuelCardsQuery>
    {
        public GetFuelCardsQueryValidator()
        {
        }
    }
}
