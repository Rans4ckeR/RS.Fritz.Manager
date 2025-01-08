using System.Runtime.ExceptionServices;

namespace RS.Fritz.Manager.API;

/// <summary>
/// Extension methods for <see cref="Task"/>.
/// </summary>
public static class TaskExtensions
{
    /// <inheritdoc cref="Evaluate(ValueTask,bool)"/>>
    public static async ValueTask Evaluate(this Task task, ConfigureAwaitOptions configureAwaitOptions = ConfigureAwaitOptions.None)
    {
        if (task.IsCompletedSuccessfully)
            return;

        try
        {
            await task
                .ConfigureAwait(configureAwaitOptions);
        }
        catch
        {
            if (task.Exception is null)
                throw;

            ExceptionDispatchInfo.Capture(task.GetFlattenedAggregateException()).Throw();
        }
    }

    /// <summary>
    /// Ensures all exceptions are observed from an async method by flattening any <see cref="AggregateException"/> instances into a single <see cref="AggregateException"/> instance.
    /// </summary>
    public static async ValueTask Evaluate(this ValueTask task, bool continueOnCapturedContext = false)
    {
        if (task.IsCompletedSuccessfully)
            return;

        try
        {
            await task.ConfigureAwait(continueOnCapturedContext);
        }
        catch
        {
            if (task.AsTask().Exception is null)
                throw;

            ExceptionDispatchInfo.Capture(task.AsTask().GetFlattenedAggregateException()).Throw();
        }
    }

    /// <inheritdoc cref="Evaluate(ValueTask,bool)"/>>
    public static async ValueTask<T> Evaluate<T>(this Task<T> task, ConfigureAwaitOptions configureAwaitOptions = ConfigureAwaitOptions.None)
    {
        if (task.IsCompletedSuccessfully)
            return task.Result;

        T? result = default;

        try
        {
            result = await task
                .ConfigureAwait(configureAwaitOptions);
        }
        catch
        {
            if (task.Exception is null)
                throw;

            ExceptionDispatchInfo.Capture(task.GetFlattenedAggregateException()).Throw();
        }

        return result!;
    }

    /// <inheritdoc cref="Evaluate(ValueTask,bool)"/>>
    public static async ValueTask<T> Evaluate<T>(this ValueTask<T> task, bool continueOnCapturedContext = false)
    {
        if (task.IsCompletedSuccessfully)
            return task.Result;

        T? result = default;

        try
        {
            result = await task.ConfigureAwait(continueOnCapturedContext);
        }
        catch
        {
            if (task.AsTask().Exception is null)
                throw;

            ExceptionDispatchInfo.Capture(task.AsTask().GetFlattenedAggregateException()).Throw();
        }

        return result!;
    }

    /// <summary>
    /// Gets the flattened aggregate exception for a faulted task.
    /// </summary>
    public static AggregateException GetFlattenedAggregateException(this Task task) => task.Exception!.Flatten();
}