using FleetManagement.Framework.Models.Dtos;
using MediatR.Cqrs.Execution;
using System.Collections.Generic;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetFuelCardDetails
{
    public class GetFuelCardsQueryResult : ExecutionResult
    {
        public List<FuelCardDto> FuelCards { get; }

        public GetFuelCardsQueryResult(List<FuelCardDto> fuelCards)
        {
            FuelCards = fuelCards;
        }

        private GetFuelCardsQueryResult()
        {
        }
    }
}
