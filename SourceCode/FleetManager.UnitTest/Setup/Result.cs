using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.UnitTest.Integration.Setup
{
    public class Result
    {
        public bool IsSuccess { get; }

        public ErrorType Type { get; }

        public object[] ErrorReplaceParams { get; set; }

        public bool IsFailure => !IsSuccess;

        protected Result(bool isSuccess, ErrorType type, object[] errorReplaceParams = null)
        {
            if (isSuccess && type != null)
                throw new InvalidOperationException();

            if (!isSuccess && type == null)
                throw new InvalidOperationException();

            IsSuccess = isSuccess;
            Type = type;
            ErrorReplaceParams = errorReplaceParams;
        }

        public static Result Fail(ErrorType type, params object[] stringReplaceParams)
        {
            return new Result(false, type, stringReplaceParams);
        }

        public static Result<T> Fail<T>(ErrorType type, params object[] stringReplaceParams)
        {
            return new Result<T>(default(T), false, type, stringReplaceParams);
        }

        public static Result Ok()
        {
            return new Result(true, null);
        }

        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(value, true, null);
        }

        public static Result Combine(params Result[] results)
        {
            foreach (var result in results)
            {
                if (result.IsFailure)
                    return result;
            }

            return Ok();
        }
    }

    public class Result<T> : Result
    {
        private readonly T _value;
        public T Value => IsSuccess ? _value : throw new InvalidOperationException();

        protected internal Result(T value, bool isSuccess, ErrorType type, object[] errorReplaceParams = null)
            : base(isSuccess, type, errorReplaceParams)
        {
            _value = value;
        }
    }
}
