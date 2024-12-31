using System.Collections.Concurrent;

namespace RS.Fritz.Manager.UI;

[ProviderAlias(nameof(UserInterfaceLogService))]
internal sealed class UserInterfaceLogServiceProvider : ILoggerProvider
{
    private readonly ConcurrentDictionary<string, UserInterfaceLogService> loggers = new(StringComparer.OrdinalIgnoreCase);

    public ILogger CreateLogger(string categoryName) => loggers.GetOrAdd(categoryName, static q => new(q));

    public void Dispose() => loggers.Clear();
}