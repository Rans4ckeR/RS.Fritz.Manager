namespace RS.Fritz.Manager.API;

using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

internal sealed class WebUiService : IWebUiService
{
    private const string LoginPath = "//login_sid.lua?version=2";

    private readonly IHttpClientFactory httpClientFactory;

    public WebUiService(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public async Task<WebUiSessionInfo> GetUsersAsync(InternetGatewayDevice internetGatewayDevice, CancellationToken cancellationToken = default)
    {
        Uri loginUri = GetLoginUri(internetGatewayDevice);
        await using Stream xmlResponseStream = await httpClientFactory.CreateClient(Constants.NonValidatingHttpsClientName).GetStreamAsync(loginUri, cancellationToken);

        return Deserialize(xmlResponseStream);
    }

    public async Task<WebUiSessionInfo> LogonAsync(InternetGatewayDevice internetGatewayDevice, CancellationToken cancellationToken = default)
    {
        WebUiSessionInfo webUiSessionInfo = await GetUsersAsync(internetGatewayDevice, cancellationToken);
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

        return await GetResponseAsync(internetGatewayDevice, parameters, cancellationToken);
    }

    public Task<WebUiSessionInfo> LogoffAsync(InternetGatewayDevice internetGatewayDevice, string sessionId, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string> { { "logout", string.Empty }, { "sid", sessionId } };

        return GetResponseAsync(internetGatewayDevice, parameters, cancellationToken);
    }

    public Task<WebUiSessionInfo> ValidateSessionAsync(InternetGatewayDevice internetGatewayDevice, string sessionId, CancellationToken cancellationToken = default)
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

    private static Uri GetLoginUri(InternetGatewayDevice internetGatewayDevice)
    {
        return new Uri(FormattableString.Invariant($"https://{internetGatewayDevice.PreferredLocation.Host}{LoginPath}"));
    }

    private async Task<WebUiSessionInfo> GetResponseAsync(InternetGatewayDevice internetGatewayDevice, IDictionary<string, string> parameters, CancellationToken cancellationToken)
    {
        var formContent = new FormUrlEncodedContent(parameters);
        Uri loginUri = GetLoginUri(internetGatewayDevice);
        HttpResponseMessage loginResponse = await httpClientFactory.CreateClient(Constants.NonValidatingHttpsClientName).PostAsync(loginUri, formContent, cancellationToken);
        await using Stream xmlResponseStream = await loginResponse.EnsureSuccessStatusCode().Content.ReadAsStreamAsync(cancellationToken);

        return Deserialize(xmlResponseStream);
    }
}