namespace RS.Fritz.Manager.API;

using System.Net;

public sealed record InternetGatewayDevice(IFritzServiceOperationHandler FritzServiceOperationHandler, IUsersService UsersService, IEnumerable<Uri> Locations, string Server, string CacheControl, string? Ext, string SearchTarget, string UniqueServiceName, UPnPDescription UPnPDescription, Uri PreferredLocation)
{
    private IReadOnlyCollection<ServiceListItem>? services;

    public ushort? SecurityPort { get; private set; }

    public User[]? Users { get; private set; }

    public NetworkCredential? NetworkCredential { get; set; }

    public IEnumerable<ServiceListItem> Services { get => services ??= UPnPDescription.Device.GetServices().ToArray(); }

    internal async Task<TResult> ExecuteAsync<TResult>(Func<IFritzServiceOperationHandler, InternetGatewayDevice, Task<TResult>> operation)
    {
        return await operation(FritzServiceOperationHandler, this);
    }

    public async Task InitializeAsync()
    {
        SecurityPort = (await this.DeviceInfoGetSecurityPortAsync()).SecurityPort;
        Users = (await UsersService.GetUsersAsync(this)).ToArray();
    }
}