namespace MediatR.Cqrs.Execution
{
    public class ExecutionWarning
    {
        public string Message { get; set; }

        public string Code { get; set; }

        public ExecutionWarning(string message, string code)
        {
            Message = message;
            Code = code;
        }

        public ExecutionWarning()
        {
        }
    }
}
