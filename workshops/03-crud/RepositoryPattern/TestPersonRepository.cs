using System;
using System.Data;
using System.Data.Common;
using Dapper;
using NExpect;
using NUnit.Framework;
using PeanutButter.DuckTyping.Extensions;
using PeanutButter.TempDb.MySql.Data;
using static PeanutButter.RandomGenerators.RandomValueGen;
using static NExpect.Expectations;

namespace TDD101.Workshops.CRUD.RepositoryPattern
{
    [TestFixture]
    public class TestPersonRepository
    {
        [Test]
        public void ShouldBeAbleToAddAPerson()
        {
            // Arrange
            var sut = Create(TestDatabase.OpenConnection);
            var person = GetRandom<Person>();
            // Act
            var id = sut.Create(person);
            // Assert
            using var connection = TestDatabase.OpenConnection();
            var result = connection.Query<Person>("select * from people where id = @id", new { id });
            Expect(result)
                // collection should only have one item
                .To.Contain.Only(1)
                // id on our randomly generated person is very unlikely to match
                .Intersection.Equal.To(person.DuckAs<IPersonDetails>());
        }

        private IPersonRepository Create(Func<IDbConnection> connectionFactory)
        {
            return new PersonRepository(connectionFactory);
        }
    }

    // used in testing only
    public interface IPersonDetails
    {
        string FirstName { get; }
        string LastName { get; }
        string Email { get; }
    }
}