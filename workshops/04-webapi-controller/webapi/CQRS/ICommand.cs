namespace TDD101.Workshops.WebApi.CQRS
{
    public interface ICommand<T> : IValidator
    {
        T Execute();
    }
}