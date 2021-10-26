using MediatR.Cqrs.Execution;

namespace MediatR.Cqrs.Queries
{
    public interface IQuery<out TRes> : IRequest<TRes>
        where TRes : ExecutionResult
    {
    }
}
