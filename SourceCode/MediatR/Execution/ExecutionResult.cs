using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatR.Cqs.Execution
{
    public class ExecutionResult
    {
        private List<ExecutionError> Errors { get; set; }

        public ExecutionErrorType? ErrorType { get; set; }

        public bool Succes => !Errors.Any() && ErrorType == null;

        protected ExecutionResult()
        {
            Errors = new List<ExecutionError>();
        }

        protected ExecutionResult(List<ExecutionError> errors, ExecutionErrorType? errorType) : this()
        {
            Errors = errors;
            ErrorType = errorType;
        }


        public static ExecutionResult Succeeded() => new ExecutionResult();

        public static ExecutionResult NotFound(params ExecutionError[] executionErrors)
        {
            var result = new ExecutionResult
            {
                ErrorType = ExecutionErrorType.NotFound
            };

            result.Errors.AddRange(executionErrors);

            return result;
        }

        public static ExecutionResult BadRequest(params ExecutionError[] executionErrors)
        {
            var result = new ExecutionResult
            {
                ErrorType = ExecutionErrorType.BadRequest
            };

            result.Errors.AddRange(executionErrors);

            return result;
        }

        public static ExecutionResult Forbidden(params ExecutionError[] executionErrors)
        {
            var result = new ExecutionResult
            {
                ErrorType = ExecutionErrorType.Forbidden
            };

            result.Errors.AddRange(executionErrors);

            return result;
        }

        public static ExecutionResult InternalServerError(params ExecutionError[] executionErrors)
        {
            var result = new ExecutionResult
            {
                ErrorType = ExecutionErrorType.InternalServerError
            };

            result.Errors.AddRange(executionErrors);

            return result;
        }
    }
}
