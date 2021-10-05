namespace MediatR.Cqrs.Execution
{
    public enum ExecutionErrorType
    {
        InternalServerError,
        BadRequest,
        NotFound,
        Forbidden
    }
}
