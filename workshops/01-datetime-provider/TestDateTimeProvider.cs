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
        public void ShouldReturnCorrectDateTime()
        public void ShouldReturnCorrectDateTimeTwice()
        {
            // Arrange
            var sut = Create();
            // Act
            var start = DateTime.UtcNow;
            var result1 = sut.UtcNow;
            var middle = DateTime.UtcNow;
            var result2 = sut.UtcNow;
            var end = DateTime.UtcNow;
            // Assert
            Expect(result1)
                .To.Be.Greater.Than.Or.Equal.To(
                    start,
                    () => $"result: {result1.Ticks} vs start: {start.Ticks}")
                .And
                .To.Be.Less.Than.Or.Equal.To(
                    middle);
            Expect(result2)
                .To.Be.Greater.Than.Or.Equal.To(
                    middle)
                .And
                .To.Be.Less.Than.Or.Equal.To(
                    end);
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