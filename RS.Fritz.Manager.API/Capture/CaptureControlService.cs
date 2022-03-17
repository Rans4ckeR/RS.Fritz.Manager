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
        // RoSchmi not needed ?
        this.httpClientFactory = httpClientFactory;
    }

    public async Task GetStartCaptureResponseAsync(Uri uri, string folderPath, string filePrefix)
    {
        HttpClient httpClient = httpClientFactory.CreateClient(Constants.HttpClientName);
        var file = new FileInfo(FormattableString.Invariant($"{folderPath}\\{filePrefix}_{DateTime.Now.ToString("dd/MM/yyyy'_'HH'_'mm'.'ss")}.eth"));

        var response = await httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
        response.EnsureSuccessStatusCode();
        using (var downloadStream = await response.Content.ReadAsStreamAsync())
        {
            using (var fileStream = file.Create())
            {
                await downloadStream.CopyToAsync(fileStream);
            }
        }
    }

    public async Task GetStopCaptureResponseAsync(Uri uri)
    {
        HttpClient httpClient = httpClientFactory.CreateClient(Constants.HttpClientName);
        var response = await httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
        response.EnsureSuccessStatusCode();
    }
}