﻿namespace RS.Fritz.Manager.API
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public static class TaskExtensions
    {
        public static async Task<TResult[]> WhenAllSafe<TResult>(IEnumerable<Task<TResult>> tasks)
        {
            Task<TResult[]> whenAllTask = Task.WhenAll(tasks);

            try
            {
                return await whenAllTask;
            }
            catch
            {
                // Ignore individual task exceptions
            }

#pragma warning disable CS8597 // Thrown value may be null.
            throw whenAllTask.Exception;
#pragma warning restore CS8597 // Thrown value may be null.
        }

        public static async Task WhenAllSafe(IEnumerable<Task> tasks)
        {
            Task whenAllTask = Task.WhenAll(tasks);

            try
            {
                await whenAllTask;

                return;
            }
            catch
            {
                // Ignore individual task exceptions
            }

#pragma warning disable CS8597 // Thrown value may be null.
            throw whenAllTask.Exception;
#pragma warning restore CS8597 // Thrown value may be null.
        }
    }
}