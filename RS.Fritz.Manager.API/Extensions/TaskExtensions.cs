namespace RS.Fritz.Manager.API;

public static class TaskExtensions
{
    /// <summary>
    /// Executes a list of tasks and waits for all of them to complete and throws an <see cref="AggregateException"/> containing all exceptions from all tasks.
    /// When using <see cref="Task.WhenAll(IEnumerable{Task})"/> only the first thrown exception from a single <see cref="Task"/> may be observed.
    /// </summary>
    /// <typeparam name="T">The type of <paramref name="tasks"/>'s return value.</typeparam>
    /// <param name="tasks">The list of <see cref="Task"/>s who's exceptions will be handled.</param>
    /// <returns>Returns a <see cref="ValueTask"/> that awaited and handled the original <paramref name="tasks"/>.</returns>
    public static async ValueTask<T[]> WhenAllSafe<T>(IEnumerable<Task<T>> tasks)
    {
        var whenAllTask = Task.WhenAll(tasks);

        try
        {
            return await whenAllTask;
        }
        catch
        {
            if (whenAllTask.Exception is null)
                throw;

            throw whenAllTask.Exception;
        }
    }

    /// <summary>
    /// Executes a list of tasks and waits for all of them to complete and throws an <see cref="AggregateException"/> containing all exceptions from all tasks.
    /// When using <see cref="Task.WhenAll(IEnumerable{Task})"/> only the first thrown exception from a single <see cref="Task"/> may be observed.
    /// </summary>
    /// <param name="tasks">The list of <see cref="Task"/>s who's exceptions will be handled.</param>
    /// <returns>Returns a <see cref="ValueTask"/> that awaited and handled the original <paramref name="tasks"/>.</returns>
    public static async ValueTask WhenAllSafe(IEnumerable<Task> tasks)
    {
        var whenAllTask = Task.WhenAll(tasks);

        try
        {
            await whenAllTask;
        }
        catch
        {
            if (whenAllTask.Exception is null)
                throw;

            throw whenAllTask.Exception;
        }
    }
}