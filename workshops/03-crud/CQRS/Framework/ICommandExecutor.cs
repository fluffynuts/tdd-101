namespace TDD101.Workshops.CRUD.CQRS.Framework
{
    public interface ICommandExecutor
    {
        T Execute<T>(ICommand<T> command);
    }
}