namespace RS.Fritz.Manager.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public static class TaskExtensions
    {
#pragma warning disable IDE0060 // Remove unused parameter
        public static void Forget(this Task task)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            // Allows for a 'fire and forget' <see cref="Task" /> without having to disable compiler warning CS2014.
        }

        public static async Task Evaluate(this Task task)
        {
            try
            {
                await task;
            }
            catch
            {
                bool throwExceptionForFailure = CheckForFailure(task);

                if (throwExceptionForFailure)
                    throw task.GetFlattenedAggregateException();

                throw;
            }
        }

        public static async Task<T> Evaluate<T>(this Task<T> task)
        {
            T result;

            try
            {
                result = await task;
            }
            catch
            {
                bool throwExceptionForFailure = CheckForFailure(task);

                if (throwExceptionForFailure)
                    throw task.GetFlattenedAggregateException();

                throw;
            }

            return result;
        }

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

        private static AggregateException GetFlattenedAggregateException(this Task task) => task.Exception!.Flatten();

        private static bool CheckForFailure(Task task)
        {
            if (task.IsFaulted)
            {
                HandleTaskExceptions(task);

                return true;
            }

            return false;
        }

        private static void HandleTaskExceptions(Task task)
        {
            AggregateException flattenedAggregateException = task.GetFlattenedAggregateException();

            flattenedAggregateException.Handle(_ => true);
        }
    }
}