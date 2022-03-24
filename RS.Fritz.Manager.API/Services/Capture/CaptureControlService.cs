namespace RS.Fritz.Manager.API;

using System.Globalization;

internal sealed class CaptureControlService : ICaptureControlService
{
    private const string Scheme = "http";
    private const string CapturePath = "/cgi-bin/capture_notimeout";

    private readonly IHttpClientFactory httpClientFactory;
    private readonly IWebUiService webUiService;

    public CaptureControlService(IHttpClientFactory httpClientFactory, IWebUiService webUiService)
    {
        this.httpClientFactory = httpClientFactory;
        this.webUiService = webUiService;
    }

    public async Task<FileInfo> GetStartCaptureResponseAsync(InternetGatewayDevice internetGateway, string folderPath, string filePrefix, CancellationToken cancellationToken = default)
    {
        const string iface = "2-1";
        string sid = await GetSidAsync(internetGateway, cancellationToken);
        string query = FormattableString.Invariant($"sid={sid}&capture=Start&snaplen=1600&ifaceorminor={iface}");
        var captureUri = new Uri(FormattableString.Invariant($"{Scheme}://{internetGateway.PreferredLocation.Host}{CapturePath}?{query}"));
        HttpClient httpClient = httpClientFactory.CreateClient(Constants.HttpClientName);
        var file = new FileInfo(FormattableString.Invariant($"{folderPath}\\{filePrefix}_{DateTime.Now.ToString("s").Replace(":", string.Empty)}.eth"));
        HttpResponseMessage response = await httpClient.GetAsync(captureUri, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

        _ = response.EnsureSuccessStatusCode();

        await using Stream downloadStream = await response.Content.ReadAsStreamAsync(cancellationToken);
        await using FileStream fileStream = file.Open(new FileStreamOptions { Access = FileAccess.Write, Mode = FileMode.CreateNew, Options = FileOptions.Asynchronous });

        await downloadStream.CopyToAsync(fileStream, cancellationToken);

        return file;
    }

    public async Task GetStopCaptureResponseAsync(InternetGatewayDevice internetGateway, CancellationToken cancellationToken = default)
    {
        const string iface = "eth_udma0";
        string sid = await GetSidAsync(internetGateway, cancellationToken);
        string timeString20 = DateTime.UtcNow.Ticks.ToString("D20", CultureInfo.InvariantCulture);
        string timeId = FormattableString.Invariant($"t{timeString20[^13..]}");
        var captureUri = new Uri(FormattableString.Invariant($"{Scheme}://{internetGateway.PreferredLocation.Host}{CapturePath}?iface={iface}&minor=1&type=2&capture=Stop&sid={sid}&useajax=1&xhr=1&{timeId}=nocache"));
        HttpClient httpClient = httpClientFactory.CreateClient(Constants.HttpClientName);
        HttpResponseMessage response = await httpClient.GetAsync(captureUri, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

        _ = response.EnsureSuccessStatusCode();
    }

    private async Task<string> GetSidAsync(InternetGatewayDevice internetGateway, CancellationToken cancellationToken)
    {
        WebUiSessionInfo webUiSessionInfo = await webUiService.LogonAsync(internetGateway, cancellationToken);

        return webUiSessionInfo.Sid;
    }
}