namespace RS.Fritz.Manager.UI;

using CommunityToolkit.Mvvm.Messaging;

internal sealed class UserInterfaceLogService : ILogger
{
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel))
            return;

        string message = formatter(state, exception);

        _ = StrongReferenceMessenger.Default.Send(new UserMessageValueChangedMessage(new(message)));
    }

    public bool IsEnabled(LogLevel logLevel) => logLevel >= LogLevel.Warning;

    IDisposable ILogger.BeginScope<TState>(TState state)
        => throw new NotSupportedException();
}