using System.Data;

namespace TDD101.Workshops.CRUD.CQRS.Framework
{
    public interface IDatabaseConsumer
    {
        void Connect(IDbConnection connection);
    }
}