namespace RS.Fritz.Manager.API;

using System;
using System.Threading;
using System.Threading.Tasks;

public interface IDeviceMeshService
{
    Task<DeviceMesh> GetDeviceMeshAsync(Uri meshListPathUri, CancellationToken cancellationToken = default);
}