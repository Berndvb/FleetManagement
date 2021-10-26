using MediatR.Cqrs.Execution;

namespace MediatR.Cqrs.Commands
{
    public interface ICommandHandler<in TCommand, TRes> : IRequestHandler<TCommand, TRes>
        where TCommand : ICommand<TRes>
        where TRes : ExecutionResult
    { 
    }
}
