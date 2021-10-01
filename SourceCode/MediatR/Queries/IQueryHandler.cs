using MediatR.Cqs.Execution;
using MediatR.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatR.Cqs.Queries
{
    public interface IQueryHandler<in TQuery, TRes> : IRequestHandler<TQuery, TRes>
        where TQuery : IQuery<TRes>
        where TRes : ExecutionResult
    {
    }
}
