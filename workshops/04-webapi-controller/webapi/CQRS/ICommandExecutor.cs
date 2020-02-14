namespace TDD101.Workshops.WebApi.CQRS
{
    public interface ICommandExecutor
    {
        T Execute<T>(ICommand<T> command);
    }
}