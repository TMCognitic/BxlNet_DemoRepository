using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.CQS.Queries
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQueryDescription<TResult>
        where TResult : class
    {
        IQueryResult<TResult> Execute(TQuery query);
    }
}
