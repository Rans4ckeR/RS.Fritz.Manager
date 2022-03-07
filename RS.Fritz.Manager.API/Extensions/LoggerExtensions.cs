namespace RS.Fritz.Manager.API
{
    using System;
    using Microsoft.Extensions.Logging;

    public static class LoggerExtensions
    {
        private static readonly Action<ILogger, string, Exception?> ExceptionDetails = LoggerMessage.Define<string>(LogLevel.Error, new EventId(1, nameof(ExceptionThrown)), "Exception thrown (Exception = '{Exception}')");

        public static void ExceptionThrown(this ILogger logger, Exception exception)
        {
            ExceptionDetails(logger, exception.GetDetailedExceptionInfo(), null);
        }
    }
}