namespace RS.Fritz.Manager.API;

public interface IWebUiService
{
    ValueTask<WebUiSessionInfo> GetUsersAsync(InternetGatewayDevice internetGatewayDevice, CancellationToken cancellationToken = default);

    ValueTask<WebUiSessionInfo> LogonAsync(InternetGatewayDevice internetGatewayDevice, CancellationToken cancellationToken = default);

    ValueTask<WebUiSessionInfo> LogoffAsync(InternetGatewayDevice internetGatewayDevice, string sessionId, CancellationToken cancellationToken = default);

    ValueTask<WebUiSessionInfo> ValidateSessionAsync(InternetGatewayDevice internetGatewayDevice, string sessionId, CancellationToken cancellationToken = default);
}