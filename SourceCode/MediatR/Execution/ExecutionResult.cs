using FleetManager.EFCore.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MediatR.Cqrs.Execution
{
    public class ExecutionResult
    {
        private List<ExecutionError> Errors { get; set; }

        private List<ExecutionWarning> Warnings { get; set; }

        public ExecutionPaging ExecutionPaging { get; set; }

        public ExecutionErrorType? ErrorType { get; set; }

        public ExecutionWarningType? WarningType { get; set; }

        public bool HasSucceeded => !Errors.Any() && ErrorType == null;

        public bool HasWarnings => Warnings.Any() && WarningType != null;

        public bool HasPaging => ExecutionPaging != null;

        protected ExecutionResult()
        {
            Errors = new List<ExecutionError>();
            Warnings = new List<ExecutionWarning>();
        }

        protected ExecutionResult(List<ExecutionError> errors, ExecutionErrorType? errorType) : this()
        {
            Errors = errors;
            ErrorType = errorType;
        }

        protected ExecutionResult(List<ExecutionWarning> warnings, ExecutionWarningType? warningType) : this()
        {
            Warnings = warnings;
            WarningType = warningType;
        }

        public static ExecutionResult Succeeded() => new ExecutionResult();


        public static ExecutionResult SucceededWithNoData(params ExecutionWarning[] executionWarnings)
        {
            var result = new ExecutionResult
            {
                WarningType = ExecutionWarningType.NoData
            };

            result.Warnings.AddRange(executionWarnings);

            return result;
        }

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

        public void FillPagingInfo<T>(PaginatedList<T> list)
        {
            ExecutionPaging = new ExecutionPaging
            {
                TotalCount = list.Count,
                PageSize = list.PageSize,
                CurrentPage = list.PageNumber,
                TotalPages = list.TotalPages
            };
        }

        public List<ExecutionError> GetErrors() => Errors;

        public List<ExecutionWarning> GetWarnings() => Warnings;

        public TResult As<TResult>() where TResult : ExecutionResult
        {
            var result = (TResult)Activator.CreateInstance(typeof(TResult), true);
            result.Errors = GetErrors();
            result.ErrorType = ErrorType;
            result.Warnings = GetWarnings();
            result.WarningType = WarningType;
            result.ExecutionPaging = ExecutionPaging;

            return result;
        }
    }
}
