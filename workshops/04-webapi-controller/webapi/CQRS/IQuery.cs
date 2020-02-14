namespace TDD101.Workshops.WebApi.CQRS
{
    public interface IQuery<T> : IValidator
    {
        T Execute();
    }
}