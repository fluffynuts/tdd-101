using NUnit.Framework;
using TDD101.Workshops.CRUD.CQRS.Framework;

namespace TDD101.Workshops.CRUD.CQRS
{
    public abstract class CQRSBaseTest
    {
        protected ICommandExecutor CommandExecutor { get; private set; }
        protected IQueryExecutor QueryExecutor { get; private set; }

        [OneTimeSetUp]
        public void Setup()
        {
            CommandExecutor = new CommandExecutor(TestDatabase.OpenConnection);
            QueryExecutor = new QueryExecutor(TestDatabase.OpenConnection);
        }
    }
}