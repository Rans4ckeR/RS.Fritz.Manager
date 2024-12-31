using System.Net;
using Microsoft.Extensions.Logging;

namespace RS.Fritz.Manager.API;

public static partial class LoggerExtensions
{
    private static readonly Action<ILogger, string, Exception?> ExceptionDetails = LoggerMessage.Define<string>(LogLevel.Error, new((int)LoggingEvents.UserEvent, nameof(ExceptionThrown)), "{Exception}");

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

    [LoggerMessage(Level = LogLevel.Trace, EventId = (int)LoggingEvents.SoapRequest, Message = "{Request}")]
    internal static partial void SoapRequest(this ILogger logger, string request);

    [LoggerMessage(Level = LogLevel.Trace, EventId = (int)LoggingEvents.SoapReply, Message = "{Reply}")]
    internal static partial void SoapReply(this ILogger logger, string reply);

    [LoggerMessage(Level = LogLevel.Trace, EventId = (int)LoggingEvents.DiscoverRequest, Message = "{LocalIpEndPoint} -> {RemoteIpEndPoint}\r\n{Request}")]
    internal static partial void DiscoverRequest(this ILogger logger, IPEndPoint localIpEndPoint, IPEndPoint remoteIpEndPoint, string request);

    [LoggerMessage(Level = LogLevel.Trace, EventId = (int)LoggingEvents.DiscoverReply, Message = "{RemoteIpEndPoint} -> {LocalIpEndPoint}\r\n{Reply}")]
    internal static partial void DiscoverReply(this ILogger logger, IPEndPoint localIpEndPoint, IPEndPoint remoteIpEndPoint, string reply);

    [LoggerMessage(Level = LogLevel.Trace, EventId = (int)LoggingEvents.HttpRequest, Message = "{HttpRequestMessage}\r\n{RequestContent}")]
    internal static partial void HttpRequest(this ILogger logger, HttpRequestMessage httpRequestMessage, string? requestContent);

    [LoggerMessage(Level = LogLevel.Trace, EventId = (int)LoggingEvents.HttpReply, Message = "{Elapsed} {HttpResponseMessage}\r\n{ReplyContent}")]
    internal static partial void HttpReply(this ILogger logger, HttpResponseMessage httpResponseMessage, string replyContent, TimeSpan elapsed);
}