namespace RS.Fritz.Manager.UI;

internal sealed class WanIpConnectionGetGenericPortMappingEntryViewModel(DeviceLoginInfo deviceLoginInfo, ILogger<WanIpConnectionGetGenericPortMappingEntryViewModel> logger)
    : WanConnectionGetGenericPortMappingEntryViewModel(deviceLoginInfo, logger)
{
    protected override async ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
        => WanConnectionGetGenericPortMappingEntryResponse = await ExecuteApiAsync(q => q.WanIpConnectionGetGenericPortMappingEntryAsync(new(Index!.Value))).ConfigureAwait(true);
}