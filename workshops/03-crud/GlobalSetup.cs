using System.Data;
using System.Data.Common;
using NUnit.Framework;
using PeanutButter.TempDb.MySql.Data;

namespace TDD101.Workshops.CRUD
{
    public static class TestDatabase
    {
        public static TempDBMySql Database { get; set; }
        
        public static IDbConnection OpenConnection() => Database.OpenConnection();
    }

    [SetUpFixture]
    public class GlobalSetup
    {
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            // enable snake_case at the database to translate to TitleCase in C#
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            TestDatabase.Database = new TempDBMySql();
            using var migrator = new MySqlSimpleMigrator(TestDatabase.Database.OpenConnection());
        }

        [OneTimeTearDown]
        public void OneTimeTeardown()
        {
            TestDatabase.Database?.Dispose();
            TestDatabase.Database = null;
        }
    }
}