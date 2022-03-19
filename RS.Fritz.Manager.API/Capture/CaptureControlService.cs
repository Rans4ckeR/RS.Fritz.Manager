namespace RS.Fritz.Manager.API;

using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

internal sealed class CaptureControlService : ICaptureControlService
{
    private readonly IHttpClientFactory httpClientFactory;

    public CaptureControlService(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public async Task GetStartCaptureResponseAsync(Uri uri, string folderPath, string filePrefix)
    {
        HttpClient httpClient = httpClientFactory.CreateClient(Constants.HttpClientName);
        var file = new FileInfo(FormattableString.Invariant($"{folderPath}\\{filePrefix}_{DateTime.Now.ToString("s").Replace(":", string.Empty)}.eth"));
        HttpResponseMessage? response = await httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
        _ = response.EnsureSuccessStatusCode();
        await using Stream? downloadStream = await response.Content.ReadAsStreamAsync();
        await using FileStream? fileStream = file.Create();
        await downloadStream.CopyToAsync(fileStream);
    }

    public async Task GetStopCaptureResponseAsync(Uri uri)
    {
        HttpClient httpClient = httpClientFactory.CreateClient(Constants.HttpClientName);
        HttpResponseMessage? response = await httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
        _ = response.EnsureSuccessStatusCode();
    }
}