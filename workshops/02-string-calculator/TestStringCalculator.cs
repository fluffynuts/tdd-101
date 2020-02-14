using System;
using NUnit.Framework;

namespace TDD101.Workshops.StringCalculator
{
    [TestFixture]
    public class TestStringCalculator
    {
        private static IStringCalculator Create()
        {
            throw new NotImplementedException();
        }
    }

    public interface IStringCalculator
    {
        int Add(string input);
    }
}
