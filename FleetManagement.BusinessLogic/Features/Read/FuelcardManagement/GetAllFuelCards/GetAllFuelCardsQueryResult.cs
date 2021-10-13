using System.Collections.Generic;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Execution;

namespace FleetManagement.BLL.Features.Read.FuelcardManagement.GetAllFuelCards
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
