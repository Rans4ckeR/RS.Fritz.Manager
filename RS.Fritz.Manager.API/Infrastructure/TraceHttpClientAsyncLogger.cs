using System.Net.Mime;
using System.Xml.Linq;
using Microsoft.Extensions.Http.Logging;
using Microsoft.Extensions.Logging;

namespace RS.Fritz.Manager.API;

internal sealed class TraceHttpClientAsyncLogger(ILogger<TraceHttpClientAsyncLogger> logger) : IHttpClientAsyncLogger
{
    private readonly ILogger logger = logger;

    public async ValueTask<object?> LogRequestStartAsync(HttpRequestMessage request, CancellationToken cancellationToken = default)
    {
        if (!logger.IsEnabled(LogLevel.Trace))
            return null;

        string? requestBody = null;
        string? mediaType = null;

        if (request.Content is not null)
        {
            mediaType = request.Content.Headers.ContentType?.MediaType;
            requestBody = await request.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        }

        logger.HttpRequest(request, GetFormattedContent(mediaType, requestBody));

        return null;
    }

    public async ValueTask LogRequestStopAsync(object? context, HttpRequestMessage request, HttpResponseMessage response, TimeSpan elapsed, CancellationToken cancellationToken = default)
    {
        if (!logger.IsEnabled(LogLevel.Trace))
            return;

        string? mediaType = response.Content.Headers.ContentType?.MediaType;
        string responseBody = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

        logger.HttpReply(response, GetFormattedContent(mediaType, responseBody)!, elapsed);
    }

    public ValueTask LogRequestFailedAsync(object? context, HttpRequestMessage request, HttpResponseMessage? response, Exception exception, TimeSpan elapsed, CancellationToken cancellationToken = default) =>
        default;

    public object LogRequestStart(HttpRequestMessage request) =>
        throw new NotSupportedException();

    public void LogRequestStop(object? context, HttpRequestMessage request, HttpResponseMessage response, TimeSpan elapsed) =>
        throw new NotSupportedException();

    public void LogRequestFailed(object? context, HttpRequestMessage request, HttpResponseMessage? response, Exception exception, TimeSpan elapsed) =>
        throw new NotSupportedException();

    private static string? GetFormattedContent(string? mediaType, string? content) =>
        mediaType is null || content is null
            ? null
            : MediaTypeNames.Text.Xml.Equals(mediaType, StringComparison.OrdinalIgnoreCase)
                ? XElement.Parse(content).ToString()
                : content;
}