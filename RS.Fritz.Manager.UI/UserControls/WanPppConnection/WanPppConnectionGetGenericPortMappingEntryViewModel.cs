namespace RS.Fritz.Manager.UI;

internal sealed class WanPppConnectionGetGenericPortMappingEntryViewModel : WanConnectionGetGenericPortMappingEntryViewModel
{
    public WanPppConnectionGetGenericPortMappingEntryViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger)
    {
    }

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        WanConnectionGetGenericPortMappingEntryResponse = await ExecuteApiAsync(q => q.WanPppConnectionGetGenericPortMappingEntryAsync(Index!.Value));
    }
}