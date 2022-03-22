namespace RS.Fritz.Manager.API;

using System.Net;

public sealed record InternetGatewayDevice(IFritzServiceOperationHandler FritzServiceOperationHandler, IUsersService UsersService, IEnumerable<Uri> Locations, string Server, string CacheControl, string? Ext, string SearchTarget, string UniqueServiceName, Uri PreferredLocation)
{
    public UPnPDescription? UPnPDescription { get; set; }

    public ushort? SecurityPort { get; private set; }

    public User[]? Users { get; private set; }

    public NetworkCredential? NetworkCredential { get; set; }

    internal async Task<TResult> ExecuteAsync<TResult>(Func<IFritzServiceOperationHandler, InternetGatewayDevice, Task<TResult>> operation)
    {
        await InitializeAsync();

        return await operation(FritzServiceOperationHandler, this);
    }

    public async Task InitializeAsync()
    {
        if (SecurityPort is null)
            await GetSecurityPortAsync();

        if (Users is null)
            await GetUsersAsync();
    }

    private async Task GetSecurityPortAsync()
    {
        SecurityPort = (await FritzServiceOperationHandler.DeviceInfoGetSecurityPortAsync(this)).SecurityPort;
    }

    private async Task GetUsersAsync()
    {
        Users = (await UsersService.GetUsersAsync(this)).ToArray();
    }
}