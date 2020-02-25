using System;
using NUnit.Framework;
using NExpect;
using static NExpect.Expectations;

namespace TDD101.Workshops.StringCalculator
{
    [TestFixture]
    public class TestStringCalculator
    {
        [Test]
        public void ShouldReturnZeroForEmptyString()
        {
            // Arrange
            var input = "";
            var sut = Create();
            // Act
            var result = sut.Add(input);
            // Assert
            Expect(result)
                .To.Equal(0);
        }
        
        private static IStringCalculator Create()
        {
            return new StringCalculatorImpl();
        }
    }

    internal class StringCalculatorImpl
        : IStringCalculator
    {
        public int Add(string input)
        {
            return 0;
        }
    }

    public interface IStringCalculator
    {
        int Add(string input);
    }
}
