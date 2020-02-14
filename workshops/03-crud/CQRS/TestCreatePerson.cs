using Dapper;
using NUnit.Framework;
using static PeanutButter.RandomGenerators.RandomValueGen;
using NExpect;
using PeanutButter.DuckTyping.Extensions;
using TDD101.Workshops.CRUD.RepositoryPattern;
using static NExpect.Expectations;

namespace TDD101.Workshops.CRUD.CQRS
{
    [TestFixture]
    public class TestCreatePerson: CQRSBaseTest
    {
        [TestFixture]
        public class WhenAllPropertiesSet: TestCreatePerson
        {
            [Test]
            public void ShouldBeAbleToAddAPerson()
            {
                // Arrange
                var person = GetRandom<Person>();
                var sut = Create(person);
                // Act
                var id = CommandExecutor.Execute(sut);
                // Assert
                using var connection = TestDatabase.OpenConnection();
                var result = connection.Query<Person>("select * from people where id = @id", new { id });
                Expect(result)
                    // collection should only have one item
                    .To.Contain.Only(1)
                    // id on our randomly generated person is very unlikely to match
                    .Intersection.Equal.To(person.DuckAs<IPersonDetails>());
            }
        }

        private static CreatePerson Create(Person person)
        {
            return new CreatePerson(person);
        }
    }
}