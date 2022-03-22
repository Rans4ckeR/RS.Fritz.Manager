namespace RS.Fritz.Manager.API;

public static class TaskExtensions
{
    public static async Task<TResult[]> WhenAllSafe<TResult>(IEnumerable<Task<TResult>> tasks)
    {
        var whenAllTask = Task.WhenAll(tasks);

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
        var whenAllTask = Task.WhenAll(tasks);

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