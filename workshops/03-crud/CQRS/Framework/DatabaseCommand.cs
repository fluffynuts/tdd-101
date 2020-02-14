using Dapper;

namespace TDD101.Workshops.CRUD.CQRS.Framework
{
    public abstract class DatabaseCommand<T> : DatabaseConsumer, ICommand<T>
    {
        public abstract T Execute();
        public abstract void Validate();

        protected TResult Exec<TResult>(string sql, object parameters)
        {
            return Connection.QueryFirst<TResult>(sql, parameters);
        }

        protected int Exec(string sql, object parameters)
        {
            return Connection.Execute(sql, parameters);
        }
    }
}