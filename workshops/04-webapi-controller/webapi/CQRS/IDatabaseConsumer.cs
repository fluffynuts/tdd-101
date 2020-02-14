using System.Data;

namespace TDD101.Workshops.WebApi.CQRS
{
    public interface IDatabaseConsumer
    {
        void Connect(IDbConnection connection);
    }
}