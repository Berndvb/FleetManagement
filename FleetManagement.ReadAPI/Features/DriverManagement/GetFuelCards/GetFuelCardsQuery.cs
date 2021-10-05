using MediatR.Cqrs.Queries;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetFuelCardDetails
{
    public class GetFuelCardsQuery : IQuery<GetFuelCardsQueryResult>
    {
        public string DriverId { get; set; }
    }
}
