using System;
using System.Data;

namespace TDD101.Workshops.CRUD.CQRS.Framework
{
    public class CommandExecutor: Executor, ICommandExecutor
    {
        public CommandExecutor(Func<IDbConnection> connectionFactory)
            : base(connectionFactory)
        {
        }
    }
}