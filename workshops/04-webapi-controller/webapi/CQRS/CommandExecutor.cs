using System;
using System.Data;

namespace TDD101.Workshops.WebApi.CQRS
{
    public class CommandExecutor: Executor, ICommandExecutor
    {
        public CommandExecutor(Func<IDbConnection> connectionFactory)
            : base(connectionFactory)
        {
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