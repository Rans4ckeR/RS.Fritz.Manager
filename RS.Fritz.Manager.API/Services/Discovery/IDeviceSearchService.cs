using System.Net;

namespace RS.Fritz.Manager.API;

public interface IDeviceSearchService
{
    /// <summary>
    /// Discovers InternetGatewayDevices by sending a search request to all multicast addresses or to the unicast address if specified.
    /// </summary>
    /// <param name="sendCount">The amount of times to repeat the discovery message.</param>
    /// <param name="timeoutInSeconds">The time to wait for a response from any InternetGatewayDevice. Should be 1-5.</param>
    /// <param name="ipEndPoint">If specified, a unicast discovery will be performed for the specified IP address and port instead of a multicast discovery.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
    /// <returns>The discovered <see cref="GroupedInternetGatewayDevice"/>.</returns>
    ValueTask<GroupedInternetGatewayDevice[]> GetInternetGatewayDevicesAsync(int sendCount = 1, int timeoutInSeconds = 1, IPEndPoint? ipEndPoint = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Discovers the specified device types by sending a search request to all multicast addresses or to the unicast address if specified.
    /// </summary>
    /// <param name="deviceTypes">The device types to discover.</param>
    /// <param name="sendCount">The amount of times to repeat the discovery message.</param>
    /// <param name="timeoutInSeconds">The time to wait for a response from any device. Should be 1-5.</param>
    /// <param name="ipEndPoint">If specified, a unicast discovery will be performed for the specified IP address and port instead of a multicast discovery.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
    /// <returns>The raw <see cref="ServerDeviceResponse"/> of the discovered devices.</returns>
    ValueTask<List<ServerDeviceResponse>> GetRawDeviceResponsesAsync(IEnumerable<string> deviceTypes, int sendCount = 1, int timeoutInSeconds = 1, IPEndPoint? ipEndPoint = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Connects to a specific IP address to look for an InternetGatewayDevice.
    /// </summary>
    /// <param name="ipAddress">The IP address of the InternetGatewayDevice.</param>
    /// <param name="port">The port to connect to on the InternetGatewayDevice.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
    /// <returns>The <see cref="GroupedInternetGatewayDevice"/> at the given IP address if any, <see langword="null" /> otherwise.</returns>
    ValueTask<GroupedInternetGatewayDevice?> GetInternetGatewayDeviceAsync(IPAddress ipAddress, ushort port = UPnPConstants.AvmPort, CancellationToken cancellationToken = default);
}