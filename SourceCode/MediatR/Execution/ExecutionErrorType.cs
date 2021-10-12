namespace MediatR.Cqrs.Execution
{
    public enum ExecutionErrorType
    {
        InternalServerError = 1,
        BadRequest = 2,
        NotFound = 3,
        Forbidden = 4
    }
}
