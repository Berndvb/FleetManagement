using MediatR.Cqrs.Execution;

namespace MediatR.Cqrs.Commands
{
    public  interface ICommand<out TRes> : IRequest<TRes>
    {
    }

    public interface ICommand : IRequest<ExecutionResult>
    {
    }
}
