using FleetManagement.Framework.Models.Dtos;
using MediatR.Cqrs.Execution;
using System.Collections.Generic;

namespace FleetManagement.ReadAPI.Features.FuelcardManagement.GetAllFuelCards
{
    public class GetAllFuelCardsQueryResult : ExecutionResult
    {
        public List<FuelCardDto> FuelCards { get; }

        public GetAllFuelCardsQueryResult(List<FuelCardDto> fuelCards)
        {
            FuelCards = fuelCards;
        }

        private GetAllFuelCardsQueryResult()
        {
        }
    }
}
