using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR.Cqrs
{
    public class ValidationBehaviour<TReq, TRes> : IPipelineBehavior<TReq, TRes> where TReq : IRequest<TRes>
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
                    throw new ValidationException(failures);
            }

            return await next();
        }
    }
}
