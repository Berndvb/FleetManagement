using System.Collections.Generic;

namespace MediatR.Cqrs.Execution
{
    public class ExecutionResultDto
    {
        public List<ExecutionError> Errors { get; set; }
    }
}
