using System.Collections.Generic;
using FleetManagement.BLL.Models.Dtos.ReadDtos;
using MediatR.Cqrs.Execution;

namespace FleetManagement.BLL.Features.DriverZone.GetFuelCardsForDriver
{
    public class GetFuelCardsForDriverQueryResult : ExecutionResult
    {
        public List<FuelCardDto> FuelCards { get; }

        public GetFuelCardsForDriverQueryResult(List<FuelCardDto> fuelCards)
        {
            FuelCards = fuelCards;
        }

        private GetFuelCardsForDriverQueryResult()
        {
        }
    }
}
