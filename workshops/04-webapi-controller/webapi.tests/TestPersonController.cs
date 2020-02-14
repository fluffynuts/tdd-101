using NSubstitute;
using NUnit.Framework;
using TDD101.Workshops.WebApi.Controllers;
using TDD101.Workshops.WebApi.CQRS;

namespace TDD101.Workshops.WebApi.Tests
{
    [TestFixture]
    public class TestPersonController
    {
        [TestFixture]
        public class Find: TestPersonController
        {
            [TestFixture]
            public class WhenPersonExists
            {
                [Test]
                public void ShouldReturnThatPerson()
                {
                    // Arrange
                    // Act
                    // Assert
                }
            }

            [TestFixture]
            public class WhenPersonNotFound
            {
                [Test]
                public void ShouldThrowHttpNotFound()
                {
                    // Arrange
                    
                    // Act
                    // Assert
                }
            }
        }
        private static PeopleController Create(
            IQueryExecutor queryExecutor = null,
            ICommandExecutor commandExecutor = null)
        {
            return new PeopleController(
                queryExecutor ?? Substitute.For<IQueryExecutor>(),
                commandExecutor ?? Substitute.For<ICommandExecutor>()
            );
        }
    }
}