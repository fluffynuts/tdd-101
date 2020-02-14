using System;
using NExpect;
using NUnit.Framework;
using static NExpect.Expectations;

namespace TDD101.Workshops.DatetimeProvider
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void ShouldReturnUtcDateTime()
        {
            // Arrange
            var sut = Create();
            // Act
            var result = sut.UtcNow;
            // Assert
            Expect(result.Kind)
                .To.Equal(DateTimeKind.Utc);
        }

        [Test]
        public void ShouldReturnCorrectDateTime()
        {
            // Arrange
            // Act
            // Assert
        }
        
        private static IDateTimeProvider Create()
        {
            throw new NotImplementedException();
        }
    }

    public interface IDateTimeProvider
    {
        public DateTime UtcNow { get; }
    }
}