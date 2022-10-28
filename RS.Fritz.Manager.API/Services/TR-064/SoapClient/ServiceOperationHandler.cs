namespace RS.Fritz.Manager.API;

internal abstract class ServiceOperationHandler
{
    protected static async Task<TResult> ExecuteAsync<T, TResult>(T client, Func<T, Task<TResult>> operation)
    {
        if (client is not ICommunicationObject)
            throw new NotSupportedException();

        await using ((IAsyncDisposable)client)
        {
            return await operation(client);
        }
    }
}