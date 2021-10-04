using MediatR.Cqs.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatR.Commands
{
    public  interface ICommand<out TRes> : IRequest<TRes>
    {
    }

    public interface ICommand : IRequest<ExecutionResult>
    {
    }
}
