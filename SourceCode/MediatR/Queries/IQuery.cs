using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatR.Queries
{
    public interface IQuery<out TRes> : IRequest<TRes>
    {
    }

    //public interface IQuery : IRequest<INSERTRESULT>
    //{
    //}
}
