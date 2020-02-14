namespace TDD101.Workshops.WebApi.CQRS
{
    public interface IQueryExecutor
    {
        T Execute<T>(IQuery<T> query);
    }
}