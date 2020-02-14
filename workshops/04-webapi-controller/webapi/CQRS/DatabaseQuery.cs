namespace TDD101.Workshops.WebApi.CQRS
{
    public abstract class DatabaseQuery<T> : DatabaseConsumer, IQuery<T>
    {
        public abstract T Execute();

        public abstract void Validate();
    }
}