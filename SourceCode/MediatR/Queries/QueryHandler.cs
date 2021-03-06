using MediatR.Cqrs.Execution;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR.Cqrs.Queries
{
    public abstract class QueryHandler<TReq, TRes> : IQueryHandler<TReq, TRes>
      where TRes : ExecutionResult
      where TReq : IQuery<TRes>
    {
        public abstract Task<TRes> Handle(TReq request, CancellationToken cancellationToken);

        protected TRes NotFound(ExecutionError error = null)
        {
            return ExecutionResult.NotFound(error).As<TRes>();
        }

        protected TRes BadRequest(ExecutionError error = null)
        {
            return ExecutionResult.BadRequest(error).As<TRes>();
        }

        protected TRes Forbidden(ExecutionError error = null)
        {
            return ExecutionResult.Forbidden(error).As<TRes>();
        }

        protected TRes InternalServerError(ExecutionError error = null)
        {
            return ExecutionResult.InternalServerError(error).As<TRes>();
        }

        protected TRes SucceededWithNoData(ExecutionWarning warning = null)
        {
            return ExecutionResult.SucceededWithNoData(warning).As<TRes>();
        }
    }
}
