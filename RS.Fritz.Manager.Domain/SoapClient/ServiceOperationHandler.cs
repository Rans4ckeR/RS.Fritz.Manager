namespace RS.Fritz.Manager.Domain
{
    using System;
    using System.ServiceModel;
    using System.Threading.Tasks;

    public abstract class ServiceOperationHandler
    {
        protected static async Task<TResult> ExecuteAsync<T, TResult>(T client, Func<T, Task<TResult>> operation)
        {
            try
            {
                // RoSchmi hier wird Request ausgeführt
                /*
                while (true)
                {
                    await Task.Delay(10);
                }
                */

                var returnResult = await Execute(client, operation).ConfigureAwait(false);
                return returnResult;
                //return await Execute(client, operation).ConfigureAwait(false);
            }
            finally
            {
                // RoSchmi

                //CloseClient(client);
            }
        }

        private static Task<TResult> Execute<T, TResult>(T client, Func<T, Task<TResult>> operation)
        {
            var returnResult = operation(client);
            return returnResult;
            //return operation(client);
        }

        private static void CloseClient<T>(T client)
        {
            (client as ICommunicationObject)?.SafeClose();
        }
    }
}