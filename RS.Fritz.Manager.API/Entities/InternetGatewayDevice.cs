using System.Collections.Frozen;
using System.Net;

namespace RS.Fritz.Manager.API;

public sealed record InternetGatewayDevice(
    IFritzServiceOperationHandler FritzServiceOperationHandler,
    IUsersService UsersService,
    string? CacheControl,
    string? Date,
    string? Ext,
    IEnumerable<Uri?>? Locations,
    string? Server,
    string? SearchTarget,
    string? UniqueServiceName,
    string? Options,
    string? Nls,
    int? BootId,
    int? ConfigId,
    ushort? UnicastSearchPort,
    IEnumerable<Uri?>? SecureLocations,
    UPnPDescription? UPnPDescription,
    Uri? PreferredLocation,
    FrozenSet<IPAddress> LocalIpAddresses,
    ushort? Version)
{
    private IReadOnlyCollection<ServiceListItem>? services;

    public ushort? SecurityPort { get; private set; }

    public User[]? Users { get; private set; }

    public NetworkCredential? NetworkCredential { get; set; }

    public bool IsAvm => SearchTarget?.StartsWith(UPnPConstants.InternetGatewayDeviceAvmNamespace, StringComparison.OrdinalIgnoreCase) ?? false;

    public IEnumerable<ServiceListItem> Services
        => services ??= [.. UPnPDescription?.Device?.GetServices() ?? []];

    public async ValueTask InitializeAsync()
    {
        SecurityPort = (await this.DeviceInfoGetSecurityPortAsync().ConfigureAwait(false)).SecurityPort;
        Users = [.. await UsersService.GetUsersAsync(this).ConfigureAwait(false)];
    }

    internal Task<TResult> ExecuteAsync<TResult>(Func<IFritzServiceOperationHandler, InternetGatewayDevice, Task<TResult>> operation)
        => operation(FritzServiceOperationHandler, this);
}