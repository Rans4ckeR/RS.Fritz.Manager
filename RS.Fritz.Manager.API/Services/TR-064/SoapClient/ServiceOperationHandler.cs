namespace RS.Fritz.Manager.API;

internal abstract class ServiceOperationHandler
{
    protected static async Task<TResult> ExecuteAsync<T, TResult>(T client, Func<T, Task<TResult>> operation)
    {
        if (client is not ICommunicationObject communicationObject)
            throw new NotSupportedException();

        try
        {
            return await operation(client);
        }
        finally
        {
            CloseClient(communicationObject);
        }
    }

    private static void CloseClient(ICommunicationObject communicationObject)
    {
        try
        {
            if (communicationObject.State == CommunicationState.Faulted)
                communicationObject.Abort();
            else if (communicationObject.State != CommunicationState.Closed)
                communicationObject.Close();
        }
        catch (CommunicationException)
        {
            communicationObject.Abort();
        }
        catch (TimeoutException)
        {
            communicationObject.Abort();
        }
    }
}