using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;

namespace TDD101.Workshops.CRUD.CQRS.Framework
{
    public abstract class DatabaseQuery<T> : DatabaseConsumer, IQuery<T>
    {
        public abstract T Execute();

        public abstract void Validate();
    }
}