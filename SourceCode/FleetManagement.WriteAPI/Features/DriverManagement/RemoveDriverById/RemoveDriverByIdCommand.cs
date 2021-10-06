using MediatR.Cqrs.Commands;

namespace FleetManagement.WriteAPI.Features.DriverManagement.RemoveDriver
{
    public class RemoveDriverByIdCommand : ICommand<RemoveDriverByIdCommandResult>
    {
        public string DriverId { get; set; }
    }
}
