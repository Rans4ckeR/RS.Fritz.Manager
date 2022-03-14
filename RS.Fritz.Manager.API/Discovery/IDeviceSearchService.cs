namespace RS.Fritz.Manager.API;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IDeviceSearchService
{
    Task<IEnumerable<InternetGatewayDevice>> GetDevicesAsync(string? deviceType = null, int? sendCount = null, int? timeout = null, CancellationToken cancellationToken = default);
}