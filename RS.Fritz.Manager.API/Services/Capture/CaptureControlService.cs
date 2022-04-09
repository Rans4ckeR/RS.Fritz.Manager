namespace RS.Fritz.Manager.API;

using System.Globalization;

internal sealed class CaptureControlService : ICaptureControlService
{
    private readonly IHttpClientFactory httpClientFactory;

    public CaptureControlService(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public async Task<IEnumerable<CaptureInterfaceGroup>> GetInterfacesAsync(InternetGatewayDevice internetGatewayDevice, CancellationToken cancellationToken = default)
    {
        string sid = await GetSidAsync(internetGatewayDevice);
        var captureUri = new Uri(FormattableString.Invariant($"https://{internetGatewayDevice.PreferredLocation.Host}/data.lua"));
        HttpClient httpClient = httpClientFactory.CreateClient(Constants.NonValidatingHttpsClientName);
        var content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            { "xhr", "1" },
            { "sid", sid },
            { "lang", "en" },
            { "oldpage", "/capture.lua" },
            { "initalRefreshParamsSaved", "true" }
        });
        HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(captureUri, content, cancellationToken);
        string responseContent = await httpResponseMessage.EnsureSuccessStatusCode().Content.ReadAsStringAsync(cancellationToken);
        var captureInterfaceGroups = new List<CaptureInterfaceGroup>();
        int groupNameBeginPosition = -1;

        while ((groupNameBeginPosition = responseContent.IndexOf("<h3>", groupNameBeginPosition + 1, StringComparison.OrdinalIgnoreCase)) != -1)
        {
            int groupNameEndPosition = responseContent.IndexOf("</h3>", groupNameBeginPosition + 1, StringComparison.OrdinalIgnoreCase);
            string groupName = responseContent[(groupNameBeginPosition + "<h3>".Length)..groupNameEndPosition];
            int interfaceNameBeginPosition = groupNameEndPosition;
            int nextGroupNameBeginPosition = responseContent.IndexOf("<h3>", groupNameBeginPosition + 1, StringComparison.OrdinalIgnoreCase);
            var captureInterfaces = new List<CaptureInterface>();

            while ((interfaceNameBeginPosition = responseContent.IndexOf("<th>", interfaceNameBeginPosition + 1, StringComparison.OrdinalIgnoreCase)) != -1 && interfaceNameBeginPosition < nextGroupNameBeginPosition)
            {
                int interfaceNameEndPosition = responseContent.IndexOf("</th>", interfaceNameBeginPosition + 1, StringComparison.OrdinalIgnoreCase);
                string interfaceName = responseContent[(interfaceNameBeginPosition + "<th>".Length)..interfaceNameEndPosition];
                int startParameterBeginPosition = responseContent.IndexOf("\" value=\"", interfaceNameEndPosition + 1, StringComparison.OrdinalIgnoreCase) + "\" value=\"".Length;
                int startParameterEndPosition = responseContent.IndexOf("\"", startParameterBeginPosition + 1, StringComparison.OrdinalIgnoreCase);
                string startParameter = responseContent[startParameterBeginPosition..startParameterEndPosition];
                int stopParameterBeginPosition = responseContent.IndexOf("\" value=\"", startParameterEndPosition + 1, StringComparison.OrdinalIgnoreCase) + "\" value=\"".Length;
                int stopParameterEndPosition = responseContent.IndexOf("\"", stopParameterBeginPosition + 1, StringComparison.OrdinalIgnoreCase);
                string stopParameter = responseContent[stopParameterBeginPosition..stopParameterEndPosition];
                string[] stopParameterParts = stopParameter.Split(';');

                captureInterfaces.Add(new CaptureInterface(interfaceName, startParameter, stopParameterParts[0], stopParameterParts[1], stopParameterParts[2]));
            }

            if (captureInterfaces.Any())
                captureInterfaceGroups.Add(new CaptureInterfaceGroup(groupName, captureInterfaces));
        }

        return captureInterfaceGroups;
    }

    public async Task StartCaptureAsync(InternetGatewayDevice internetGatewayDevice, FileInfo fileInfo, CaptureInterface captureInterface, int packetCaptureSizeLimit = 1600, CancellationToken cancellationToken = default)
    {
        string sid = await GetSidAsync(internetGatewayDevice);
        var captureUri = new Uri(FormattableString.Invariant($"https://{internetGatewayDevice.PreferredLocation.Host}/cgi-bin/capture_notimeout?sid={sid}&capture=Start&snaplen={packetCaptureSizeLimit}&ifaceorminor={captureInterface.InterfaceOrMinor}"));
        HttpClient httpClient = httpClientFactory.CreateClient(Constants.NonValidatingHttpsClientName);
        HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(captureUri, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
        await using Stream downloadStream = await httpResponseMessage.EnsureSuccessStatusCode().Content.ReadAsStreamAsync(cancellationToken);
        await using FileStream fileStream = fileInfo.Open(new FileStreamOptions { Access = FileAccess.Write, Mode = FileMode.CreateNew, Options = FileOptions.Asynchronous });

        await downloadStream.CopyToAsync(fileStream, cancellationToken);
    }

    public async Task StopCaptureAsync(InternetGatewayDevice internetGatewayDevice, CaptureInterface captureInterface, CancellationToken cancellationToken = default)
    {
        string sid = await GetSidAsync(internetGatewayDevice);
        string timeString20 = DateTime.UtcNow.Ticks.ToString("D20", CultureInfo.InvariantCulture);
        string timeId = FormattableString.Invariant($"t{timeString20[^13..]}");
        var captureUri = new Uri(FormattableString.Invariant($"https://{internetGatewayDevice.PreferredLocation.Host}/cgi-bin/capture_notimeout?iface={captureInterface.Interface}&minor={captureInterface.Minor}&type={captureInterface.Type}&capture=Stop&sid={sid}&useajax=1&xhr=1&{timeId}=nocache"));
        HttpClient httpClient = httpClientFactory.CreateClient(Constants.NonValidatingHttpsClientName);
        HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(captureUri, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

        _ = httpResponseMessage.EnsureSuccessStatusCode();
    }

    private static async Task<string> GetSidAsync(InternetGatewayDevice internetGatewayDevice)
    {
        DeviceConfigCreateUrlSidResponse deviceConfigCreateUrlSidResponse = await internetGatewayDevice.DeviceConfigCreateUrlSidAsync();

        return deviceConfigCreateUrlSidResponse.UrlSid.Replace("sid=", null, StringComparison.OrdinalIgnoreCase);
    }
}