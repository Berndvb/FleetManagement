using System.Collections.Generic;

namespace MediatR.Cqs.Execution
{
    public class ExecutionResultDto
    {
        public List<ExecutionError> Errors { get; set; }
    }
}
