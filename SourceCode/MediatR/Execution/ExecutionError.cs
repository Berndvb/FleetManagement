namespace MediatR.Cqrs.Execution
{
    public class ExecutionError
    {
        public string Message { get; set; }

        public string  Code { get; set; }

        public ExecutionError(string message, string code)
        {
            Message = message;
            Code = code;
        }
    }
}
