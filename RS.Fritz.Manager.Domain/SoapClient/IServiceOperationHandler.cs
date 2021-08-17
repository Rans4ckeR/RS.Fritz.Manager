namespace RS.Fritz.Manager.Domain
{
    using System;
    using System.Threading.Tasks;

    public interface IServiceOperationHandler
    {
        Task ExecuteAsync<T>(T client, Func<T, Task> operation);

        Task<TResult> ExecuteAsync<T, TResult>(T client, Func<T, Task<TResult>> operation);
    }
}