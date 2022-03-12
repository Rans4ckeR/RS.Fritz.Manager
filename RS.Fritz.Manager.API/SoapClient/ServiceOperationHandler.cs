namespace RS.Fritz.Manager.API;

using System;
using System.ServiceModel;
using System.Threading.Tasks;

internal abstract class ServiceOperationHandler
{
    protected static async Task<TResult> ExecuteAsync<T, TResult>(T client, Func<T, Task<TResult>> operation)
    {
        try
        {
            return await Execute(client, operation).ConfigureAwait(false);
        }
        finally
        {
            CloseClient(client);
        }
    }

    private static Task<TResult> Execute<T, TResult>(T client, Func<T, Task<TResult>> operation)
    {
        return operation(client);
    }

    private static void CloseClient<T>(T? client)
    {
        (client as ICommunicationObject)?.SafeClose();
    }
}