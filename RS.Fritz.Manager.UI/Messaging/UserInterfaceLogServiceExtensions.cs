using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging.Configuration;

namespace RS.Fritz.Manager.UI;

public static class UserInterfaceLogServiceExtensions
{
    public static ILoggingBuilder AddUserInterfaceLogService(this ILoggingBuilder loggingBuilder)
    {
        loggingBuilder.AddConfiguration();
        loggingBuilder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, UserInterfaceLogServiceProvider>());

        return loggingBuilder;
    }
}