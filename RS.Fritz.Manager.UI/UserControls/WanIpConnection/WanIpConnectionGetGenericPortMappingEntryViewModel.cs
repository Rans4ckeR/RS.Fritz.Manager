namespace RS.Fritz.Manager.UI;

internal sealed class WanIpConnectionGetGenericPortMappingEntryViewModel : WanConnectionGetGenericPortMappingEntryViewModel
{
    public WanIpConnectionGetGenericPortMappingEntryViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger)
    {
    }

    protected override async ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
        => WanConnectionGetGenericPortMappingEntryResponse = await ExecuteApiAsync(q => q.WanIpConnectionGetGenericPortMappingEntryAsync(new(Index!.Value))).ConfigureAwait(true);
}