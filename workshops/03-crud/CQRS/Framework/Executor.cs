using System;
using System.Data;

namespace TDD101.Workshops.CRUD.CQRS.Framework
{
    public abstract class Executor
    {
        protected readonly Func<IDbConnection> _connectionFactory;

        public Executor(Func<IDbConnection> connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        
        public T Execute<T>(ICommand<T> command)
        {
            if (command is IDatabaseConsumer databaseConsumer)
            {
                var connection = _connectionFactory();
                databaseConsumer.Connect(connection);
            }

            command.Validate();
            return command.Execute();
        }
    }
}