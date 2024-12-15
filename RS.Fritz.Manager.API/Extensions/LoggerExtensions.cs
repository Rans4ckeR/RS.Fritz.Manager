using Microsoft.Extensions.Logging;

namespace RS.Fritz.Manager.API;

public static class LoggerExtensions
{
    private static readonly Action<ILogger, string, Exception?> ExceptionDetails = LoggerMessage.Define<string>(LogLevel.Error, new(1, nameof(ExceptionThrown)), "{Exception}");

    public static void ExceptionThrown(this ILogger logger, Exception exception)
    {
        try
        {
            ExceptionDetails(logger, exception.GetDetailedExceptionInfo(), null);
        }
        catch (Exception ex)
        {
            ExceptionDetails(logger, ex.GetDetailedExceptionInfo(), null);
        }
    }
}