using System.Text.Json.Serialization;
using FleetManagement.Framework.Models.Enums;
using MediatR.Cqrs.Commands;

namespace FleetManagement.BLL.Features.DriverZone.UpdateFuelCardInfo
{
    public class UpdateFuelCardInfoCommand : ICommand<UpdateFuelCardInfoCommandResult>
    {
        [JsonIgnore]
        public int FuelCardId { get; set; }

        public string Pincode { get; set; }

        public AuthenticationType AuthenticationType { get; set; }

        public bool Blocked { get; set; }

        public UpdateFuelCardInfoCommand WithId(int id)
        {
            FuelCardId = id;
            return this;
        }
    }
}
