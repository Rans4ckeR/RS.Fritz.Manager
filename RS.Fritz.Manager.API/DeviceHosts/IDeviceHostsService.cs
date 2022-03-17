namespace RS.Fritz.Manager.API;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IDeviceHostsService
{
    Task<IEnumerable<DeviceHost>> GetDeviceHostsAsync(Uri hostListPathUri, CancellationToken cancellationToken = default);
}