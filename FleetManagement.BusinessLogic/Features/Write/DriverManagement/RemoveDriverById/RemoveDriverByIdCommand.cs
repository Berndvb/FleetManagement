using MediatR.Cqrs.Commands;

namespace FleetManagement.BLL.Features.Write.DriverManagement.RemoveDriverById
{
    public class RemoveDriverByIdCommand : ICommand<RemoveDriverByIdCommandResult>
    {
        public int DriverId { get; set; }
    }
}
