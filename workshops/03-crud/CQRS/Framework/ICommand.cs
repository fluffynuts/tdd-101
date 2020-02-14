namespace TDD101.Workshops.CRUD.CQRS.Framework
{
    public interface ICommand<T> : IValidator
    {
        T Execute();
    }
}