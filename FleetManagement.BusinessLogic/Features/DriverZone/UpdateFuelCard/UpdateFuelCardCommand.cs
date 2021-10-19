using FleetManagement.Framework.Models.Enums;
using MediatR.Cqrs.Commands;
using Newtonsoft.Json;

namespace FleetManagement.BLL.Features.DriverZone.UpdateFuelCard
{
    public class UpdateFuelCardCommand : ICommand<UpdateFuelCardCommandResult>
    {
        [JsonIgnore]
        public int FuelCardId { get; set; }

        public string Pincode { get; set; }

        public AuthenticationType AuthenticationType { get; set; }

        public bool Blocked { get; set; }

        public UpdateFuelCardCommand WithId(int id)
        {
            FuelCardId = id;
            return this;
        }
    }
}
