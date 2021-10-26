using FleetManagement.Framework.Constants;
using FluentValidation;
using MediatR.Cqrs.Execution;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR.Cqrs
{
    public class ValidationBehaviour<TReq, TRes> : IPipelineBehavior<TReq, TRes> where TReq : IRequest<TRes> where TRes : ExecutionResult
    {
        private readonly IEnumerable<IValidator<TReq>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TReq>> validators)
        {
            _validators = validators;
        }

        public async Task<TRes> Handle(TReq request, CancellationToken cancellationToken, RequestHandlerDelegate<TRes> next) 
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TReq>(request);
                var validationResults = await Task.WhenAll(_validators.Select(x => x.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(x => x.Errors).Where(y => y != null).ToList();

                if (failures.Count != 0)
                {
                    var failureMessages = new StringBuilder();
                    failures.ForEach(x => failureMessages.Append(x));
                    var error = new ExecutionError(failureMessages.ToString(), Constants.ErrorCodes.InvalidRequestInput);
                    return ExecutionResult.BadRequest(error).As<TRes>();
                }
            }

            return await next();
        }
    }
}
