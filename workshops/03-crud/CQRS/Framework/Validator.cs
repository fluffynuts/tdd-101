using System;

namespace TDD101.Workshops.CRUD.CQRS.Framework
{
    public abstract class Validator
    {
        protected void Assert(
            bool condition,
            string message)
        {
            if (!condition)
            {
                throw new ArgumentException(message);
            }
        }

        protected void Assert(
            Func<bool> expr,
            string message)
        {
            Assert(expr(), message);
        }

        protected void AssertIsSet<T>(
            T value,
            string name)
        {
            Assert(() => !value.Equals(default(T)), $"{name} not set");
        }
    }
}