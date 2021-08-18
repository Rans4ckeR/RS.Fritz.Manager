﻿namespace RS.Fritz.Manager.Domain
{
    using System;
    using System.ServiceModel;
    using System.Threading.Tasks;

    public sealed class ServiceOperationHandler : IServiceOperationHandler
    {
        public async Task ExecuteAsync<T>(T client, Func<T, Task> operation)
        {
            try
            {
                await Execute(client, operation).ConfigureAwait(false);
            }
            finally
            {
                CloseClient(client);
            }
        }

        public async Task<TResult> ExecuteAsync<T, TResult>(T client, Func<T, Task<TResult>> operation)
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

        private static Task Execute<T>(T client, Func<T, Task> operation)
        {
            return operation(client);
        }

        private static Task<TResult> Execute<T, TResult>(T client, Func<T, Task<TResult>> operation)
        {
            return operation(client);
        }

        private static void CloseClient<T>(T client)
        {
            (client as ICommunicationObject)?.SafeClose();
        }
    }
}