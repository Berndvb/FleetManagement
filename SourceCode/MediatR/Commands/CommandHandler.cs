using MediatR.Cqrs.Execution;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR.Cqrs.Commands
{
    public abstract class CommandHandler<TReq, TRes> : ICommandHandler<TReq, TRes>
        where TRes : ExecutionResult
        where TReq : ICommand<TRes>
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
    }

    //public abstract class CommandHandler<TReq> : ICommandHandler<TReq>
    //    where TReq : ICommand
    //{
    //    public abstract Task<ExecutionResult> Handle(TReq request, CancellationToken cancellationToken);

    //    protected ExecutionResult NotFound(ExecutionError error = null)
    //    {
    //        return ExecutionResult.NotFound(error);
    //    }

    //    protected ExecutionResult BadRequest(ExecutionError error = null)
    //    {
    //        return ExecutionResult.BadRequest(error);
    //    }

    //    protected ExecutionResult Forbidden()
    //    {
    //        return ExecutionResult.Forbidden();
    //    }
    //}
}
