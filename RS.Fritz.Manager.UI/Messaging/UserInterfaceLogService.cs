using CommunityToolkit.Mvvm.Messaging;

namespace RS.Fritz.Manager.UI;

internal sealed class UserInterfaceLogService(string name) : ILogger
{
    private readonly string name = name;

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel))
            return;

        string formattedMessage = formatter(state, null);
        string? exceptionDetails = null;

        if (exception is not null)
            exceptionDetails = exception.GetDetailedExceptionInfo();

        string message = FormattableString.Invariant($"{name} - {logLevel} - {eventId}:\r\n{formattedMessage}{(!string.IsNullOrWhiteSpace(formattedMessage) && exceptionDetails is not null ? "\r\n\r\n" : null)}{exceptionDetails}");

#pragma warning disable IDE0066 // Convert switch statement to expression
        switch (eventId.Id)
        {
            case (int)LoggingEvents.UserEvent:
                _ = StrongReferenceMessenger.Default.Send(new UserMessageValueChangedMessage(new(message)));
                break;
            default:
                _ = StrongReferenceMessenger.Default.Send(new LogMessageValueChangedMessage(new(message)));
                break;
        }
#pragma warning restore IDE0066 // Convert switch statement to expression
    }

    public bool IsEnabled(LogLevel logLevel) =>
        logLevel is not LogLevel.None;

    public IDisposable BeginScope<TState>(TState state)
        where TState : notnull => null!;
}