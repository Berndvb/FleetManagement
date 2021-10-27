using System.Collections.Generic;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Execution;

namespace FleetManagement.BLL.Features.AdministrativeZone.FuelCardManagement.GetFuelCards
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
