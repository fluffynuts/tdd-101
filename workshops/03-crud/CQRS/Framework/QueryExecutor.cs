using System;
using System.Data;

namespace TDD101.Workshops.CRUD.CQRS.Framework
{
    public class QueryExecutor: Executor, IQueryExecutor
    {
        public QueryExecutor(Func<IDbConnection> connectionFactory)
            : base(connectionFactory)
        {
        }

    }
}