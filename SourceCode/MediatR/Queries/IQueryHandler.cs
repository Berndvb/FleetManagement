using MediatR.Cqrs.Execution;

namespace MediatR.Cqrs.Queries
{
    public interface IQueryHandler<in TQuery, TRes> : IRequestHandler<TQuery, TRes>
        where TQuery : IQuery<TRes>
        where TRes : ExecutionResult
    {
    }
}
