namespace TDD101.Workshops.CRUD.CQRS.Framework
{
    public interface IQuery<T> : IValidator
    {
        T Execute();
    }
}