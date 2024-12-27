using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace RS.Fritz.Manager.API;

internal sealed class WebUiService(IHttpClientFactory httpClientFactory, INetworkService networkService) : IWebUiService
{
    private const string LoginPath = "//login_sid.lua?version=2";

    private readonly IHttpClientFactory httpClientFactory = httpClientFactory;
    private readonly INetworkService networkService = networkService;

    public async ValueTask<WebUiSessionInfo> GetUsersAsync(InternetGatewayDevice internetGatewayDevice, CancellationToken cancellationToken = default)
    {
        Uri loginUri = GetLoginUri(internetGatewayDevice);
        Stream xmlResponseStream = await httpClientFactory.CreateClient(Constants.DefaultHttpClientName).GetStreamAsync(loginUri, cancellationToken).ConfigureAwait(false);

        await using (xmlResponseStream.ConfigureAwait(false))
        {
            return Deserialize(xmlResponseStream);
        }
    }

    public async ValueTask<WebUiSessionInfo> LogonAsync(InternetGatewayDevice internetGatewayDevice, CancellationToken cancellationToken = default)
    {
        WebUiSessionInfo webUiSessionInfo = await GetUsersAsync(internetGatewayDevice, cancellationToken).ConfigureAwait(false);
        string[] challengeParts = webUiSessionInfo.Challenge.Split('$');
        int firstIterationCount = int.Parse(challengeParts[1], CultureInfo.InvariantCulture);
        byte[] firstSalt = Convert.FromHexString(challengeParts[2]);
        int secondIterationCount = int.Parse(challengeParts[3], CultureInfo.InvariantCulture);
        byte[] secondSalt = Convert.FromHexString(challengeParts[4]);
        byte[] passwordBytes = Encoding.UTF8.GetBytes(internetGatewayDevice.NetworkCredential!.Password);
        byte[] firstHash = GetHash(passwordBytes, firstSalt, firstIterationCount);
        byte[] secondHash = GetHash(firstHash, secondSalt, secondIterationCount);
        string challengeResponse = FormattableString.Invariant($"{challengeParts[4]}${Convert.ToHexString(secondHash)}");
        var parameters = new Dictionary<string, string> { { "username", internetGatewayDevice.NetworkCredential.UserName }, { "response", challengeResponse } };

        return await GetResponseAsync(internetGatewayDevice, parameters, cancellationToken).ConfigureAwait(false);
    }

    public ValueTask<WebUiSessionInfo> LogoffAsync(InternetGatewayDevice internetGatewayDevice, string sessionId, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string> { { "logout", string.Empty }, { "sid", sessionId } };

        return GetResponseAsync(internetGatewayDevice, parameters, cancellationToken);
    }

    public ValueTask<WebUiSessionInfo> ValidateSessionAsync(InternetGatewayDevice internetGatewayDevice, string sessionId, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string> { { "sid", sessionId } };

        return GetResponseAsync(internetGatewayDevice, parameters, cancellationToken);
    }

    private static WebUiSessionInfo Deserialize(Stream xmlResponseStream)
    {
        using var xmlTextReader = new XmlTextReader(xmlResponseStream);

        return (WebUiSessionInfo)new XmlSerializer(typeof(WebUiSessionInfo)).Deserialize(xmlTextReader)!;
    }

    private static byte[] GetHash(byte[] password, byte[] salt, int iterations)
    {
        using var derivedBytes = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);

        return derivedBytes.GetBytes(32);
    }

    private Uri GetLoginUri(InternetGatewayDevice internetGatewayDevice)
        => networkService.FormatUri(Uri.UriSchemeHttps, internetGatewayDevice.PreferredLocation!, 443, LoginPath);

    private async ValueTask<WebUiSessionInfo> GetResponseAsync(InternetGatewayDevice internetGatewayDevice, IDictionary<string, string> parameters, CancellationToken cancellationToken)
    {
        using var formContent = new FormUrlEncodedContent(parameters);
        Uri loginUri = GetLoginUri(internetGatewayDevice);
        using HttpResponseMessage loginResponse = await httpClientFactory.CreateClient(Constants.DefaultHttpClientName).PostAsync(loginUri, formContent, cancellationToken).ConfigureAwait(false);
        Stream xmlResponseStream = await loginResponse.EnsureSuccessStatusCode().Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);

        await using (xmlResponseStream.ConfigureAwait(false))
        {
            return Deserialize(xmlResponseStream);
        }
    }
}