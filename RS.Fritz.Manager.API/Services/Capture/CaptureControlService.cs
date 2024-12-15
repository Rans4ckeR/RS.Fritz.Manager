using System.Globalization;

namespace RS.Fritz.Manager.API;

internal sealed class CaptureControlService(IHttpClientFactory httpClientFactory, INetworkService networkService) : ICaptureControlService
{
    public async ValueTask<IEnumerable<CaptureInterfaceGroup>> GetInterfacesAsync(InternetGatewayDevice internetGatewayDevice, CancellationToken cancellationToken = default)
    {
        string sid = await GetSidAsync(internetGatewayDevice).ConfigureAwait(false);
        Uri captureUri = networkService.FormatUri(Uri.UriSchemeHttps, internetGatewayDevice.PreferredLocation!, 443, "/data.lua");
        HttpClient httpClient = httpClientFactory.CreateClient(Constants.DefaultHttpClientName);
        using var content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            { "xhr", "1" },
            { "sid", sid },
            { "oldpage", "/capture.lua" },
            { "page", "cap" }
        });
        using HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(captureUri, content, cancellationToken).ConfigureAwait(false);
        string responseContent = await httpResponseMessage.EnsureSuccessStatusCode().Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        var captureInterfaceGroups = new List<CaptureInterfaceGroup>();
        int groupNameBeginPosition = -1;

        while ((groupNameBeginPosition = responseContent.IndexOf("<h3>", groupNameBeginPosition + 1, StringComparison.OrdinalIgnoreCase)) is not -1)
        {
            int groupNameEndPosition = responseContent.IndexOf("</h3>", groupNameBeginPosition + 1, StringComparison.OrdinalIgnoreCase);
            string groupName = responseContent[(groupNameBeginPosition + "<h3>".Length)..groupNameEndPosition];
            int interfaceNameBeginPosition = groupNameEndPosition;
            int nextGroupNameBeginPosition = responseContent.IndexOf("<h3>", groupNameBeginPosition + 1, StringComparison.OrdinalIgnoreCase);
            var captureInterfaces = new List<CaptureInterface>();

            while ((interfaceNameBeginPosition = responseContent.IndexOf("<th>", interfaceNameBeginPosition + 1, StringComparison.OrdinalIgnoreCase)) is not -1 && interfaceNameBeginPosition < nextGroupNameBeginPosition)
            {
                int interfaceNameEndPosition = responseContent.IndexOf("</th>", interfaceNameBeginPosition + 1, StringComparison.OrdinalIgnoreCase);
                string interfaceName = responseContent[(interfaceNameBeginPosition + "<th>".Length)..interfaceNameEndPosition];
                int startParameterBeginPosition = responseContent.IndexOf("\" value=\"", interfaceNameEndPosition + 1, StringComparison.OrdinalIgnoreCase) + "\" value=\"".Length;
                int startParameterEndPosition = responseContent.IndexOf('"', startParameterBeginPosition + 1);
                string startParameter = responseContent[startParameterBeginPosition..startParameterEndPosition];
                int stopParameterBeginPosition = responseContent.IndexOf("\" value=\"", startParameterEndPosition + 1, StringComparison.OrdinalIgnoreCase) + "\" value=\"".Length;
                int stopParameterEndPosition = responseContent.IndexOf('"', stopParameterBeginPosition + 1);
                string stopParameter = responseContent[stopParameterBeginPosition..stopParameterEndPosition];
                string[] stopParameterParts = stopParameter.Split(';');

                captureInterfaces.Add(new(interfaceName, startParameter, stopParameterParts[0], stopParameterParts[1], stopParameterParts[2]));
            }

            if (captureInterfaces.Count is not 0)
                captureInterfaceGroups.Add(new(groupName, captureInterfaces));
        }

        return captureInterfaceGroups;
    }

    public async ValueTask StartCaptureAsync(InternetGatewayDevice internetGatewayDevice, FileInfo fileInfo, CaptureInterface captureInterface, int packetCaptureSizeLimit = 1600, CancellationToken cancellationToken = default)
    {
        string sid = await GetSidAsync(internetGatewayDevice).ConfigureAwait(false);
        Uri captureUri = networkService.FormatUri(Uri.UriSchemeHttps, internetGatewayDevice.PreferredLocation!, 443, FormattableString.Invariant($"/cgi-bin/capture_notimeout?sid={sid}&capture=Start&snaplen={packetCaptureSizeLimit}&ifaceorminor={captureInterface.InterfaceOrMinor}"));
        HttpClient httpClient = httpClientFactory.CreateClient(Constants.DefaultHttpClientName);
        using HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(captureUri, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
        Stream downloadStream = await httpResponseMessage.EnsureSuccessStatusCode().Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);

        await using (downloadStream.ConfigureAwait(false))
        {
            FileStream fileStream = fileInfo.Open(new FileStreamOptions { Access = FileAccess.Write, Mode = FileMode.CreateNew, Options = FileOptions.Asynchronous });

            await using (fileStream.ConfigureAwait(false))
            {
                await downloadStream.CopyToAsync(fileStream, cancellationToken).ConfigureAwait(false);
            }
        }
    }

    public async ValueTask StopCaptureAsync(InternetGatewayDevice internetGatewayDevice, CaptureInterface captureInterface, CancellationToken cancellationToken = default)
    {
        string sid = await GetSidAsync(internetGatewayDevice).ConfigureAwait(false);
        string timeString20 = DateTime.UtcNow.Ticks.ToString("D20", CultureInfo.InvariantCulture);
        string timeId = FormattableString.Invariant($"t{timeString20[^13..]}");
        Uri captureUri = networkService.FormatUri(Uri.UriSchemeHttps, internetGatewayDevice.PreferredLocation!, 443, FormattableString.Invariant($"/cgi-bin/capture_notimeout?iface={captureInterface.Interface}&minor={captureInterface.Minor}&type={captureInterface.Type}&capture=Stop&sid={sid}&useajax=1&xhr=1&{timeId}=nocache"));
        HttpClient httpClient = httpClientFactory.CreateClient(Constants.DefaultHttpClientName);
        using HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(captureUri, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);

        _ = httpResponseMessage.EnsureSuccessStatusCode();
    }

    private static async ValueTask<string> GetSidAsync(InternetGatewayDevice internetGatewayDevice)
    {
        DeviceConfigCreateUrlSidResponse deviceConfigCreateUrlSidResponse = await internetGatewayDevice.DeviceConfigCreateUrlSidAsync().ConfigureAwait(false);

        return deviceConfigCreateUrlSidResponse.UrlSid.Replace("sid=", null, StringComparison.OrdinalIgnoreCase);
    }
}