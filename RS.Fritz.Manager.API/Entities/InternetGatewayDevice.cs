﻿namespace RS.Fritz.Manager.API;

using System.Net;

public sealed record InternetGatewayDevice(IFritzServiceOperationHandler FritzServiceOperationHandler, IUsersService UsersService, IEnumerable<Uri> Locations, string Server, string CacheControl, string? Ext, string SearchTarget, string UniqueServiceName, UPnPDescription UPnPDescription, Uri PreferredLocation, IReadOnlyCollection<IPAddress> LocalIpAddresses)
{
    private IReadOnlyCollection<ServiceListItem>? services;

    public ushort? SecurityPort { get; private set; }

    public User[]? Users { get; private set; }

    public NetworkCredential? NetworkCredential { get; set; }

    public IEnumerable<ServiceListItem> Services
        => services ??= UPnPDescription.Device.GetServices().ToArray();

    public async ValueTask InitializeAsync()
    {
        SecurityPort = (await this.DeviceInfoGetSecurityPortAsync().ConfigureAwait(false)).SecurityPort;
        Users = (await UsersService.GetUsersAsync(this).ConfigureAwait(false)).ToArray();
    }

    internal Task<TResult> ExecuteAsync<TResult>(Func<IFritzServiceOperationHandler, InternetGatewayDevice, Task<TResult>> operation)
        => operation(FritzServiceOperationHandler, this);
}