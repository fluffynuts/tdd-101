using System;
using System.Data;

namespace TDD101.Workshops.WebApi.CQRS
{
    public class QueryExecutor: Executor, IQueryExecutor
    {
        public QueryExecutor(Func<IDbConnection> connectionFactory)
            : base(connectionFactory)
        {
        }

        public T Execute<T>(IQuery<T> query)
        {
            if (query is IDatabaseConsumer databaseConsumer)
            {
                var connection = _connectionFactory();
                databaseConsumer.Connect(connection);
            }

            query.Validate();
            return query.Execute();
        }
    }
}