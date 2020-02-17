using System;
using System.Threading;
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
            Expect(result)
                .Not.To.Equal(DateTime.MinValue);
            Expect(result.Kind)
                .To.Equal(DateTimeKind.Utc);
        }

        [Test]
        public void ShouldReturnNewTimeEveryTime()
        {
            // Arrange
            var sut = Create();
            // Act
            var result1 = sut.UtcNow;
            Thread.Sleep(10);
            var result2 = sut.UtcNow;
            // Assert
            Expect(result2)
                .To.Be.Greater.Than(result1);
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
            return new DatetimeProviderImpl();
        }
    }

    internal class DatetimeProviderImpl
        : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }

    public interface IDateTimeProvider
    {
        public DateTime UtcNow { get; }
    }
}