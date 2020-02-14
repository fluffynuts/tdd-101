using System;
using System.Data;

namespace TDD101.Workshops.WebApi.CQRS
{
    public abstract class Executor
    {
        protected readonly Func<IDbConnection> _connectionFactory;

        public Executor(Func<IDbConnection> connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
    }
}