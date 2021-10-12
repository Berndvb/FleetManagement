using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;

namespace MediatR.Cqrs.Execution
{
    public static class ExecutionResultExtensions
    {
        public static IActionResult ToActionResult<TResult>(this TResult executionResult)
            where TResult : ExecutionResult
        {
            switch (executionResult.ErrorType)
            {
                case ExecutionErrorType.InternalServerError:
                    return CreateInternalServerErrorResult(executionResult);
                case ExecutionErrorType.BadRequest:
                    return CreateBadRequestResult(executionResult);
                case ExecutionErrorType.Forbidden:
                    return CreateForbidenResult(executionResult);
                case ExecutionErrorType.NotFound:
                    return CreateNotFoundResult(executionResult);
                default:
                    return CreateOkResult(executionResult);
            }
        }

        private static IActionResult CreateInternalServerErrorResult<TResult>(TResult executionResult)
           where TResult : ExecutionResult
        {
            if (executionResult.GetErrors().Any())
            {
                var forbiddenResult = new ObjectResult(executionResult.ToErrorExecutionResultDto());
                forbiddenResult.StatusCode = (int)HttpStatusCode.InternalServerError;
                return forbiddenResult;
            }

            return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
        }

        private static IActionResult CreateBadRequestResult<TResult>(TResult executionResult)
            where TResult : ExecutionResult
        {
            if (executionResult.GetErrors().Any())
                return new BadRequestObjectResult(executionResult.ToErrorExecutionResultDto());

            return new BadRequestResult();
        }

        private static IActionResult CreateForbidenResult<TResult>(TResult executionResult)
            where TResult : ExecutionResult
        {
            if (executionResult.GetErrors().Any())
            {
                var forbiddenResult = new ObjectResult(executionResult.ToErrorExecutionResultDto());
                forbiddenResult.StatusCode = (int)HttpStatusCode.Forbidden;
                return forbiddenResult;
            }

            return new StatusCodeResult((int)HttpStatusCode.Forbidden);
        }

        private static IActionResult CreateNotFoundResult<TResult>(TResult executionResult)
            where TResult : ExecutionResult
        {
            if (executionResult.GetErrors().Any())
                return new NotFoundObjectResult(executionResult.ToErrorExecutionResultDto());

            return new NotFoundResult();
        }

        private static IActionResult CreateOkResult<TResult>(TResult executionResult)
          where TResult : ExecutionResult
        {
            return executionResult.HasSucceeded 
                ? new OkObjectResult(executionResult)
                : new OkObjectResult(executionResult.ToErrorExecutionResultDto());
        }

        public static ExecutionResultDto ToErrorExecutionResultDto(this ExecutionResult executionResult)
        {
            return new ExecutionResultDto
            {
                Errors = executionResult.GetErrors()
            };
        }
    }
}
