using MediatR.Cqrs.Commands;

namespace FleetManagement.WriteAPI.Features.DriverManagement.RemoveDriver
{
    public class RemoveDriverByIdCommand : ICommand<RemoveDriverByIdCommandResult>
    {
        public int DriverId { get; set; }
    }
}
