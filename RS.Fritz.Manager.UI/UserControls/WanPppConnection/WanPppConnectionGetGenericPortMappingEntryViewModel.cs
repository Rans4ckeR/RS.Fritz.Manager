namespace RS.Fritz.Manager.UI;

internal sealed class WanPppConnectionGetGenericPortMappingEntryViewModel(DeviceLoginInfo deviceLoginInfo, ILogger<WanPppConnectionGetGenericPortMappingEntryViewModel> logger)
    : WanConnectionGetGenericPortMappingEntryViewModel(deviceLoginInfo, logger)
{
    protected override async ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
        => WanConnectionGetGenericPortMappingEntryResponse = await ExecuteApiAsync(q => q.WanPppConnectionGetGenericPortMappingEntryAsync(new(Index!.Value))).ConfigureAwait(true);
}